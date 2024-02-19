using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinExifTool.Utils;

namespace WinExifTool
{
    public partial class frmTools : Form
    {
        private WorkTasks.WorkTask m_Task = null;
        private List<DS.FilesRow> m_Files;
        private frmMain m_MainForm;

        /// <summary>
        /// Files 
        /// </summary>
        public List<DS.FilesRow> Files
        {
            get { return m_Files; }
            set
            {
                m_Files = value;
                tsFileCount.Text = string.Format("Ilość plików: {0}", Files.Count);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        public frmTools(WorkTasks.WorkTask task)
        {
            InitializeComponent();
            m_Task = task;
        }

        private void frmTools_Load(object sender, EventArgs e)
        {
            ControlPanel.Controls.Clear();
            if (m_Task.Control != null)
            {
                ControlPanel.Controls.Add(m_Task.Control);
            }
            this.Text = m_Task.Description;
        }

        private void frmTools_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_MainForm.ToolsForm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Clear status message 
            tsMessage.Text = string.Empty;

            // assign list of files to work
            m_Task.Files = Files;

            // Read settings and check if everything is correct 
            if (!m_Task.ReadSettings())
            {
                return;
            }

            // Do the job
            m_Task.Make();

            // Refresh file info
            m_MainForm.TagChanged();

            // Close form
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
