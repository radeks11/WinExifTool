using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WinExifTool.Utils;

namespace WinExifTool
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConfig_Load(object sender, EventArgs e)
        {
            // Path to exiftool.exe
            editExifToolPath.Text = Properties.Settings.Default.exiftool;

            // Wybór języka
            editLanguage.DataSource = Languages.Select();
            editLanguage.ValueMember = "Key";
            editLanguage.DisplayMember = "Description";

            string lang = Properties.Settings.Default.lang;
            if (lang != string.Empty)
            {
                editLanguage.SelectedValue = lang;
            }

            // Rozszerzenia
            editExtensions.Text = Settings.SerializeList(Settings.Extensions, "|", string.Empty);
            
            // Klucz API
            editGOOGLEAPIKEY.Text = Properties.Settings.Default.GOOGLE_APIKEY;

            // Map provider
            editMapProvider.SelectedItem = Properties.Settings.Default.MapProvider;

            // Wersja
            lblDownload.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Select exiftool path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (editExifToolPath.Text != string.Empty)
            {
                openFileExifToolDialog.InitialDirectory = System.IO.Path.GetDirectoryName(editExifToolPath.Text);
            }

            DialogResult result = openFileExifToolDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                editExifToolPath.Text = openFileExifToolDialog.FileName;
            }
        }

        /// <summary>
        /// Save and close config window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (editExifToolPath.Text != string.Empty)
            {
                string path = editExifToolPath.Text;
                if (System.IO.File.Exists(path))
                {
                    Properties.Settings.Default.exiftool = path;
                }
            }
            else
            {
                MessageBox.Show("Ścieżka do pliku ExifTool nie została określona");
                status = false;
            }

            ListItem selectedItem = (ListItem)editLanguage.SelectedItem;
            if (selectedItem != null)
            {
                Properties.Settings.Default.lang = selectedItem.Key;
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(selectedItem.Key);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(selectedItem.Key);
            }

            Settings.Extensions = Settings.DeserializeList(editExtensions.Text);
            Properties.Settings.Default.GOOGLE_APIKEY = editGOOGLEAPIKEY.Text;
            if (editMapProvider.SelectedIndex >= 0)
            {
                Properties.Settings.Default.MapProvider = editMapProvider.SelectedItem.ToString();
            }
            
            if (status)
            {
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void lblExifToolDownload_Click(object sender, EventArgs e)
        {
            string url = @"https://exiftool.org/";
            System.Diagnostics.Process.Start(url);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();   
        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Log.LogFullPath);
        }

        private void btnShowExecFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ExifTool.GetExecuteLogFolder());
        }

        private void lblGenerateGOOGLEAPIKEY_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://developers.google.com/maps/documentation/embed/get-api-key");
        }

        private void lblDownload_Click(object sender, EventArgs e)
        {
            // TODO:
            // Strona programu
        }

        private void lblExifToolTUF8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://stackoverflow.com/questions/57131654/using-utf-8-encoding-chcp-65001-in-command-prompt-windows-powershell-window/57134096#57134096");
        }
    }
}
