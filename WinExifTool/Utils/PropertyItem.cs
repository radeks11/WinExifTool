using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinExifTool.Utils 
{
    [DataObject(true)]
    public class PropertyItem : ISerializableKeyItem
    {
        #region Zmienne prywatne 

        /// <summary>
        /// Nazwa sekcji
        /// </summary>
        private string m_Section;

        /// <summary>
        /// Nazwa pola
        /// </summary>
        private string m_Field;

        /// <summary>
        /// 
        /// </summary>
        private static readonly List<string> m_Properties = new List<string> {
            "IPTC:By-line",
            "IPTC:Caption-Abstract",
            "IPTC:Category",
            "IPTC:City",
            "IPTC:Country-PrimaryLocationCode",
            "IPTC:Country-PrimaryLocationName",
            "IPTC:Headline",
            "IPTC:ObjectName",
            "IPTC:Province-State",
            "IPTC:SupplementalCategories",
            "XMP:Country",
            "XMP:CountryCode",
            "XMP:Creator",
            "XMP:City",
            "XMP:Description",
            "XMP:Rating",
            "XMP:State",
            "XMP:Title"
        };

        #endregion

        #region Właściwości

        /// <summary>
        /// Section 
        /// </summary>
        public string Section
        {
            get { return m_Section; }
            set { m_Section = value; }
        }

        /// <summary>
        /// Field 
        /// </summary>
        public string Field
        {
            get { return m_Field; }
            set { m_Field = value; }
        }

        /// <summary>
        /// Klucz złożony składający się z nazwy sekcji i pola. Pełni jednoczeście rolę serializacji i deserializacji elementu 
        /// </summary>
        public string Key
        {
            get { return m_Section + ":" + m_Field; }
            set
            {
                string[] parts = value.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                m_Section = parts[0];
                m_Field = parts[1];
            }
        }

        /// <summary>
        /// Properties 
        /// </summary>
        public static List<string> Properties
        {
            get { return m_Properties; }
        }

        #endregion

        #region Metody

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Key;
        }

        #endregion

        #region Konstruktor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public PropertyItem(string key)
        {
            string[] parts = key.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            m_Section = parts[0];
            m_Field = parts[1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="field"></param>
        public PropertyItem(string section, string field)
        {
            m_Section = section;
            m_Field = field;
        }

        #endregion

        /// <summary>
        /// Pobiera listę języków
        /// </summary>
        /// <typeparam name="T">ListItem</typeparam>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<PropertyItem> Select()
        {
            List<PropertyItem> list = new List<PropertyItem>();

            foreach (string key in m_Properties)
            {
                PropertyItem p = new PropertyItem(key);
                list.Add(p);
            }
            return list;
        }
    }
}
