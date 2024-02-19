using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinExifTool.Utils;

namespace WinExifTool
{
    public partial class frmKeyword : Form
    {
        private KeywordItem m_KeywordItem;
        private string[] m_Sections;

        /// <summary>
        /// KeywordItem 
        /// </summary>
        public KeywordItem KeywordItem
        {
            get { return m_KeywordItem; }
            set { m_KeywordItem = value; }
        }

        /// <summary>
        /// Sections 
        /// </summary>
        public string[] Sections
        {
            get { return m_Sections; }
            set { m_Sections = value; }
        }

        public void readSections(HashSet<string> sections)
        {
            m_Sections = new string[sections.Count];
            sections.CopyTo(m_Sections);
        }

        public frmKeyword(KeywordItem item, bool allowEditKeyword)
        {
            InitializeComponent();
            m_KeywordItem = item;
            txtKeyword.Enabled = allowEditKeyword;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Enabled && txtKeyword.Text == string.Empty)
            {
                return;
            }
            m_KeywordItem.Section = cbSection.Text;
            m_KeywordItem.Keyword = txtKeyword.Text;
            m_KeywordItem.CheckState = CheckState.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmIPTCKeyword_Load(object sender, EventArgs e)
        {
            cbSection.Items.AddRange(Sections);
            cbSection.SelectedItem = m_KeywordItem.Section;
            txtKeyword.Text = m_KeywordItem.Keyword;
        }
    }
}
