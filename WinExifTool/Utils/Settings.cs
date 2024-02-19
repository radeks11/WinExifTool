using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinExifTool.Utils
{
    /// <summary>
    /// Deserialize lists stored in settings.
    /// </summary>
    public static class Settings
    {

        #region Zmienne prywatne

        /// <summary>
        /// Lista elementów do wykluczania
        /// </summary>
        private static Dictionary<string, PropertyItem> m_ExcludedProperties = new Dictionary<string, PropertyItem>();
        private static Dictionary<string, PropertyItem> m_MainProperties = new Dictionary<string, PropertyItem>();
        private static Dictionary<string, KeywordItem> m_Keywords = new Dictionary<string, KeywordItem>();
        private static HashSet<string> m_Patterns = new HashSet<string>();
        private static HashSet<string> m_Extensions;

        #endregion

        #region Właściwości

        /// <summary>
        /// ExcludedProperties 
        /// </summary>
        public static Dictionary<string, PropertyItem> ExcludedProperties
        {
            get { return m_ExcludedProperties; }
            set { m_ExcludedProperties = value; }
        }

        /// <summary>
        /// MainProperties
        /// </summary>
        public static Dictionary<string, PropertyItem> MainProperties
        {
            get { return m_MainProperties; }
            set { m_MainProperties = value; }
        }

        /// <summary>
        /// Keywords 
        /// </summary>
        public static Dictionary<string, KeywordItem> Keywords
        {
            get { return m_Keywords ; }
            set { m_Keywords = value; }
        }

        /// <summary>
        /// Patterns 
        /// </summary>
        public static HashSet<string> Patterns
        {
            get { return m_Patterns; }
            set { m_Patterns = value; }
        }

        /// <summary>
        /// Extensions
        /// </summary>
        public static HashSet<string> Extensions
        {
            get { return m_Extensions; }
            set { m_Extensions = value; }
        }

        #endregion

        #region Wczytywanie i zapisywanie ustawień

        /// <summary>
        /// Read settings required serialization
        /// </summary>
        public static bool ReadSettings()
        {
            ClearExecLog();
            m_ExcludedProperties = DeserializeFileProperty(Properties.Settings.Default.gvPropertiesExcludedProperties);
            m_MainProperties = DeserializeFileProperty(Properties.Settings.Default.gvPropertiesMainProperties);
            m_Keywords = DeserializeKeywords(Properties.Settings.Default.keywords);
            m_Patterns = DeserializeList(Properties.Settings.Default.patterns);
            m_Extensions = DeserializeList(Properties.Settings.Default.extensions);
            return ReadExifToolPath();
        }

        /// <summary>
        /// Write settings required serialization
        /// Perform save on all settings changed by user
        /// </summary>
        public static void SaveSettings(bool saveOnDisk)
        {
            Properties.Settings.Default.gvPropertiesExcludedProperties = SerializeList<string, PropertyItem>(m_ExcludedProperties);
            Properties.Settings.Default.gvPropertiesMainProperties = SerializeList<string, PropertyItem>(m_MainProperties);
            Properties.Settings.Default.keywords = SerializeList<string, KeywordItem>(m_Keywords);
            Properties.Settings.Default.extensions = SerializeList(m_Extensions, "|", string.Empty);
            if (saveOnDisk)
            {
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        #region ReadExifToolPath

        /// <summary>
        /// Check and read ExifTool path. ExifTool is required to proper work.
        /// </summary>
        /// <returns></returns>
        public static bool ReadExifToolPath()
        {
            if (Properties.Settings.Default.exiftool == string.Empty || !System.IO.File.Exists(Properties.Settings.Default.exiftool))
            {
                System.Windows.Forms.MessageBox.Show(Properties.Lang.exiftool_not_found);
                frmConfig frm = new frmConfig();
                frm.lblExifTool.ForeColor = System.Drawing.Color.Red;
                frm.lblExifTool.Font = new System.Drawing.Font(frm.lblExifTool.Font, System.Drawing.FontStyle.Bold);
                frm.ShowDialog();                
            }

            if (Properties.Settings.Default.exiftool == string.Empty || !System.IO.File.Exists(Properties.Settings.Default.exiftool))
            {
                return false;
            }
            {
                return true;
            }
        }

        #endregion

        #region Serializacja

        /// <summary>
        /// Serializuje słownik, w serializowanym stringu zapisywany jest tylko klucz ze słownika
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string SerializeList<T, V>(IDictionary<T, V> list) where V : ISerializableKeyItem
        {
            StringBuilder sb = new StringBuilder();
            IEnumerator<KeyValuePair<T, V>> en = list.GetEnumerator();
            while (en.MoveNext())
            {
                if (sb.Length > 0)
                {
                    sb.Append("|");
                }
                sb.Append(en.Current.Value.Key);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Serializuje Hashset
        /// </summary>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string SerializeList(HashSet<string> list, string delimiter, string prefix)
        {
            StringBuilder sb = new StringBuilder();
            HashSet<string>.Enumerator en = list.GetEnumerator();

            while (en.MoveNext())
            {
                if (sb.Length > 0)
                {
                    sb.Append(delimiter);
                }
                sb.Append(prefix + en.Current);
            }

            return sb.ToString();
        }

        #endregion

        #region Deserializacja

        /// <summary>
        /// Deserializuje string z listą właściwości pliku. 
        /// String
        ///     EXIF:CreateDate|EXIF:ModifyDate
        /// Zostanie zamieniony na
        ///     EXIF:CreateDate => 
        ///         Section:EXIF,
        ///         Property:CreateDate
        ///     EXIF:
        ///         Section:EXIF,
        ///         Property:ModifyDate
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static Dictionary<string, PropertyItem> DeserializeFileProperty(string setting)
        {
            Dictionary<string, PropertyItem> list = new Dictionary<string, PropertyItem>();
            string[] elements = setting.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string element in elements)
            {
                PropertyItem item = new PropertyItem(element);
                list.Add(item.Key, item);
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, KeywordItem> DeserializeKeywords(string setting)
        {
            List<string> keywords = setting.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            Dictionary<string, KeywordItem> list = new Dictionary<string, KeywordItem>();
            foreach (string keyword in keywords)
            {
                KeywordItem item = KeywordItem.Parse(keyword, true);
                list.Add(item.Keyword, item);
            }
            return list;
        }

        /// <summary>
        /// Deserializuje HashSet 
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static HashSet<string> DeserializeList(string setting)
        {
            return DeserializeList(setting, '|');
        }

        /// <summary>
        /// Deserializuje HashSet
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static HashSet<string> DeserializeList(string setting, char delimiter)
        {
            List<string> list = setting.Split(new char[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string s in list)
            {
                hashSet.Add(s);
            }
            return hashSet;
        }


        #endregion

        #region Excluded properties

        public static void AddExcludedProperty(DS.PropertiesRow row)
        {
            PropertyItem item = new PropertyItem(row.Section, row.Field);
            if (!m_ExcludedProperties.ContainsKey(item.Key))
            {
                m_ExcludedProperties.Add(item.Key, item);
            }
        }

        public static bool ExistsExcludedProperty(DS.PropertiesRow row)
        {
            PropertyItem item = new PropertyItem(row.Section, row.Field);
            return m_ExcludedProperties.ContainsKey(item.Key);
        }

        #endregion

        #region Main properties

        public static void AddMainProperty(DS.PropertiesRow row)
        {
            PropertyItem item = new PropertyItem(row.Section, row.Field);
            if (!m_MainProperties.ContainsKey(item.Key))
            {
                m_MainProperties.Add(item.Key, item);
            }
        }

        public static void RemoveMainProperty(DS.PropertiesRow row)
        {
            PropertyItem item = new PropertyItem(row.Section, row.Field);
            if (m_MainProperties.ContainsKey(item.Key))
            {
                m_MainProperties.Remove(item.Key);
            }
        }

        public static void AddRemoveMainProperty(DS.PropertiesRow row, bool add)
        {
            if (add)
            {
                AddMainProperty(row);
            }
            else
            {
                RemoveMainProperty(row);
            }
        }

        public static bool ExistsMainProperty(DS.PropertiesRow row)
        {
            PropertyItem item = new PropertyItem(row.Section, row.Field);
            return m_MainProperties.ContainsKey(item.Key);
        }

        public static string MainPropertyFilter()
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, PropertyItem>.Enumerator en = m_MainProperties.GetEnumerator();
            while (en.MoveNext())
            {
                if (sb.Length > 0)
                {
                    sb.Append(" or ");
                }
                sb.AppendFormat("(Section='{0}' and Field='{1}')", en.Current.Value.Section, en.Current.Value.Field);
            }
            return sb.ToString();
        }

        #endregion

        #region Keywords

        /// <summary>
        /// Dodaj element do ustawień
        /// </summary>
        public static void AddKeyword(KeywordItem item)
        {
            item.Template = true;
            if (!m_Keywords.ContainsKey(item.Key))
            {
                m_Keywords.Add(item.Key, item);
            }
        }

        /// <summary>
        /// Usuń element z ustawień
        /// </summary>
        public static void RemoveKeyword(KeywordItem item)
        {
            item.Template = false;
            if (m_Keywords.ContainsKey(item.Key))
            {
                m_Keywords.Remove(item.Key);
            }
        }

        #endregion

        #region Patterns

        /// <summary>
        /// Dodaj element do ustawień
        /// </summary>
        public static void AddPattern(string pattern)
        {
            if (!m_Patterns.Contains(pattern))
            {
                m_Patterns.Add(pattern);
            }
        }

        /// <summary>
        /// Usuń element z ustawień
        /// </summary>
        public static void RemovePattern(string pattern)
        {
            if (m_Patterns.Contains(pattern))
            {
                m_Patterns.Remove(pattern);
            }
        }

        #endregion

        #region Extensions

        public static bool IsKnownExtension(string extension)
        {
            if (extension.StartsWith("."))
            {
                return m_Extensions.Contains(extension.Substring(1));
            }
            else
            {
                return m_Extensions.Contains(extension);
            }
        }

        #endregion

        #region ClearExecLog

        /// <summary>
        /// Clear ExecLog. Remove files older theb 7 days.
        /// </summary>
        public static void ClearExecLog()
        {
            string executeLogFolder = ExifTool.GetExecuteLogFolder();
            foreach (string logfile in System.IO.Directory.GetFiles(executeLogFolder))
            {
                if (System.IO.File.GetLastWriteTime(logfile) < DateTime.Now.AddDays(-7))
                {
                    System.IO.File.Delete(logfile);
                }   
            }
        }

        #endregion
    }
}
