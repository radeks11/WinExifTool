using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinExifTool.Utils;
using WinExifTool.CollectionEx;
using System.Drawing;

namespace WinExifTool
{
    public partial class frmMetadata : Form
    {
        #region Zmienne prywatne

        private List<DS.FilesRow> m_Files = new List<DS.FilesRow>();
        private frmMain m_MainForm;
        private Dictionary<string, int> m_KeywordsInFiles;              // Każde napotkane słowo kluczowe tu ląduje        
        HashSet<string> m_Sections = new HashSet<string>();             // Sekcje
        private bool m_ClickFlag = false;

        DataGridViewCellStyle m_KeywordSectionHeaderStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle m_KeywordRegularStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle m_KeywordTemplateStyle = new DataGridViewCellStyle();

        /// <summary>
        /// Lista zmienionych słów kluczowych z kluczem takim jak słowo kluczowe bez sekcji
        /// </summary>
        Dictionary<string, KeywordItem> m_ChangedKeywords = new Dictionary<string, KeywordItem>();

        #endregion

        #region Właściwości

        /// <summary>
        /// Files 
        /// </summary>
        public List<DS.FilesRow> Files
        {
            get { return m_Files; }
            set { 
                
                if (m_Files.GetHashCode() == value.GetHashCode())
                {
                    return;
                }

                m_Files = value;
                
                if (m_Files.Count == 1)
                {
                    tsMessage.Text = m_Files[0].FileName;
                }
                else
                {
                    tsMessage.Text = string.Format("Ilość plików: {0}", Files.Count);
                }
                MakeTemplate();
                Invalidate();
            }
        }

        /// <summary>
        /// MainForm 
        /// </summary>
        public frmMain MainForm
        {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }

        private int Rating
        {
            get
            {
                for (int i = 5; i > 0; i--)
                {
                    RadioButton cbRatingX = (RadioButton)Controls.Find("cbRating" + i.ToString(), false)[0];
                    if (cbRatingX.Checked)
                    {
                        return i;
                    }
                }

                return 0;
            }
            set
            {
                for (int i = 1; i <= 5; i++)
                {
                    RadioButton cbRatingX = (RadioButton)Controls.Find("cbRating" + i.ToString(), false)[0];
                    cbRatingX.Checked = i <= value;
                }
            }
        }

        #endregion

        #region Konstruktor, Load i Close

        public frmMetadata()
        {
            InitializeComponent();
        }

        private void frmEditIPTC_Load(object sender, EventArgs e)
        {
            // Style
            m_KeywordSectionHeaderStyle.BackColor = Color.LightGray;
            m_KeywordSectionHeaderStyle.SelectionBackColor = Color.LightGray;
            m_KeywordSectionHeaderStyle.ForeColor = Color.Black;
            m_KeywordSectionHeaderStyle.SelectionForeColor = Color.Black;
            m_KeywordSectionHeaderStyle.Font = new Font(this.Font, FontStyle.Bold);

            m_KeywordRegularStyle.BackColor = SystemColors.Window;
            m_KeywordRegularStyle.SelectionBackColor = SystemColors.Window;
            m_KeywordRegularStyle.ForeColor = Color.Black;
            m_KeywordRegularStyle.SelectionForeColor = Color.Black;
            m_KeywordRegularStyle.Font = new Font(this.Font, FontStyle.Regular);

            m_KeywordTemplateStyle.BackColor = SystemColors.Window;
            m_KeywordTemplateStyle.SelectionBackColor = SystemColors.Window;
            m_KeywordTemplateStyle.ForeColor = Color.DarkViolet;
            m_KeywordTemplateStyle.SelectionForeColor = Color.DarkViolet;
            m_KeywordTemplateStyle.Font = new Font(this.Font, FontStyle.Regular);

            gvKeywords.AutoGenerateColumns = false;
            gvKeywords.DataSource = bsKeywords;
            gvKeywords_Resize(null, null);
        }

