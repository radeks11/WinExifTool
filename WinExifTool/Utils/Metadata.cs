using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WinExifTool.Utils
{
    public partial class Metadata
    {

        #region Zmienne prywatne

        private bool m_DataChanged = false;
        private string m_FilePath;
        private SortedDictionary<string, string> m_Properties;
        private SortedDictionary<string, string> m_Changes;
        private SortedDictionary<string, string> m_MergedProperties;
        private DS.FilesRow m_Row;
        // private static readonly Regex m_ParseCSV = new Regex("[,]{1}(?=(?:[^\\\"]*\\\"[^\\\"]*\\\")*(?![^\\\"]*\\\"))");
        private static readonly string[] DATE_PATTERNS = { "dd-MM-yyyy HH:mm:ss", "dd-MM-yyyy", "MM/dd/yyyy HH:mm:ss" };
        private static readonly string DATE_FORMAT = "dd-MM-yyyy HH:mm:ss";
        private static readonly DateTime DEF_DATE = new DateTime(1900, 1, 1);

        #endregion

        #region Właściwości 

        /// <summary>
        /// FilePath 
        /// </summary>
        public string FilePath
        {
            get { return m_FilePath; }
            set { m_FilePath = value; }
        }

        /// <summary>
        /// Properties 
        /// </summary>
        public SortedDictionary<string, string> Properties
        {
            get { return m_Properties; }
            set { m_Properties = value; }
        }

        /// <summary>
        /// Current properties with changes applied
        /// </summary>
        public SortedDictionary<string, string> MergedProperties
        {
            get 
            { 
                if (m_DataChanged || m_MergedProperties == null)
                {
                    m_MergedProperties = new SortedDictionary<string, string>(m_Properties);
                    CollectionHelper.Merge(m_MergedProperties, m_Changes);
                    m_DataChanged = false;
                }
                return m_MergedProperties; 
            }
        }

        /// <summary>
        /// Changes 
        /// </summary>
        public SortedDictionary<string,string> Changes
        {
            get { return m_Changes; }
            set { m_Changes = value; }
        }

        /// <summary>
        /// Does metadata contains changes
        /// </summary>
        public bool HasMetadataChanges
        {
            get
            {
                SortedDictionary<string, string>.Enumerator enumerator = m_Changes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Key.StartsWith("EXIF:") || enumerator.Current.Key.StartsWith("IPTC:") || enumerator.Current.Key.StartsWith("XMP:") || enumerator.Current.Key.StartsWith("Composite:"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public DateTime ChangedFileDate
        {
            get
            {
                return CollectionHelper.Get(m_Changes, "File:FileCreateDate", DateTime.MinValue);
            }
        }

        /// <summary>
        /// Row 
        /// </summary>
        public DS.FilesRow Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }

        #endregion

        #region Konstruktor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        public Metadata(string filepath)
        {
            m_FilePath = filepath;
            m_Properties = new SortedDictionary<string, string>();
            m_Changes = new SortedDictionary<string, string>();
            m_MergedProperties = null;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="properties"></param>
        public Metadata(string filepath, SortedDictionary<string, string> properties)
        {
            m_FilePath = filepath;
            m_Properties = properties;
            m_Changes = new SortedDictionary<string, string>();
            m_MergedProperties = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="properties"></param>
        /// <param name="changes"></param>
        public Metadata(string filepath, SortedDictionary<string, string> properties, object changes)
        {
            m_FilePath = filepath;
            m_Properties = properties;
            m_Changes = changes == DBNull.Value ? new SortedDictionary<string, string>() : (SortedDictionary<string, string>)changes;
            m_MergedProperties = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public Metadata(DS.FilesRow row)
        {
            m_Row = row;
            m_FilePath = row.FilePath;
            m_Properties =  row.IsPropertiesNull() ? new SortedDictionary<string, string>() : (SortedDictionary<string, string>)row.Properties;
            m_Changes = row.IsChangesNull() ? new SortedDictionary<string, string>() : (SortedDictionary<string, string>)row.Changes;
            m_MergedProperties = null;
        }

        #endregion

        #region CSV

        /// <summary>
        /// Parsuje linię CSV i zwraca obiekt Metadata
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="header"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Metadata ParseCSV(string filepath, string header, string line)
        {
            Metadata metadata = new Metadata(filepath);
            metadata.ReadPropertiesFromCSV(header, line);
            return metadata;
        }

        /// <summary>
        /// Zamienia właściwości pliku, exif itd z linii tekstowej na obiekt SortedDictionary
        /// </summary>
        /// <param name="headerline"></param>
        /// <param name="dataline"></param>
        /// <returns></returns>
        private SortedDictionary<string, string> ReadPropertiesFromCSV(string headerline, string dataline)
        {
            List<string> header = parseCSVLine(headerline, ',');
            List<string> data = parseCSVLine(dataline, ',');

            if (header.Count != data.Count)
            {
                return m_Properties;
            }

            for (int i = 0; i < header.Count; i++)
            {
                string value = TrimQuotes(data[i]);
                m_Properties.Add(header[i], value);
            }

            return m_Properties;
        }

        private string TrimQuotes(string s)
        {
            if (s.Length == 0)
            {
                return s;
            }

            if (s[s.Length - 1] == '"')
            {
                s = s.Substring(0, s.Length - 1);
            }

            if (s[0] == '"')
            {
                s = s.Substring(1);
            }

            return s;
        }

        #endregion

        #region Parsowanie CSV

        private enum charType : int { NormalChar = 0, Quote = 1, Delimiter = 2, Skip = 3 };

        /// <summary>
        /// Parsuje linię
        /// </summary>
        /// <param name="line">string zawierający linię do parsowania</param>
        /// <param name="delimiter">znak rozdzielający</param>
        /// <returns>Wartości po parsowaniu</returns>
        public static List<string> parseCSVLine(string line, char delimiter)
        {
            return parseCSVLine(line, delimiter, '"');
        }

        /// <summary>
        /// Parsuje linię
        /// </summary>
        /// <param name="line">string zawierający linię do parsowania</param>
        /// <param name="delimiter">znak rozdzielający</param>
        /// <param name="quote">cudzysłów</param>
        /// <returns>Wartości po parsowaniu</returns>
        public static List<string> parseCSVLine(string line, char delimiter, char quote)
        {
            List<string> fields = new List<string>();

            bool IsQuoted = false;
            bool IsFirst = true;
            bool SkipNextChar = false;
            System.Text.StringBuilder s = new System.Text.StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                /*
                 * Domyślne typy znaków
                 */
                charType currentCharType = charType.NormalChar;
                charType nextCharType = charType.NormalChar;

                /*
                 * Okreslenie typu znaku
                 */
                if (line[i] == quote)
                    currentCharType = charType.Quote;
                else if (line[i] == delimiter)
                    currentCharType = charType.Delimiter;
                else if (line[i] == 13)
                    currentCharType = charType.Skip;

                /*
                 * Określenie typu następnego znaku
                 */
                if (i + 1 < line.Length)
                {
                    if (line[i + 1] == quote)
                        nextCharType = charType.Quote;
                    else if (line[i + 1] == delimiter)
                        nextCharType = charType.Delimiter;
                    else if (line[i + 1] == 13)
                        nextCharType = charType.Skip;
                }
                else
                    nextCharType = charType.Delimiter;

                /*
                 * Algorytm rozpoznawania
                 */
                if (SkipNextChar || currentCharType == charType.Skip)
                {
                    // znaki do ominięcia
                    SkipNextChar = false;
                    IsFirst = false;
                }
                else if (currentCharType == charType.Delimiter)
                {
                    if (!IsQuoted)
                    {
                        fields.Add(s.ToString());
                        s = new System.Text.StringBuilder();
                        IsQuoted = false;
                        IsFirst = true;
                    }
                    else
                    {
                        IsFirst = false;
                        s.Append(line[i]);
                    }
                }
                else if (currentCharType == charType.Quote)
                {
                    if (IsFirst)
                    {
                        IsQuoted = true;
                        IsFirst = false;
                    }
                    else if (IsQuoted)
                    {
                        if (nextCharType == charType.Delimiter || nextCharType == charType.Skip)
                        {
                            IsQuoted = false;
                        }
                        else if (nextCharType == charType.Quote)
                        {
                            s.Append(line[i]);
                            IsFirst = false;
                            SkipNextChar = true;
                        }
                        else
                            throw new Exception("Błąd podczas parsowania linii");
                    }
                    else
                        throw new Exception("Błąd podczas parsowania linii");
                }
                else
                {
                    s.Append(line[i]);
                    IsFirst = false;
                }
            }
            fields.Add(s.ToString());

            return fields;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static public string CleanString(string s)
        {
            if (s != null && s.Length > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(s.Length);
                foreach (char c in s)
                {
                    sb.Append(Char.IsControl(c) ? ' ' : c);
                }
                s = sb.ToString();
            }
            return s;
        }

        #endregion Parsowanie CSV

        #region FillPropertiesTable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        public void FillPropertiesTable(DS.PropertiesDataTable table, bool filterOutExcluded)
        {
            table.Rows.Clear();

            // Połącz słowniki

            CollectionHelper.Merge(m_Properties, m_Changes);

            // 
            SortedDictionary<string, string>.Enumerator enumerator = m_Properties.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DS.PropertiesRow row = table.NewPropertiesRow();

                // Klucz dzielimy na Sekcję i Pole
                string[] parts = enumerator.Current.Key.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    row.Section = parts[0];
                    row.Field = parts[1];
                }
                else
                {
                    row.Section = "File";
                    row.Field = enumerator.Current.Key;
                }

                row.Value = enumerator.Current.Value;
                row.Changed = m_Changes.ContainsKey(enumerator.Current.Key);

                if ( !( Settings.ExistsExcludedProperty(row) && filterOutExcluded) )
                {
                    table.Rows.Add(row);
                }
            }
        }



        #endregion

        #region DS.Files

        /// <summary>
        /// Build DS.Files row 
        /// </summary>
        public void BuildFilesRow()
        {
            if (m_Row == null)
            {
                return;
            }

            m_Row.Properties = Properties;

            if (Changes.Count == 0)
            {
                m_Row.SetChangesNull();
            }
            else
            {
                m_Row.Changes = Changes;
            }
            m_Row.Keywords = Get("IPTC:Keywords");
            m_Row.Headline = Get("IPTC:Headline");
            m_Row.Title = Get(new string[] { "IPTC:ObjectName", "XMP:Title" });
            m_Row.GPS = Get("Composite:GPSPosition");
            m_Row.Caption = Get(new string[] { "IPTC:Caption-Abstract", "XMP:Description" });
            m_Row.Rating = Get("XMP:Rating");
            string createDate = Get(new string[] { "EXIF:DateTimeOriginal", "EXIF:CreateDate", "File:FileCreateDate" });
            m_Row.CreateDate = ParseDate(createDate, m_Row.FileOrgDate);
        }

        /// <summary>
        /// Reset DS.Files row, clear all changes and build row from scratch 
        /// </summary>
        public void ResetRow()
        {
            if (m_Row == null)
            {
                return;
            }

            m_Row.Properties = Properties;
            m_Row.SetChangesNull();
            m_Changes = new SortedDictionary<string, string>();
            BuildFilesRow();
        }

        /// <summary>
        /// Apply changes to DS.Files row and start 
        /// </summary>
        public void CommitChanges()
        {
            if (m_Row == null)
            {
                return;
            }

            m_Properties = m_MergedProperties;
            m_Changes = new SortedDictionary<string, string>();
            m_MergedProperties = new SortedDictionary<string, string>();
            m_DataChanged = true;
            BuildFilesRow();
        }

        #endregion

        #region Get value from merged properties

        /// <summary>
        /// Helps to get actual value from merged properties
        /// </summary>
        /// <param name="key">Key name, eg: IPTC:Caption</param>
        /// <returns></returns>
        public string Get(string key)
        {
            return CollectionHelper.Get(MergedProperties, key);
        }

        /// <summary>
        /// Helps to get actual value from merged properties from given list. 
        /// </summary>
        /// <param name="keys">List of keys.</param>
        /// <returns>First non empty value from the keys</returns>
        public string Get(IEnumerable<string> keys)
        {
            return CollectionHelper.Get(MergedProperties, keys);
        }

        /// <summary>
        /// Helps to get actual int value from merged properties
        /// </summary>
        /// <param name="key">Key name, eg: XMP:Rating</param>
        /// <param name="notFoundValue">Value returned if key is not found or empty</param>
        /// <returns>Integer value from merged properties or given <paramref name="notFoundValue"/></returns>
        public int Get(string key, int notFoundValue)
        {
            return CollectionHelper.Get(MergedProperties, key, notFoundValue);
        }

        /// <summary>
        /// Helps to get actual <see cref="DateTime"/> value from merged properties
        /// </summary>
        /// <param name="key">Key name, eg: EXIF:CreateDate</param>
        /// <param name="notFoundValue">Value returned if key is not found or empty</param>
        /// <returns><see cref="DateTime"/> value from merged properties or given <paramref name="notFoundValue"/></returns>
        public DateTime Get(string key, DateTime notFoundValue)
        {
            return CollectionHelper.Get(MergedProperties, key, notFoundValue);
        }

        /// <summary>
        /// Helps to get actual <see cref="List{T}"/> values from merged properties
        /// </summary>
        /// <param name="key">Key name, eg: IPTC:Keywords</param>
        /// <param name="delimiter">Delimiter to split values into list</param>
        /// <returns><see cref="List{T}"/> values</returns>
        public List<string> GetList(string key, char delimiter)
        {
            return CollectionHelper.GetList(MergedProperties, key, delimiter);
        }

        #endregion

        #region Set value in Changes

        /// <summary>
        /// Set string value in changes 
        /// </summary>
        /// <param name="key">Key name, eg: IPTC:Caption</param>
        /// <param name="value">String value</param>
        public void Set(string key, string value)
        {
            CollectionHelper.Set(Changes, key, value);
            m_DataChanged = true;
        }

        /// <summary>
        /// Set <see cref="DateTime"/> value in changes 
        /// </summary>
        /// <param name="key">Key name, eg: IPTC:Caption</param>
        /// <param name="value"><see cref="DateTime"/> value</param>
        public void Set(string key, DateTime value)
        {
            CollectionHelper.Set(Changes, key, value);
            m_DataChanged = true;
        }

        /// <summary>
        /// Set list of values in changes
        /// </summary>
        /// <param name="key">Key name, eg: IPTC:Keywords</param>
        /// <param name="values">List of values</param>
        /// <param name="delimiter">Delimiter to split values into list</param>
        public void SetList(string key, IEnumerable<string> values, char delimiter)
        {
            CollectionHelper.SetList(Changes, key, values, delimiter);
            m_DataChanged = true;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Determine if key exists and contains value in merged properties
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            string value;
            if (MergedProperties.TryGetValue(key, out value))
            {
                return value != string.Empty;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region ParseDate

        /// <summary>
        /// Konwertuje string do daty wg podanego wzoru
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static DateTime ParseDate(string s, string pattern)
        {
            System.Globalization.DateTimeFormatInfo DateFormatPattern = new System.Globalization.DateTimeFormatInfo();
            DateFormatPattern.ShortDatePattern = pattern;
            return DateTime.ParseExact(s, pattern, DateFormatPattern);
        }

        /// <summary>
        /// Konwertuje string do daty wg podanego wzoru. W przypadku błędu lub niemożności konwersji zwraca DefaultValue
        /// </summary>
        /// <param name="s">String zawierający datę</param>
        /// <param name="defaultDate">Wartość do zwrócenia w przypadku, gdy konwersja nie jest możliwa</param>
        /// <returns></returns>
        public static DateTime ParseDate(string s, DateTime defaultDate)
        {
            
            foreach (string pattern in DATE_PATTERNS)
            {
                if (String.IsNullOrEmpty(s))
                {
                    return defaultDate;
                }

                try
                {
                    return ParseDate(s, pattern);
                }
                catch
                { }
            }

            return DEF_DATE;
        }

        /// <summary>
        /// Konwertuje string do daty wg podanego wzoru. W przypadku błędu lub niemożności konwersji zwraca DefaultValue
        /// </summary>
        /// <param name="s">String zawierający datę</param>
        /// <returns></returns>
        public static DateTime ParseDate(string s)
        {
            return ParseDate(s, DEF_DATE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string DateTimeToString(DateTime d)
        {
            return d.ToString(DATE_FORMAT);
        }

        #endregion

        #region ReadFileDates

        /// <summary>
        /// Read dates of file
        /// </summary>
        public void ReadFileDates()
        {
            try
            {
                CollectionHelper.Set(m_Properties, "File:FileCreateDate", System.IO.File.GetCreationTime(FilePath));
                CollectionHelper.Set(m_Properties, "File:FileModifyDate", System.IO.File.GetLastWriteTime(FilePath));
            }
            catch { }
        }

        #endregion
    }

}
