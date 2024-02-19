using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinExifTool.WorkTasks.Controls
{
    public partial class ControlFixedDate : UserControl
    {
        public ControlFixedDate()
        {
            InitializeComponent();
        }

        private void ControlFixedDate_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.WorkClassFixedDate_Date != null && Properties.Settings.Default.WorkClassFixedDate_Date.Year > 1900)
            {
                editStartDate.Value = Properties.Settings.Default.WorkClassFixedDate_Date;
                editStartTime.Value = Properties.Settings.Default.WorkClassFixedDate_Date;
                editShift.Value = Properties.Settings.Default.WorkClassFixedDate_Shift;
                editShift.Checked = Properties.Settings.Default.WorkClassFixedDate_ShiftChecked;
                editWriteExif.Checked = Properties.Settings.Default.WorkClassFixedDate_Exif;
            }
        }
    }
}
