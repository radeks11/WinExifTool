using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinExifTool.WorkTasks.Controls
{
    public partial class ControlCodepage : UserControl
    {
        public ControlCodepage()
        {
            InitializeComponent();
        }

        private void ControlCodepage_Load(object sender, EventArgs e)
        {
            // Ustawianie list
            editFrom.DataSource = Utils.Charset.Select();
            editFrom.ValueMember = "Codepage";
            editFrom.DisplayMember = "Name";
            editFrom.SelectedIndex = Properties.Settings.Default.WorkClassCodepage_editFrom;
            editTo.DataSource = Utils.Charset.Select();
            editTo.ValueMember = "Codepage";
            editTo.DisplayMember = "Name";
            editTo.SelectedIndex = Properties.Settings.Default.WorkClassCodepage_editTo;
        }
    }
}
