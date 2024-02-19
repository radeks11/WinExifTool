using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinExifTool.Utils;

namespace WinExifTool.WorkTasks
{
    /// <summary>
    /// Task to move or copy metadata between IPTC/XMP fields
    /// </summary>
    class WorkClassMetadata : WorkTask
    {
        /// <summary>
        /// Operation item structore
        /// </summary>
        protected struct OperationItem
        {
            /// <summary>
            /// Field to move/copy data from
            /// </summary>
            public string From;

            /// <summary>
            /// Field to move/copy data to
            /// </summary>
            public string To;

            /// <summary>
            /// Do the copy instead of move
            /// </summary>
            public bool Copy;

            /// <summary>
            /// Construcotr
            /// </summary>
            /// <param name="from">Field to move/copy data from</param>
            /// <param name="to">Field to move/copy data to</param>
            /// <param name="copy">Do the copy instead of move</param>
            public OperationItem(string from, string to, bool copy)
            {
                this.From = from;
                this.To = to;
                this.Copy = copy;
            }
        }

        /// <summary>
        /// List of operations
        /// </summary>
        private List<OperationItem> m_Operations = new List<OperationItem>();

        /// <summary>
        /// Class description
        /// </summary>
        public override string Description 
        {
            get { return Properties.Lang.WorkClassMetadata_description; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkClassMetadata()
        {
            Control = new Controls.ControlMetadata();    
        }

        /// <summary>
        /// Read and check settings
        /// </summary>
        /// <returns></returns>
        public override bool ReadSettings()
        {
            Controls.ControlMetadata control = (Controls.ControlMetadata)Control;
            AddOperation(control.editFrom1, control.editTo1, control.cb1);
            AddOperation(control.editFrom2, control.editTo2, control.cb2);
            AddOperation(control.editFrom3, control.editTo3, control.cb3);
            AddOperation(control.editFrom4, control.editTo4, control.cb4);

            if (m_Operations.Count == 0)
            {
                MessageBox.Show("");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Add operation
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cb"></param>
        protected void AddOperation(ComboBox from, ComboBox to, CheckBox cb)
        {
            if (from.SelectedIndex >= 0 && to.SelectedIndex >= 0)
            {
                OperationItem item = new OperationItem(((PropertyItem)from.SelectedItem).Key, ((PropertyItem)to.SelectedItem).Key, cb.Checked);
                m_Operations.Add(item);

                Properties.Settings.Default["WorkClassMetadata_" + from.Name] = from.SelectedIndex;
                Properties.Settings.Default["WorkClassMetadata_" + to.Name] = to.SelectedIndex;
                Properties.Settings.Default["WorkClassMetadata_" + cb.Name] = cb.Checked;
            }
        }

        /// <summary>
        /// Do the job
        /// </summary>
        public override void Make()
        {
            foreach (DS.FilesRow row in Files)
            {
                // get metadata
                Metadata metadata = new Metadata(row);

                foreach (OperationItem item in m_Operations)
                {
                    string fromValue = metadata.Get(item.From);
                    if (fromValue != string.Empty)
                    {
                        metadata.Set(item.To, fromValue);
                    }

                    // Jeżeli przenosimy zamiast kopiować to trzeba wyczyścić oryginalne pole
                    if (!item.Copy)
                    {
                        metadata.Set(item.From, string.Empty);
                    }
                }
                metadata.BuildFilesRow();
            }
        }
    }
}
