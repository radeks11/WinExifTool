using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinExifTool.Utils;

namespace WinExifTool.WorkTasks.Controls
{
    public partial class ControlPatternEdit : Form
    {

        public ControlPatternEdit()
        {
            InitializeComponent();
        }

        private void frmPatterns_Load(object sender, EventArgs e)
        {
            HashSet<string>.Enumerator en = Settings.Patterns.GetEnumerator();
            editPatterns.Items.Clear();
            while (en.MoveNext())
            {
                editPatterns.Items.Add(en.Current);
            }
        }

        private void editPatterns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // Usuń elementy z Hashset
                foreach (string item in editPatterns.SelectedItems)
                {
                    Settings.Patterns.Remove(item);
                }

                // Załaduj ponownie listę
                frmPatterns_Load(null, null);
            }
        }
    }
}