        private void frmEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_MainForm.MetadataForm = null;
        }

        private void frmMetadata_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    cbRating1.Checked = true;
                    break;
                case Keys.D2:
                    cbRating2.Checked = true;
                    break;
                case Keys.D3:
                    cbRating3.Checked = true;
                    break;
                case Keys.D4:
                    cbRating4.Checked = true;
                    break;
                case Keys.D5:
                    cbRating5.Checked = true;
                    break;
            }
        }

        #endregion

        #region OK i Cancel

        private void btnOK_Click(object sender, EventArgs e)
        {
            MakeChangedKeywords();
            foreach (DS.FilesRow row in Files)
            {
                Metadata metadata = new Metadata(row);
                
                // Pamiętaj, że edytowane pola trzeba zdefiniować do zapisania w ExifTool.cs
                MakeChangesTextBox(txtHeadline, metadata, "IPTC:Headline");
                MakeChangesTextBox(txtTitle, metadata, "IPTC:ObjectName", "XMP:Title");
                MakeChangesTextBox(txtCaption, metadata, "IPTC:Caption-Abstract", "XMP:Description");
                MakeChangesTextBox(txtAuthor, metadata, "IPTC:By-line", "XMP:Creator");
                MakeChangesTextBox(txtCategory, metadata, "IPTC:Category");
                MakeChangesTextBox(txtSupplementalCategories, metadata, "IPTC:SupplementalCategories");
                MakeChangesTextBox(txtCity, metadata, "IPTC:City", "XMP:City");
                MakeChangesTextBox(txtProvince, metadata, "IPTC:Province-State", "XMP:State");
                MakeChangesTextBox(txtCountry, metadata, "IPTC:Country-PrimaryLocationName", "XMP:Country");
                MakeChangesTextBox(txtCountryCode, metadata, "IPTC:Country-PrimaryLocationCode", "XMP:CountryCode");

                makeChangesKeywords(metadata);
                MakeChangesRating(metadata);

                if (metadata.Changes.Count > 0)
                {
                    metadata.BuildFilesRow();
                }
            }
            m_MainForm.TagChanged();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Make Template

        private void Reset()
        {
            m_KeywordsInFiles = new Dictionary<string, int>();
            ds.Keywords.Rows.Clear();
            txtHeadline.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtCaption.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtSupplementalCategories.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtCountryCode.Text = string.Empty;
            cbHeadline.CheckState = CheckState.Indeterminate;
            cbTitle.CheckState = CheckState.Indeterminate;
            cbCaption.CheckState = CheckState.Indeterminate;
            cbAuthor.CheckState = CheckState.Indeterminate;
            cbCategory.CheckState = CheckState.Indeterminate;
            cbSupplementalCategories.CheckState = CheckState.Indeterminate;
            cbCity.CheckState = CheckState.Indeterminate;
            cbProvince.CheckState = CheckState.Indeterminate;
            cbCountry.CheckState = CheckState.Indeterminate;
            cbCountryCode.CheckState = CheckState.Indeterminate;
            cbRating.CheckState = CheckState.Indeterminate;
            cbRating.Tag = -1;
        }

        private void MakeTemplate()
        {
            // Zmienne na słowa kluczowe
            Reset();

            // Ustaw domyślne wartości
            foreach (DS.FilesRow file in m_Files)
            {
                Metadata metadata = new Metadata(file);

                NakeTemplateTextBox(txtHeadline, metadata, "IPTC:Headline");
                MakeTemplateTextBox(txtTitle, metadata, "IPTC:ObjectName", "XMP:Title");
                MakeTemplateTextBox(txtCaption, metadata, "IPTC:Caption-Abstract", "XMP:Description");
                MakeTemplateTextBox(txtAuthor, metadata, "IPTC:By-line", "XMP:Creator");
                NakeTemplateTextBox(txtCategory, metadata, "IPTC:Category");
                NakeTemplateTextBox(txtSupplementalCategories, metadata, "IPTC:SupplementalCategories");
                MakeTemplateTextBox(txtCity, metadata, "IPTC:City", "XMP:City");
                MakeTemplateTextBox(txtProvince, metadata, "IPTC:Province-State", "XMP:State");
                MakeTemplateTextBox(txtCountry, metadata, "IPTC:Country-PrimaryLocationName", "XMP:Country");
                MakeTemplateTextBox(txtCountryCode, metadata, "IPTC:Country-PrimaryLocationCode", "XMP:CountryCode");
                MakeTemplateRating(metadata, "XMP:Rating");

                // Wczytaj listę słów kluczowych z przekazanych plików w podziale na:
                MakeKeywordsFromFiles(metadata);
            }

            // Przygotuj listę słów kluczowych dla wszystkich plików
            MakeFinalTemplateKeywordList();

            // Ustaw ostateczną wartość rating
            Rating = (int)cbRating.Tag;
        }

        private void NakeTemplateTextBox(TextBox textBox, Metadata metadata, string key)
        {
            MakeTemplateTextBox(textBox, metadata, key, string.Empty);
        }

        private void MakeTemplateTextBox(TextBox textBox, Metadata metadata, string key, string key2)
        {
            CheckBox checkBox = (CheckBox)findAssociatedCheckBox(textBox, "cb");
            checkBox.CheckState = CheckState.Indeterminate;
            if (textBox.Text != string.Empty)
            {
                textBox.Tag = string.Empty;
                return;
            }
            textBox.Enabled = false;
            if (metadata.MergedProperties.ContainsKey(key))
            {
                textBox.Text = metadata.MergedProperties[key];
                textBox.ForeColor = Color.Gray;
                textBox.Tag = textBox.Text;
            } 
            else if (key2 != string.Empty && metadata.MergedProperties.ContainsKey(key2))
            {
                textBox.Text = metadata.MergedProperties[key2];
                textBox.ForeColor = Color.Gray;
                textBox.Tag = textBox.Text;
            }
            textBox.Enabled = true;
        }

        private void MakeTemplateRating(Metadata metadata, string key)
        {
            int rating = metadata.Get(key, 0);
            
            // Ustawienie pierwszego wiersza
            if ((int)cbRating.Tag < 0)
            {
                cbRating.Tag = rating;
            }
            else
            {
                if ((int)cbRating.Tag != rating)
                {
                    cbRating.Tag = 0;
                    cbRating.CheckState = CheckState.Indeterminate;
                }
            }
        }

        /// <summary>
        /// Dodaj słowa kluczowe z IPTC pliku
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="first"></param>
        private void MakeKeywordsFromFiles(Metadata metadata)
        {
            // Pobierz listę słów kluczowych z IPTC
            List<string> keywords = metadata.GetList("IPTC:Keywords", ',');

            int counter;
            foreach (string keyword in keywords)
            {
                if (m_KeywordsInFiles.TryGetValue(keyword, out counter) )
                {
                    m_KeywordsInFiles[keyword] = m_KeywordsInFiles[keyword] + 1;
                }
                else
                {
                    m_KeywordsInFiles.Add(keyword, 1);
                }
            }
        }


        private void MakeFinalTemplateKeywordList()
        {
            // Pobierz zdefiniowane słowa kluczowe od razu do obiektu KeywordItem
            Dictionary<string, KeywordItem>.Enumerator settingsEnumerator = Settings.Keywords.GetEnumerator();
            while (settingsEnumerator.MoveNext())
            {

                DS.KeywordsRow row = settingsEnumerator.Current.Value.NewRow(ds);
                row.TAG = m_KeywordsInFiles.ContainsKey(settingsEnumerator.Current.Value.Keyword) && m_KeywordsInFiles[settingsEnumerator.Current.Value.Keyword] == Files.Count 
                    ? (int)CheckState.Checked : (int)CheckState.Indeterminate;
                ds.Keywords.Rows.Add(row);

                // Usuń ze słów kluczowych zebrtanych z pliku
                if (m_KeywordsInFiles.ContainsKey(settingsEnumerator.Current.Value.Keyword))
                {
                    m_KeywordsInFiles.Remove(settingsEnumerator.Current.Value.Keyword);
                }
            }

            // Dodaj pozostałe słowa z IPTC
            Dictionary<string, int>.Enumerator keywordsInFilesEnumerator = m_KeywordsInFiles.GetEnumerator();
            while (keywordsInFilesEnumerator.MoveNext())
            {
                KeywordItem item = new KeywordItem(string.Empty, keywordsInFilesEnumerator.Current.Key);
                DS.KeywordsRow row = item.NewRow(ds);
                row.TAG = m_KeywordsInFiles.ContainsKey(item.Keyword) && m_KeywordsInFiles[item.Keyword] == Files.Count
                    ? (int)CheckState.Checked : (int)CheckState.Indeterminate;
                ds.Keywords.Rows.Add(row);
            }

            MakeSections();
        }

        #endregion

        #region Make changes

        private void MakeChangesTextBox(TextBox textBox, Metadata metadata, string key)
        {
            MakeChangesTextBox(textBox, metadata, key, string.Empty);
        }

        private void MakeChangesTextBox(TextBox textBox, Metadata metadata, string key, string key2)
        {
            CheckBox checkBox = (CheckBox)findAssociatedCheckBox(textBox, "cb");
            switch (checkBox.CheckState)
            {
                case CheckState.Checked:
                    metadata.Set(key, textBox.Text);
                    metadata.Set(key2, textBox.Text);
                    break;
                case CheckState.Unchecked:
                    metadata.Set(key, string.Empty);
                    metadata.Set(key2, string.Empty);
                    break;
            }
        }

        private void MakeChangesRating(Metadata metadata)
        {
            switch (cbRating.CheckState)
            {
                case CheckState.Checked:
                    metadata.Set("XMP:Rating", Rating.ToString());
                    break;
                case CheckState.Unchecked:
                    metadata.Set("XMP:Rating", string.Empty);
                    break;
            }
        }

        /// <summary>
        /// Przygotowuje listę zmienionych słów kluczowych
        /// </summary>
        private void MakeChangedKeywords()
        {
            m_ChangedKeywords = new Dictionary<string, KeywordItem>();

            foreach (DS.KeywordsRow row in ds.Keywords)
            {
                if (!row.Keyword.StartsWith("."))
                {
                    KeywordItem keywordItem = new KeywordItem(row);
                    m_ChangedKeywords.Add(keywordItem.Keyword, keywordItem);
                }
            }
        }

        private void makeChangesKeywords(Metadata metadata)
        {
            // lista aktualnych słów kluczowych
            List<string> keywords = metadata.GetList("IPTC:Keywords", ',');
            bool changed = false;

            // Usunięcie słów kluczowych, które zostały zaznaczone do usunięcia
            for (int i = keywords.Count -1; i>= 0; i--)
            {
                string keyword = keywords[i];
                if (m_ChangedKeywords.ContainsKey(keyword))
                {
                    KeywordItem keywordItem = m_ChangedKeywords[keyword];
                    if (keywordItem.CheckState == CheckState.Unchecked)
                    {
                        keywords.RemoveAt(i);
                        changed = true;
                    }
                }
            }

            // Dodanie nowych słów kluczowych
            Dictionary<string, KeywordItem>.Enumerator en = m_ChangedKeywords.GetEnumerator();
            while(en.MoveNext())
            {
                if (en.Current.Value.CheckState == CheckState.Checked)
                {
                    if (keywords.IndexOf(en.Current.Value.Keyword) < 0)
                    {
                        keywords.Add(en.Current.Value.Keyword);
                        changed = true;
                    }
                }
            }

            if (changed)
            {
                metadata.SetList("IPTC:Keywords", keywords, ',');
            }
        }

        #endregion

        #region Context Menu

        private void miAddSettings_Click(object sender, EventArgs e)
        {
            
            if (gvKeywords.CurrentRow != null)
            {
                DS.KeywordsRow row = FormUtils.getRow<DS.KeywordsRow>(gvKeywords.CurrentRow.DataBoundItem);
                row.Template = true;
                KeywordItem item = new KeywordItem(row);
                Settings.Keywords.Add(item.Key, item);
            }
        }

        private void miRemoveSettings_Click(object sender, EventArgs e)
        {
            if (gvKeywords.CurrentRow != null)
            {
                DS.KeywordsRow row = FormUtils.getRow<DS.KeywordsRow>(gvKeywords.CurrentRow.DataBoundItem);
                row.Template = false;
                KeywordItem item = new KeywordItem(row);
                Settings.Keywords.Remove(item.Key);
            }
        }

        private void miAddKeyword_Click(object sender, EventArgs e)
        {
            KeywordItem sectionItem = new KeywordItem(string.Empty);
            if(gvKeywords.CurrentRow != null)
            {
                DS.KeywordsRow row = FormUtils.getRow<DS.KeywordsRow>(gvKeywords.CurrentRow.DataBoundItem);
                sectionItem = new KeywordItem(row.Section);
            }
            frmKeyword frmKeyword = new frmKeyword(sectionItem, true);
            frmKeyword.readSections(m_Sections);

            DialogResult r = frmKeyword.ShowDialog();
            if (r == DialogResult.OK)
            {
                DS.KeywordsRow row = ds.Keywords.FindByKeyword(frmKeyword.KeywordItem.Keyword);
                if (row == null)
                {
                    ds.Keywords.Rows.Add(frmKeyword.KeywordItem.NewRow(ds));
                }
            }
        }

        private void miChangeSection_Click(object sender, EventArgs e)
        {
            if (gvKeywords.CurrentRow != null)
            {
                DS.KeywordsRow row = FormUtils.getRow<DS.KeywordsRow>(gvKeywords.CurrentRow.DataBoundItem);
                if (row.Keyword.StartsWith("."))
                {
                    return;
                }

                KeywordItem item = new KeywordItem(row);
                frmKeyword frmKeyword = new frmKeyword(item, false);
                frmKeyword.readSections(m_Sections);
                
                DialogResult r = frmKeyword.ShowDialog();
                if (r == DialogResult.OK)
                {
                    row.Section = frmKeyword.KeywordItem.Section;
                    if (Settings.Keywords.ContainsKey(item.Keyword))
                    {
                        Settings.Keywords[item.Keyword] = item;
                    }
                }
            }
            
        }

        #endregion

        #region Obsługa listy

        private void MakeSections()
        {
            m_Sections = new HashSet<string>();

            // Utwórz listę/słownik sekcji
            foreach (DS.KeywordsRow keywordRow in ds.Keywords.Rows)
            {
                if (!m_Sections.Contains(keywordRow.Section))
                {
                    m_Sections.Add(keywordRow.Section);
                }
            }

            // Dodaj sekcje do listy
            HashSet<string>.Enumerator en = m_Sections.GetEnumerator();

            while(en.MoveNext())
            {
                KeywordItem sectionItem = new KeywordItem(en.Current);
                ds.Keywords.Rows.Add(sectionItem.NewRow(ds));
            }
        }

        #endregion

        #region Pola tekstowe i związane z nimi checkboxy

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            CheckBox checkBox = (CheckBox)findAssociatedCheckBox(textBox, "cb");
            textBox.ForeColor = Color.Black;
            
            if (textBox.Enabled && textBox.Text != string.Empty)
            {
                textBox.Tag = textBox.Text;
                checkBox.CheckState = CheckState.Checked;
            }
        }

        private void CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            TextBox textBox = (TextBox)findAssociatedCheckBox(checkBox, "txt");
            
            if (checkBox.CheckState == CheckState.Checked)
            {
                if (textBox.Text == string.Empty)
                {
                    textBox.Text = (string)textBox.Tag;
                }
                textBox.ForeColor = Color.Black;
            }
            else if (checkBox.CheckState == CheckState.Unchecked)
            {
                textBox.Tag = textBox.Text;
                textBox.Text = string.Empty;
            }
            else if (checkBox.CheckState == CheckState.Indeterminate)
            {
                textBox.ForeColor = Color.Gray;
            }
        }

        private Control findAssociatedCheckBox(Control control, string prefix)
        {
            int firstUpperIndex = 0;
            for (firstUpperIndex = 0; firstUpperIndex < control.Name.Length; firstUpperIndex++)
            {
                if (char.IsUpper(control.Name[firstUpperIndex]))
                {
                    break;
                }
            }
            string cbname = prefix + control.Name.Substring(firstUpperIndex);
            return Controls.Find(cbname, false)[0];
        }

        #endregion

        #region Rating

        private void cbRating_MouseClick(object sender, MouseEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            
            // Ustaw zaznaczenie bieżącej gwiazdki
            bool status = !radioButton.Checked;
            int rating = Convert.ToInt32(radioButton.Name.Substring(radioButton.Name.Length - 1, 1));

            // Zmień zaznaczenia wcześniejszych
            for (int i = 1; i <= 5; i++)
            {
                RadioButton sub = (RadioButton)Controls.Find(radioButton.Name.Substring(0, radioButton.Name.Length - 1) + i.ToString(), false)[0];
                sub.Checked = status && i <= rating;
            }
            cbRating.CheckState = Rating > 0 ? CheckState.Checked : CheckState.Unchecked;
        }

        private void cbRating_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            radioButton.Image = radioButton.Checked ? Properties.Resources.star_filled_16 : Properties.Resources.start_empty_16;
        }

        #endregion

        #region gvKeywords

        private void gvKeywords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvKeywords.Enabled)
            {
                gvKeywords.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void gvKeywords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                
                DS.KeywordsRow row = FormUtils.getRow<DS.KeywordsRow>(gvKeywords.Rows[e.RowIndex].DataBoundItem);
                if (row.Keyword.StartsWith("."))
                {
                    gvKeywords.Rows[e.RowIndex].DefaultCellStyle = m_KeywordSectionHeaderStyle;
                }
                //else if (gvKeywords.CurrentRow.Index == e.RowIndex)
                //{
                //    gvKeywords.Rows[e.RowIndex].DefaultCellStyle = m_KeywordCurrentStyle;
                //}
                else if (row.Template)
                {
                    gvKeywords.Rows[e.RowIndex].DefaultCellStyle = m_KeywordTemplateStyle;
                }
                else
                {
                    gvKeywords.Rows[e.RowIndex].DefaultCellStyle = m_KeywordRegularStyle;
                }
            }
        }

        private void gvKeywords_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gvKeywords.Enabled && m_ClickFlag)
            {
                m_ClickFlag = false;
                gvKeywords.EndEdit();
            }
        }

        private void gvKeywords_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DS.KeywordsRow row = FormUtils.getRow<DS.KeywordsRow>(gvKeywords.Rows[e.RowIndex].DataBoundItem);
                if (row.Keyword.StartsWith("."))
                {
                    e.PaintBackground(e.ClipBounds, true);
                    e.Handled = true;
                }
            }
        }

        private void gvKeywords_Resize(object sender, EventArgs e)
        {
            gvKeywords.Columns[1].Width = gvKeywords.Width - gvKeywords.Columns[0].Width - 20;
        }

        private void gvKeywords_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gvKeywords.CurrentCell = gvKeywords.Rows[e.RowIndex].Cells[0];
            }
        }

        #endregion

    }
}
