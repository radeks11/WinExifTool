using System;
using System.Collections.Generic;
using System.Linq;
using WinExifTool.CollectionEx;
using System.Text;
using System.Threading.Tasks;


namespace WinExifTool.Utils
{
    public class KeywordItem : ISerializableKeyItem
    {

        #region Zmienne prywatne

        private string m_Section;
        private string m_Keyword;
        private bool m_Template;
        private System.Windows.Forms.CheckState m_CheckState;

        #endregion

        #region Właściwości

        /// <summary>
        /// Nazwa sekcji
        /// </summary>
        public string Section
        {
            get { return m_Section; }
            set { m_Section = value; }
        }

        /// <summary>
        /// Słowo kluczowe. Puste słowo kluczowe oznacza nagłówek sekcji
        /// </summary>
        public string Keyword
        {
            get { return m_Keyword; }
            set { m_Keyword = value; }
        }

        /// <summary>
        /// Czy element pochodzi ze zdefiniowanych słów kluczowych
        /// </summary>
        public bool Template
        {
            get { return m_Template; }
            set { m_Template = value; }
        }

        /// <summary>
        /// CheckState 
        /// </summary>
        public System.Windows.Forms.CheckState CheckState
        {
            get { return IsSection ? System.Windows.Forms.CheckState.Unchecked : m_CheckState; }
            set { m_CheckState = value; }
        }

        /// <summary>
        /// Czy element jest nagłówkiem sekcji
        /// </summary>
        public bool IsSection
        {
            get { return m_Keyword == string.Empty; }
        }

        /// <summary>
        /// Klucz dla zapisania elementu w ustawieniach
        /// </summary>
        public string Key
        {
            get { return IsSection ? m_Section : m_Section + ":" + m_Keyword; }
        }

        #endregion

        #region Konstruktor

        public KeywordItem(string section) : this(section, string.Empty, false)
        {

        }

        public KeywordItem(string section, string keyword) : this(section, keyword, false)
        {

        }

        public KeywordItem(DS.KeywordsRow row) : this(row.Section, row.Keyword, row.Template, (System.Windows.Forms.CheckState)row.TAG)
        {

        }

        public KeywordItem(string section, string keyword, bool template) : this(section, keyword, template, System.Windows.Forms.CheckState.Indeterminate)
        {

        }

        public KeywordItem(string section, string keyword, bool template, System.Windows.Forms.CheckState state)
        {
            m_Section = section == string.Empty ? "Pozostałe" : section;
            m_Keyword = keyword;
            m_CheckState = state;
            m_Template = template;
        }

        #endregion

        #region Metody

        public override string ToString()
        {
            return Key;
        }

        public KeywordItem Clone()
        {
            return (KeywordItem)this.MemberwiseClone();
        }

        public DS.KeywordsRow NewRow(DS ds)
        {
            DS.KeywordsRow row = ds.Keywords.NewKeywordsRow();

            if (this.Keyword == string.Empty)
            {
                // Nagłówek sekcji
                row.Section = this.Section;
                row.Keyword = "." + this.Section;
                row.Caption = this.Section;
                row.Template = false;
                row.TAG = (int)System.Windows.Forms.CheckState.Unchecked;

            }
            else
            {
                // Wiersz normalnego słowa kluczowego
                row.Section = this.Section;
                row.Keyword = this.Keyword;
                row.Caption = this.Keyword;
                row.Template = Settings.Keywords.ContainsKey(this.Keyword);
                row.TAG = (int)this.CheckState;

            }
            return row;
        }

        #endregion

        #region Statyczne

        /// <summary>
        /// Parsuje słowo kluczowe ze słownika.
        /// Miejsca:Praga  ->  Sekcja: Miejsca, Keyword: Praga
        /// Konie          ->  Sekcja: (brak) Pozostałe, Keyword: Konie 
        /// </summary>
        /// <param name="s">Tekst do parsowania</param>
        /// <param name="template">Czy ustawić element jako template</param>
        /// <returns></returns>
        public static KeywordItem Parse(string s, bool template)
        {
            string[] parts = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
            {
                return new KeywordItem(string.Empty, parts[0], template);
            }
            else if (parts.Length >= 2)
            {
                return new KeywordItem(parts[0], parts[1], template);
            }
            else
            {
                return new KeywordItem(string.Empty, "Błąd parsowania: " + s);
            }
        }

        #endregion

        #region Comparer

        /// <summary>
        /// Klasa porównująca elementy typu <see cref="KeywordItem"/> wg key
        /// </summary>
        public class KeywordItemComparer : Comparer<KeywordItem>
        {
            /// <summary>
            /// Comparer
            /// </summary>
            /// <param name="x">pierwszy element porównania</param>
            /// <param name="y">drugi element porównania</param>
            /// <returns>wynik porównania</returns>
            public override int Compare(KeywordItem x, KeywordItem y)
            {
                int i = System.Collections.Comparer.Default.Compare(x.Section, y.Section);
                if (i == 0)
                {
                    return System.Collections.Comparer.Default.Compare(x.Keyword, y.Keyword);
                }
                return i;
            }
        }

        #endregion

    }
}
