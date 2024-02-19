using System.Collections.Generic;
using System.Windows.Forms;

namespace WinExifTool.WorkTasks
{
    /// <summary>
    /// Convert codepage task
    /// </summary>
    class WorkClassCodepage : WorkTask
    {

        private Utils.Charset m_From;
        private Utils.Charset m_To;

        /// <summary>
        /// Class description
        /// </summary>
        public override string Description
        {
            get { return Properties.Lang.WorkClassCodepage_description; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkClassCodepage()
        {
            Control = new Controls.ControlCodepage();
        }

        /// <summary>
        /// Read settings
        /// </summary>
        public override bool ReadSettings()
        {
            Controls.ControlCodepage control = (Controls.ControlCodepage)Control;

            if (control.editFrom.SelectedIndex < 0 || control.editTo.SelectedIndex < 0 )
            {
                MessageBox.Show("");
                return false;
            }

            if (control.editFrom.SelectedIndex == control.editTo.SelectedIndex)
            {
                MessageBox.Show("");
                return false;
            }

            m_From = new Utils.Charset((int)control.editFrom.SelectedValue);
            m_To = new Utils.Charset((int)control.editTo.SelectedValue);

            Properties.Settings.Default.WorkClassCodepage_editFrom = control.editFrom.SelectedIndex;
            Properties.Settings.Default.WorkClassCodepage_editTo = control.editTo.SelectedIndex;
            return true;
        }

        /// <summary>
        /// Do the job
        /// </summary>
        public override void Make()
        {
            DialogResult r = MessageBox.Show(Properties.Lang.WorkClassCodepage_warning, Properties.Lang.WorkClassCodepage_caption, MessageBoxButtons.YesNo,  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (r == DialogResult.Yes)
            {
                MakeBatch();
            }
        }

        /// <summary>
        /// Do the job in batch
        /// </summary>
        /// <returns></returns>
        public bool MakeBatch()
        {
            // Generuj pogrupowaną listę plików
            List<List<string>> groups = m_ExifTool.GroupFileList(Files);
            foreach (List<string> group in groups)
            {
                m_ExifTool.AddArgs(group);
                m_ExifTool.AddArgs("-m");
                m_ExifTool.AddArgs("-overwrite_original");
                m_ExifTool.AddArgs("-charset", m_From);
                m_ExifTool.AddArgs(m_From.ToString());
                m_ExifTool.AddArgs("-codedcharacterset={0}", m_To);
                m_ExifTool.AddArgs("-execute");
                m_ExifTool.Exec(true);
                // m_ExifTool.Exec("-m -overwrite_original -iptc:all -charset iptc=latin2 -codedcharacterset=utf8", true); ;
            }

            return true;
        }

    }
}
