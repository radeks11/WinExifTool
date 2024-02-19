namespace WinExifTool.Utils
{
    /// <summary>
    /// Klasa pomocnicza dla elementu ComboBox
    /// </summary>
    public class ListItem
    {
        private string m_Key;
        private string m_Description;

        /// <summary>
        /// ClassName 
        /// </summary>
        public string Key
        {
            get { return m_Key; }
            set { m_Key = value; }
        }

        /// <summary>
        /// Description 
        /// </summary>
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="className"></param>
        /// <param name="description"></param>
        public ListItem(string key, string description)
        {
            m_Key = key;
            m_Description = description;
        }

        /// <summary>
        /// Jako string zwracany jest opis klasy
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_Description;
        }
    }
}
