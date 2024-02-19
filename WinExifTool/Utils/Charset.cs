using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinExifTool.Utils
{
    public class Charset
    {
        /// <summary>
        /// List of available charsets
        /// </summary>
        private static readonly Dictionary<int, string> m_CharsetList = new Dictionary<int, string>()
        {
            { 65001, "UTF8" },
            { 1252, "Latin" },
            { 1250, "Latin2" },
            { 1251, "Cyrillic" },
            { 1253, "Greek" },
            { 1254, "Turkish" },
            { 1255, "Hebrew" },
            { 1256, "Arabic" },
            { 1257, "Baltic" },
            { 1258, "Vietnam" },
            { 437, "DOSLatinUS" },
            { 850, "DOSLatin1" },
            { 852, "DOSLatin2" },
            { 866, "DOSCyrillic" }
        };

        /// <summary>
        /// 
        /// </summary>
        private int m_Codepage;

        /// <summary>
        /// 
        /// </summary>
        private string m_Name;

        /// <summary>
        /// 
        /// </summary>
        public Charset()
        {
            m_Codepage = 65001;
            m_Name = m_CharsetList[m_Codepage];
        }

        public Charset(int codepage)
        {
            m_Codepage = codepage;
            m_Name = m_CharsetList[codepage];
        }


        ///// <summary>
        ///// Codepage 
        ///// </summary>
        public int Codepage
        {
            get { return m_Codepage; }
        }

        /// <summary>
        /// Name of charset
        /// </summary>
        public string Name
        {
            get { return m_Name; }
        }

        /// <summary>
        /// Name of charset
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_Name;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FileCharset
        {
            get { return string.Format("-charset filename={0}", this.ToString() ); }
        }

        /// <summary>
        /// Pobiera listę języków
        /// </summary>
        /// <typeparam name="T">ListItem</typeparam>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Charset> Select()
        {
            List<Charset> list = new List<Charset>();
            Dictionary<int, string>.Enumerator en = m_CharsetList.GetEnumerator();
            while (en.MoveNext())
            {
                Charset c = new Charset(en.Current.Key);
                list.Add(c);
            }
            return list;
        }
    }
}
