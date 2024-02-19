using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinExifTool.WorkTasks.Controls
{
    public partial class ControlMetadata : UserControl
    {
        public ControlMetadata()
        {
            InitializeComponent();
        }

        private void ControlMetadataCopy_Load(object sender, EventArgs e)
        {
            // Ustawianie list
            editFrom1.DataSource = Utils.PropertyItem.Select();
            editFrom1.ValueMember = "Key";
            editFrom1.DisplayMember = "Key";
            editFrom1.SelectedIndex = Properties.Settings.Default.WorkClassMetadata_editFrom1;
            editTo1.DataSource = Utils.PropertyItem.Select();
            editTo1.ValueMember = "Key";
            editTo1.DisplayMember = "Key";
            editTo1.SelectedIndex = Properties.Settings.Default.WorkClassMetadata_editTo1;
            cb1.Checked = Properties.Settings.Default.WorkClassMetadata_cb1;

            editFrom2.DataSource = Utils.PropertyItem.Select();
            editFrom2.ValueMember = "Key";
            editFrom2.DisplayMember = "Key";
            editFrom2.SelectedIndex = Properties.Settings.Default.WorkClassMetadata_editFrom2;
            editTo2.DataSource = Utils.PropertyItem.Select();
            editTo2.ValueMember = "Key";
            editTo2.DisplayMember = "Key";
            editTo2.SelectedIndex = Properties.Settings.Default.WorkClassMetadata_editTo2;
            cb2.Checked = Properties.Settings.Default.WorkClassMetadata_cb2;

            editFrom3.DataSource = Utils.PropertyItem.Select();
            editFrom3.ValueMember = "Key";
            editFrom3.DisplayMember = "Key";
            editFrom3.SelectedIndex = Properties.Settings.Default.WorkClassMetadata_editFrom3;
            editTo3.DataSource = Utils.PropertyItem.Select();
            editTo3.ValueMember = "Key";
            editTo3.DisplayMember = "Key";
            editTo3.SelectedIndex = Properties.Settings.Default.WorkClassMetadata_editTo3;
            cb3.Checked = Properties.Settings.Default.WorkClassMetadata_cb3;

            editFrom4.DataSource = Utils.PropertyItem.Select();
            editFrom4.ValueMember = "Key";
            editFrom4.DisplayMember = "Key";
            editFrom4.SelectedIndex = Properties.Settings.Default.WorkClassMetadata_editFrom4;
            editTo4.DataSource = Utils.PropertyItem.Select();
            editTo4.ValueMember = "Key";
            editTo4.DisplayMember = "Key";
            editTo4.SelectedIndex = Properties.Settings.Default.WorkClassMetadata_editTo4;
            cb4.Checked = Properties.Settings.Default.WorkClassMetadata_cb4;
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            checkBox.Text = checkBox.Checked ? "Kopiowanie" : "Przenoszenie";
        }
    }
}
