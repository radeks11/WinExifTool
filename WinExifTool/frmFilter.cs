using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinExifTool
{
    public partial class frmFilter : Form
    {
        private DS.FilesDataTable m_Files;
        private frmMain m_MainForm;
        private bool m_ClickFlag = false;

        /// <summary>
        /// Files 
        /// </summary>
        public DS.FilesDataTable Files
        {
            get { return m_Files; }
            set
            {
                m_Files = value;
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

        public frmFilter()
        {
            InitializeComponent();
        }

        public void BuildItemList()
        {
            gvFilter.Enabled = false;
            AddItem("Rok", "", "Rok");
            AddItem("Rok", "2022", "    2022");
            AddItem("Rok", "2023", "    2023");
            AddItem("Rating", "", "Rating");
            AddItem("Rating", "1", "    1");
            AddItem("Rating", "3", "    3");
            AddItem("Rating", "5", "    5");
            AddItem("Keywords", "", "Keywords");
            AddItem("Keywords", "1", "    1");
            AddItem("Keywords", "3", "    3");
            AddItem("Keywords", "5", "    5");
            gvFilter.Enabled = true;
        }

        private void AddItem(string key, string value, string caption)
        {
            DS.FilterRow row = ds.Filter.NewFilterRow();
            row.Key = key;
            row.Value = value;
            row.Caption = caption;
            row.Header = value == string.Empty;
            row.test = (int)CheckState.Indeterminate;
            ds.Filter.Rows.Add(row);
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            
        }

        private void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DS.FilterRow row = Utils.FormUtils.getRow<DS.FilterRow>(gvFilter.Rows[e.RowIndex].DataBoundItem);
                if (row.Header)
                {
                    gvFilter.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                    gvFilter.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.LightGray;
                    gvFilter.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    gvFilter.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                    gvFilter.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                }
                else if (row.TAG)
                {
                    gvFilter.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                }
                else
                {
                    gvFilter.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Regular);
                }
            }
        }

        private void gvFilter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            m_ClickFlag = true;
            if (gvFilter.Enabled)
            {
                gvFilter.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void gvFilter_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (gvFilter.Enabled && m_ClickFlag)
            {
                m_ClickFlag = false;
                gvFilter.EndEdit();
                ApplyFilter();
            }
        }

        private void ApplyFilter()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CreateDate >= #2023-08-27 15:20:00#");
            m_MainForm.ApplyFilter (sb.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DS.FilterRow filterRow in ds.Filter.Rows)
            {
                Debug.Print("{0}", filterRow.test);
            }
        }
    }
}
