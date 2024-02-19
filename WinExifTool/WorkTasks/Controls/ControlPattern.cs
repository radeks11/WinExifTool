using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using WinExifTool.Utils;

namespace WinExifTool.WorkTasks.Controls
{
    public partial class ControlPattern : UserControl
    {

        public ControlPattern()
        {
            InitializeComponent();
        }

        private void ReadSettings()
        {
           // Ustaw listę masek 
            editPattern.Text = string.Empty;
            editPattern.Items.Clear();
            HashSet<string>.Enumerator en = Settings.Patterns.GetEnumerator();
            while (en.MoveNext())
            {
                // Jako domyślny wzór ustaw pierwszą maskę
                if (editPattern.Text == string.Empty)
                {
                    editPattern.Text = en.Current;
                }

                // dodaj maskę do listy wyboru
                editPattern.Items.Add(en.Current);
            }
        }

        public void SaveSettings(string pattern)
        {
            // Dodaj wzór
            if (!string.IsNullOrEmpty(pattern))
            {
                Settings.Patterns.Add(editPattern.Text);
            }
        }

        private void editModifyPatterns_Click(object sender, EventArgs e)
        {
            ControlPatternEdit changePatterns = new ControlPatternEdit();
            DialogResult result = changePatterns.ShowDialog();
            if (result == DialogResult.OK)
            {
                ReadSettings();

            }
        }

        private void ControlPattern_Load(object sender, EventArgs e)
        {
            ReadSettings();
        }
    }
}
