using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using WinExifTool.Utils;

namespace WinExifTool
{
    public partial class frmMain : Form
    {
        #region Zmienne prywatne

        private ExifTool m_ExifTool;
        private Queue<string> m_ReadProperties = new Queue<string>();
        private Object m_ReadExifToolPropertiesLock = new object();
        private Object m_ShowRowPropertiesLock = new object();
        private bool m_gvPropertiesFlag = false;
        private frmMap m_MapForm;
        private frmPreview m_PreviewForm;
        private frmMetadata m_MetadataForm;
        private frmTools m_ToolsForm;
        private frmFilter m_FilterForm;
        private bool m_TagChanged;
        private List<DS.FilesRow> m_TaggedFiles;

        #endregion

        #region Właściwości

        /// <summary>
        /// Map form 
        /// </summary>
        public frmMap MapForm
        {
            get { return m_MapForm; }
            set { m_MapForm = value; }
        }

        /// <summary>
        /// Preview form
        /// </summary>
        public frmPreview PreviewForm
        {
            get { return m_PreviewForm; }
            set { m_PreviewForm = value; }
        }

        /// <summary>
        /// Edit form
        /// </summary>
        public frmMetadata MetadataForm
        {
            get { return m_MetadataForm; }
            set { m_MetadataForm = value; }
        }

        /// <summary>
        /// Tools form
        /// </summary>
        public frmTools ToolsForm
        {
            get { return m_ToolsForm; }
            set { m_ToolsForm = value; }
        }

        /// <summary>
        /// FilterForm 
        /// </summary>
        public frmFilter FilterForm
        {
            get { return m_FilterForm; }
            set { m_FilterForm = value; }
        }

        /// <summary>
        /// TaggedFiles 
        /// </summary>
        public List<DS.FilesRow> TaggedFiles
        {
            get {

                if (m_TaggedFiles == null || m_TagChanged)
                {
                    tsSave.Enabled = false;

                    m_TaggedFiles = new List<DS.FilesRow>();
                    try
                    {
                        foreach (DS.FilesRow row in ds.Files)
                        {
                            if (row.TAG)
                            {
                                m_TaggedFiles.Add(row);
                            }

                            if (!row.IsChangesNull())
                            {
                                tsSave.Enabled = true;
                            }
                        }
                    }
                    catch { }
                    m_TagChanged = false;
                }
                return m_TaggedFiles;
            }
        }

        /// <summary>
        /// Current record
        /// </summary>
        public DS.FilesRow CurrentRow
        {
            get
            {
                if (gvFiles.CurrentRow == null)
                {
                    return null;
                }

                return FormUtils.getRow<DS.FilesRow>(gvFiles.CurrentRow.DataBoundItem);
            }
        }

        /// <summary>
        /// Get list of records to edit. 
        /// This method can be called before CurrentRow of gvFiles property is properly set the current row can be pass as a parameter
        /// </summary>
        /// <param name="currentRow">Incoming CurrentRow</param>
        /// <returns>List of records to edit</returns>
        private List<DS.FilesRow> GetFileList(DS.FilesRow currentRow)
        {
            if (TaggedFiles.Count > 0)
            {
                return TaggedFiles;
            }
            else
            {
                List<DS.FilesRow> list = new List<DS.FilesRow>();
                if (currentRow != null)
                {
                    list.Add(currentRow);
                }
                else if (CurrentRow != null)
                {
                    list.Add(CurrentRow);
                }
                return list;
            }
        }

        /// <summary>
        /// Number of changed records
        /// </summary>
        public int RowChangedCount
        {
            get
            {
                int changed = 0;
                foreach (DS.FilesRow row in ds.Files)
                {
                    if (!row.IsChangesNull())
                    {
                        changed++;
                    }
                }
                return changed;
            }
        }

        /// <summary>
        /// Check the background services are still running
        /// </summary>
        private bool BackgroundTasksActive
        {
            get { return bwWriteChanges.IsBusy || bwLoadProperties.IsBusy; }
        }

        #endregion

        #region Konstruktor i load

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args">List of files passed by the command line</param>
        public frmMain(string[] args)
        {
            InitializeComponent();

            // Settings class deserialize lists stored in settings. 
            if (!Settings.ReadSettings())
            {
                Environment.Exit(1);
            }

            // Main ExifTool object
            m_ExifTool = new ExifTool();

            // Read files from command line
            LoadFilesOrFolders(args);

            // Load properties of readed files
            bwLoadProperties_Start();
        }

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Load form settings from Properties.Settings
            LoadSettings();

            // Load list of tools as 
            LoadTools();

            // Force properties checked to filter out properties 
            gvProperties_CheckedChanged(null, null);

            // Force resize method on gvPropeperties to expand right column
            gvProperties_Resize(null, null);

            // Add columns to context menu
            gvFiles_SetMenu();
        }

        /// <summary>
        /// Form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save form settings and 
            SaveSettings();
        }

        #endregion

        #region Toolbar Files

        /// <summary>
        /// Show open file dialog, load selected media files and read their properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsOpenFiles_Click(object sender, EventArgs e)
        {
            // ustawienie filtru dla wyboru tylko obsługiwanych zdjęć
            // Ma wyglądać tak:
            // Pliki medialne|*.jpg;*.png;*.bmp|Wszystkie pliki (*.*)|*.*
            dlgOpenFiles.Filter = "Pliki medialne|" + Settings.SerializeList(Settings.Extensions, ";", "*.") + "|Wszystkie pliki (*.*)|*.*";
            DialogResult dialogResult = dlgOpenFiles.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            foreach (string filepath in dlgOpenFiles.FileNames)
            {
                LoadFile(filepath);
            }
            bwLoadProperties_Start();
        }

        /// <summary>
        /// Remove all records from file list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsClear_Click(object sender, EventArgs e)
        {
            gvFiles.Enabled = false;
            ds.Files.Rows.Clear();
            ds.Properties.Rows.Clear();
            imagePreview.Image = null;
            bwLoadProperties.CancelAsync();
            gvFiles.Enabled = true;
            TagChanged();
        }

        /// <summary>
        /// Undo changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsUndo_Click(object sender, EventArgs e)
        {
            foreach (DS.FilesRow row in ds.Files)
            {
                Metadata metadata = new Metadata(row);
                metadata.ResetRow();
            }
        }

        /// <summary>
        /// Reread properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            foreach (DS.FilesRow row in ds.Files)
            {
                lock (m_ReadExifToolPropertiesLock)
                {
                    m_ReadProperties.Enqueue(row.FilePath);
                }
            }
            bwLoadProperties_Start();
        }

        /// <summary>
        /// Save changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsSave_Click(object sender, EventArgs e)
        {
            if (bwWriteChanges.IsBusy)
            {
                bwWriteChanges.CancelAsync();
            }
            else
            {
                bwWriteChanges_Start();
            }
        }

        #endregion

        #region Toolbar Tagging

        /// <summary>
        /// Set TAG to selected files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsSetTAG_Click(object sender, EventArgs e)
        {
            TagSelectedRows(true);
        }

        /// <summary>
        /// Remove TAG from selected files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsUnsetTAG_Click(object sender, EventArgs e)
        {
            TagSelectedRows(false);
        }

        /// <summary>
        /// Set TAG to all files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsSetAllTAG_Click(object sender, EventArgs e)
        {
            gvFiles.Enabled = false;
            TagAllRows(true);
            gvFiles.Enabled = true;
            TagChanged();
        }

        /// <summary>
        /// Remove TAG from all files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsClearAllTAG_Click(object sender, EventArgs e)
        {
            gvFiles.Enabled = false;
            TagAllRows(false);
            gvFiles.Enabled = true;
            TagChanged();
        }

        #endregion

        #region Toolbar Forms

        /// <summary>
        /// Show Filter form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsFilter_Click(object sender, EventArgs e)
        {
            if (BackgroundTasksActive)
            {
                MessageBox.Show("Zaczekaj na zakończenie poprzednich zadań");
                return;
            }

            if (m_FilterForm == null)
            {
                m_FilterForm = new frmFilter();
                m_FilterForm.MainForm = this;
            }

            m_FilterForm.Files = ds.Files;
            m_FilterForm.BuildItemList();
            m_FilterForm.Show();
        }

        /// <summary>
        /// Show Preview form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsPreview_Click(object sender, EventArgs e)
        {
            if (BackgroundTasksActive)
            {
                MessageBox.Show("Zaczekaj na zakończenie poprzednich zadań");
                return;
            }

            if (CurrentRow == null)
            {
                return;
            }

            if (m_PreviewForm == null)
            {
                m_PreviewForm = new frmPreview();
                m_PreviewForm.MainForm = this;
            }
            m_PreviewForm.setImage(imagePreview.Image);
            m_PreviewForm.Show();
        }

        /// <summary>
        /// Show Map form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMap_Click(object sender, EventArgs e)
        {
            if (BackgroundTasksActive)
            {
                MessageBox.Show("Zaczekaj na zakończenie poprzednich zadań");
                return;
            }

            if (m_MapForm == null)
            {
                m_MapForm = new frmMap();
                m_MapForm.MainForm = this;
            }
            m_MapForm.Files = GetFileList(null);
            m_MapForm.CurrentRow = FormUtils.getRow<DS.FilesRow>(gvFiles.CurrentRow.DataBoundItem);
            m_MapForm.Show();
        }

        /// <summary>
        /// Show Group Edit form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMetadata_Click(object sender, EventArgs e)
        {
            if (BackgroundTasksActive)
            {
                MessageBox.Show("Zaczekaj na zakończenie poprzednich zadań");
                return;
            }

            if (m_MetadataForm == null)
            {
                m_MetadataForm = new frmMetadata();
                m_MetadataForm.MainForm = this;
            }
            m_MetadataForm.Files = GetFileList(null);
            m_MetadataForm.Show();
        }

        #endregion

        #region Toolbar Tools

        /// <summary>
        /// Load list of tools to miTools dropdown
        /// </summary>
        private void LoadTools()
        {
            foreach (ListItem task in WorkTasks.WorkTask.Tasks)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = task.Description;
                mi.Tag = task;
                mi.Image = Properties.Resources.wrench_16;
                mi.Click += miTools_Click;
                miTools.DropDownItems.Add(mi);
            }
        }

        /// <summary>
        /// Common method of miTools subitems.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miTools_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            WorkTasks.WorkTask task = WorkTasks.WorkTask.GetInstance((ListItem)mi.Tag);
            m_ToolsForm = new frmTools(task);
            m_ToolsForm.MainForm = this;
            m_ToolsForm.Files = TaggedFiles;
            m_ToolsForm.Show();
        }

        #endregion

        #region Toolbar Config 

        /// <summary>
        /// Show Config form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsConfig_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.ShowDialog();
        }

        #endregion

        #region gvFiles

        /// <summary>
        /// Load dropped files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    LoadFilesOrFolders(files);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                finally
                {
                    bwLoadProperties_Start();
                }
            }
        }

        /// <summary>
        /// Change icon if files are about to drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        /// <summary>
        /// Show propertes after enter the file row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ShowRowProperties(FormUtils.getRow<DS.FilesRow>(gvFiles.Rows[e.RowIndex].DataBoundItem));
        }

        /// <summary>
        /// Refresh file info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TagChanged();
        }

        /// <summary>
        /// Open file in externat program after double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DS.FilesRow row = (DS.FilesRow)((DataRowView)gvFiles.Rows[e.RowIndex].DataBoundItem).Row;
            Process.Start(row.FilePath);
        }

        /// <summary>
        /// Proceed key shortcuts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                
                case Keys.T:
                case Keys.M:
                    if (e.Shift)
                    {
                        TagToCurrentRow(true);
                    }
                    else
                    {
                        TagSelectedRows(true);
                    }
                    break;
                case Keys.C:
                    if (e.Shift)
                    {
                        TagToCurrentRow(false);
                    }
                    else
                    {
                        TagSelectedRows(false);
                    }
                    break;
                case Keys.A:
                    TagAllRows(true);
                    break;
                case Keys.X:
                    TagAllRows(false);
                    break;
            }
        }

        /// <summary>
        /// Format cells of gvFiles
        /// Format is set to whole row. Setting cells individually caused inconsistency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // Get data row
                    DS.FilesRow row = FormUtils.getRow<DS.FilesRow>(gvFiles.Rows[e.RowIndex].DataBoundItem);
                    
                    // set BOLD if TAG is set
                    gvFiles.Rows[e.RowIndex].DefaultCellStyle.Font = row.TAG ? new Font(this.Font, FontStyle.Bold) : new Font(this.Font, FontStyle.Regular);

                    // set RED if CHANGES are made
                    gvFiles.Rows[e.RowIndex].DefaultCellStyle.ForeColor = row.IsChangesNull() ? Color.Black : Color.Red;
                }
            }
            catch (Exception ex)
            {
                Log.addLog(ex.Message);
            }
        }

        /// <summary>
        /// Add hidden/visible columns to gvFiles context menu
        /// </summary>
        private void gvFiles_SetMenu()
        {
            for (int i = 3; i < gvFiles.Columns.Count; i++)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = "gvFilesMenuItem_" + i.ToString();
                menuItem.Text = gvFiles.Columns[i].HeaderText;
                menuItem.Click += gvFilesMenuItem_Click;
                menuItem.Checked = gvFiles.Columns[i].Visible;
                gvFilesMenu.Items.Add(menuItem);
            }
        }

        /// <summary>
        /// Common method to catch click of changing visibility of columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFilesMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = !menuItem.Checked;
            int idx = menuItem.Name.IndexOf('_');
            int columnNumber = Convert.ToInt32(menuItem.Name.Substring(idx + 1));
            gvFiles.Columns[columnNumber].Visible = menuItem.Checked;
        }

        /// <summary>
        /// Auto end edit of row after TAG click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvFiles.Enabled)
            {
                gvFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Auto end edit of row after TAG click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gvFiles.Enabled)
            {
                gvFiles.EndEdit();
            }
        }

        #endregion

        #region gvProperties

        /// <summary>
        /// Capture changes of filter properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvProperties_CheckedChanged(object sender, EventArgs e)
        {
            // Flag to prevent stack overflow
            if (m_gvPropertiesFlag)
            {
                return;
            }

            // Remember state of flag
            bool status = m_gvPropertiesFlag;
            m_gvPropertiesFlag = true;
            
            if (sender != null)
            {
                // Set status of checkboxes
                gvProperties_Status((CheckBox)sender);
            }

            // Build filter
            BuildPropertiesFilter();

            // Restore state of flag
            m_gvPropertiesFlag = status;
        }

        /// <summary>
        /// Set check status of checkboxex
        /// Some can be checked together (EXIF, IPTC) but some has to be exclusive (Changes)
        /// </summary>
        /// <param name="checkBox"></param>
        private void gvProperties_Status(CheckBox checkBox)
        {
            
            if (checkBox.Name == "gvPropertiesMAIN" || checkBox.Name == "gvPropertiesCHANGED")
            {
                // odznaczenie wszystkich pozostałych, jeżeli kliknięty został main lub changed
                bool status = checkBox.Checked;
                gvPropertiesFILE.Checked = false;
                gvPropertiesIPTC.Checked = false;
                gvPropertiesEXIF.Checked = false;
                gvPropertiesXMP.Checked = false;
                gvPropertiesMAIN.Checked = false;
                gvPropertiesCHANGED.Checked = false;
                checkBox.Checked = status;
            }
            else
            {
                // odznaczenie MAIN lub CHANGED jeżeli została kliknięta sekcja
                if (checkBox.Checked)
                {
                    gvPropertiesMAIN.Checked = false;
                    gvPropertiesCHANGED.Checked = false;
                }
            }
        }

        /// <summary>
        /// Format cells of gvProperties
        /// Format is set to whole row. Setting cells individually caused inconsistency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvProperties_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Pobierz wiersz danych
                DS.PropertiesRow row = FormUtils.getRow<DS.PropertiesRow>(gvProperties.Rows[e.RowIndex].DataBoundItem);

                // Changed properties shoud be red
                e.CellStyle.ForeColor = row.Changed ? Color.Red : Color.Black;
            }
        }

        /// <summary>
        /// HitTest of right click to select proper row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvProperties_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo h = gvProperties.HitTest(e.X, e.Y);
                DataGridViewRow row = gvProperties.Rows[h.RowIndex];
                if (!row.Selected)
                {
                    gvProperties.ClearSelection();
                    row.Selected = true;
                }
            }
        }

        /// <summary>
        /// Set most right column width to fill out the space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvProperties_Resize(object sender, EventArgs e)
        {
            gvProperties.Columns[2].Width = gvProperties.Width - gvProperties.Columns[0].Width - gvProperties.Columns[1].Width - 20;
        }

        #endregion

        #region gvPropertiesMenu

        /// <summary>
        /// Set checked state of right clicked row. Rows set as MAIN PROPERTY shoudl be checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvPropertiesMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gvProperties.SelectedRows.Count == 0)
            {
                return;
            }

            DS.PropertiesRow propertiesRow = FormUtils.getRow<DS.PropertiesRow>(gvProperties.SelectedRows[0].DataBoundItem);
            miMain.Checked = Settings.ExistsMainProperty(propertiesRow);
        }

        /// <summary>
        /// Toggle check state of MAIN PROPERTY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miMain_Click(object sender, EventArgs e)
        {
            miMain.Checked = !miMain.Checked;
            if (gvProperties.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow gridViewRow in gvProperties.SelectedRows)
                {
                    DS.PropertiesRow propertiesRow = FormUtils.getRow<DS.PropertiesRow>(gridViewRow.DataBoundItem);
                    Settings.AddRemoveMainProperty(propertiesRow, miMain.Checked);
                }
            }

            BuildPropertiesFilter();
        }

        /// <summary>
        /// Exclude property. Excluded property will be filter out 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miExclude_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvProperties.SelectedRows)
            {
                DS.PropertiesRow propertyRow = (DS.PropertiesRow)((DataRowView)row.DataBoundItem).Row;
                Settings.AddExcludedProperty(propertyRow);
                gvProperties.Rows.Remove(row);
            }

            BuildPropertiesFilter();
        }

        /// <summary>
        /// Copy property to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCopy_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in gvProperties.SelectedRows)
            {
                DS.PropertiesRow propertyRow = FormUtils.getRow<DS.PropertiesRow>(row.DataBoundItem);
                sb.AppendFormat("{0}:{1}\t{2}\n", propertyRow.Section, propertyRow.Field, propertyRow.Value);
            }
            Clipboard.SetText(sb.ToString());
        } 

        /// <summary>
        /// Show properties for current row
        /// </summary>
        /// <param name="row"></param>
        private void ShowRowProperties(DS.FilesRow row)
        {
            try
            {
                // Jeżeli nie ma aktywego rekordu to czyścimy dane
                if (row == null)
                {
                    return;
                }

                lock (m_ShowRowPropertiesLock)
                {
                    imagePreview.Image = null;
                    Metadata metadata = new Metadata(row);
                    metadata.FillPropertiesTable(ds.Properties, !gvPropertiesMAIN.Checked);
                    // metadata.BuildFilesRow(row);
                    SetPreview(row);

                    if (m_MapForm != null)
                    {
                        m_MapForm.CurrentRow = row;
                        m_MapForm.Files = GetFileList(row);
                    }

                    if (m_MetadataForm != null)
                    {
                        m_MetadataForm.Files = GetFileList(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.addLog(ex.Message);
            }
        }

        /// <summary>
        /// Show preview of current row
        /// </summary>
        /// <param name="row"></param>
        public void SetPreview(DS.FilesRow row)
        {
            try
            {
                string extension = Path.GetExtension(row.FilePath).ToLower();
                if (extension == ".mov" || extension == ".mp4")
                {
                    return;
                }
                else
                {
                    FileStream fs = new FileStream(row.FilePath, FileMode.Open);
                    Bitmap bmp = new Bitmap(fs);
                    imagePreview.Image = (Bitmap)bmp.Clone();

                    if (m_PreviewForm != null)
                    {
                        m_PreviewForm.setImage((Bitmap)bmp.Clone());
                    }

                    fs.Close();
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log.addLog(ex.Message);
            }
        }

        /// <summary>
        /// Build properties filter
        /// </summary>
        private void BuildPropertiesFilter()
        {
            // Build filter
            StringBuilder filter = new StringBuilder();

            if (gvPropertiesCHANGED.Checked)
            {
                // Ustawienie,że tylko zmiany
                filter.Append("Changed = true");

            }
            else if (gvPropertiesMAIN.Checked)
            {
                // Uastawienie głównych kategorii
                filter.Append(Settings.MainPropertyFilter());
            }
            else
            {
                // Dodanie sekcji do filtru
                filter.Append(GetPropertyFilterSection(gvPropertiesFILE, filter.Length == 0 ? string.Empty : ", "));
                filter.Append(GetPropertyFilterSection(gvPropertiesIPTC, filter.Length == 0 ? string.Empty : ", "));
                filter.Append(GetPropertyFilterSection(gvPropertiesEXIF, filter.Length == 0 ? string.Empty : ", "));
                filter.Append(GetPropertyFilterSection(gvPropertiesXMP, filter.Length == 0 ? string.Empty : ", "));
                if (filter.Length > 0)
                {
                    filter.Insert(0, "Section in (");
                    filter.Append(")");
                }
            }

            // Przypisanie zbudowanego filtru do Binding Source
            bsProperties.Filter = filter.ToString();
        }

        /// <summary>
        /// Get filter text of property section
        /// </summary>
        /// <param name="checkBox"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        private string GetPropertyFilterSection(CheckBox checkBox, string delimiter)
        {
            if (checkBox.Checked)
            {
                return delimiter + "'" + checkBox.Tag + "'";
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region bwLoadProperties

        /// <summary>
        /// Start (if possible) reading properties as a background task
        /// </summary>
        private void bwLoadProperties_Start()
        {
            if (BackgroundTasksActive)
            {
                MessageBox.Show(Properties.Lang.task_still_running);
                return;
            }

            bwLoadProperties.RunWorkerAsync();
        }

        /// <summary>
        /// Loading properties.
        /// Files to load properties are split into groups to increase the performance and remain ability to display the progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwLoadProperties_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Local list of files
            List<string> paths = new List<string>();
            int batchCounter = 0;
            lock (m_ReadExifToolPropertiesLock)
            {
                while (m_ReadProperties.Count > 0)
                {
                    // Add path to local list and remove from queue
                    paths.Add(m_ReadProperties.Dequeue());
                    batchCounter++;

                    // If the number of files exceed m_ExifTool.BATCHSIZE or it's a last package start reading properties
                    if (m_ReadProperties.Count == 0 || batchCounter >= Properties.Settings.Default.BATCHSIZE)
                    {
                        // Read properties from ExifTool
                        List<Metadata> metadataList = m_ExifTool.ReadCSV(paths);
                        
                        // Set readed properties to files 
                        foreach (Metadata metadata in metadataList)
                        {
                            // After parsing CSV metadata are not assign to the row
                            // Find the row and assing them to metadata
                            metadata.Row = ds.Files.FindByFilePath(metadata.FilePath);

                            // Read dates of files from system not from ExifTool
                            metadata.ReadFileDates();

                            // Build the row
                            metadata.BuildFilesRow();

                            // Remove path from local list
                            paths.Remove(metadata.FilePath);
                        }

                        // Report progress
                        bwLoadProperties.ReportProgress(100 - (100 * m_ReadProperties.Count / ds.Files.Rows.Count), m_ExifTool.LastError);

                        // Add error to rows where matadata could not be able to read
                        foreach (string path in paths)
                        {
                            DS.FilesRow row = ds.Files.FindByFilePath(path);
                            if (row != null)
                            {
                                row.RowError = Properties.Lang.metadata_not_read;
                            }
                        }

                        // Reset local list
                        paths = new List<string>();
                        batchCounter = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Finish reading properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwLoadProperties_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            tsProgress.Value = 100;
            TagChanged();
            ShowRowProperties(CurrentRow);
            gvFiles.Invalidate();
            tsStatus.Invalidate();
        }

        /// <summary>
        /// Catch progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwLoadProperties_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                tsProgress.Value = e.ProgressPercentage;
                tsMessage.Text = e.UserState == null ? string.Empty : e.UserState.ToString();
            }
            catch { }
        }

        #endregion

        #region Files 

        /// <summary>
        /// Parse list of paths and recognize files and folders
        /// </summary>
        /// <param name="paths"></param>
        private void LoadFilesOrFolders(string[] paths)
        {
            if (m_MapForm != null)
            {
                m_MapForm.Close();
                m_MapForm = null;
            }

            foreach (string path in paths)
            {
                if (File.Exists(path))
                {
                    LoadFile(path);
                }
                else if (Directory.Exists(path))
                {
                    LoadDirectory(path);
                }
            }
        }

        /// <summary>
        /// Load whole directory
        /// </summary>
        /// <param name="path"></param>
        private void LoadDirectory(string path)
        {
            foreach (string filepath in Directory.EnumerateFiles(path))
            {
                LoadFile(filepath);
            }
        }

        /// <summary>
        /// Load single file
        /// </summary>
        /// <param name="filepath"></param>
        private void LoadFile(string filepath)
        {
            FileInfo file = new FileInfo(filepath);
            if (ds.Files.FindByFilePath(filepath) != null)
            {
                return;
            }

            string extension = Path.GetExtension(filepath);
            if (!Settings.IsKnownExtension(extension))
            {
                return;
            }

            DS.FilesRow row = ds.Files.NewFilesRow();
            row.FilePath = filepath;
            row.FileName = file.Name;
            row.FileOrgDate = file.LastWriteTime;
            row.CreateDate = file.LastWriteTime;
            ds.Files.Rows.Add(row);
            lock (m_ReadExifToolPropertiesLock)
            {
                m_ReadProperties.Enqueue(filepath);
            }
        }

        /// <summary>
        /// Select row by path
        /// </summary>
        /// <param name="path"></param>
        public void SelectRowByPath(string path)
        {
            foreach (DataGridViewRow gvrow in gvFiles.SelectedRows)
            {
                gvrow.Selected = false;
            }
            foreach (DataGridViewRow gvrow in gvFiles.Rows)
            {
                DS.FilesRow row = FormUtils.getRow<DS.FilesRow>(gvrow.DataBoundItem);
                if (row.FilePath == path)
                {
                    gvrow.Selected = true;
                    ShowRowProperties(row);
                    return;
                }
            }
        }

        #endregion

        #region Tagging

        /// <summary>
        /// Set or unset TAG to all rows
        /// </summary>
        /// <param name="tag"></param>
        private void TagAllRows(bool tag)
        {
            foreach (DS.FilesRow filesRow in ds.Files.Rows)
            {
                filesRow.TAG = tag;
            }
            TagChanged();
        }

        /// <summary>
        /// Set or unset TAG to selected rows
        /// </summary>
        /// <param name="tag"></param>
        private void TagSelectedRows(bool tag)
        {
            // Exif if no rows selected
            if (gvFiles.SelectedRows.Count == 0)
            {
                return;
            }

            // Set or unset TAG
            foreach (DataGridViewRow row in gvFiles.SelectedRows)
            {
                DS.FilesRow filesRow = FormUtils.getRow<DS.FilesRow>(row.DataBoundItem);
                filesRow.TAG = tag;
            }

            // if there was only one row selected move to the next row after tagging
            int idx = gvFiles.SelectedRows[0].Index;
            if (gvFiles.SelectedRows.Count == 1 && idx + 1 < gvFiles.Rows.Count)
            {
                gvFiles.Rows[idx].Selected = false;
                gvFiles.Rows[idx + 1].Selected = true;
                ShowRowProperties(FormUtils.getRow<DS.FilesRow>(gvFiles.Rows[idx + 1].DataBoundItem));
            }

            // Refresh files info
            TagChanged();
        }

        /// <summary>
        /// Set or unset TAG to range of files from last TAGGED to currently selected.
        /// </summary>
        /// <param name="tag"></param>
        private void TagToCurrentRow(bool tag)
        {
            // Jeżeli nie ma nic zaznaczonego to wyjdź
            if (gvFiles.SelectedRows.Count == 0)
            {
                return;
            }

            int lastIndex = gvFiles.CurrentRow.Index;

            for (int i = lastIndex; i >= 0; i--)
            {
                DataGridViewRow row = gvFiles.Rows[i];
                DS.FilesRow filesRow = FormUtils.getRow<DS.FilesRow>(row.DataBoundItem);
                if (filesRow.TAG)
                {
                    TagChanged();
                    return;
                }
                filesRow.TAG = tag;
            }

            TagChanged();
        }

        /// <summary>
        /// Refresh file info
        /// </summary>
        public void TagChanged()
        {
            if (gvFiles.Enabled)
            {
                m_TagChanged = true;
                tsFileCount.Text = string.Format(Properties.Lang.tagged_files, TaggedFiles.Count, ds.Files.Rows.Count);

                if (m_MetadataForm != null)
                {
                    m_MetadataForm.Files = GetFileList(null); 
                }

                if (m_MapForm != null)
                {
                    m_MapForm.Files = GetFileList(null);
                }

                if (m_ToolsForm != null)
                {
                    m_ToolsForm.Files = GetFileList(null);
                }
            }
        }

        #endregion

        #region bwWriteChanges

        /// <summary>
        /// Start write changes
        /// </summary>
        private void bwWriteChanges_Start()
        {
            // Check if background task is able to start
            if (BackgroundTasksActive)
            {
                MessageBox.Show(Properties.Lang.task_still_running);
                return;
            }
            tsProgress.Value = 0;
            tsSave.Image = Properties.Resources.stop_red_24;
            bwWriteChanges.RunWorkerAsync();
        }

        /// <summary>
        /// Write changes to files.
        /// Files are splitted into groups to increase performance and display progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwWriteChanges_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int rowChangedCount = RowChangedCount;
            int changed = 0;
            int batchCounter = 0;

            foreach (DS.FilesRow row in ds.Files)
            {
                if (!row.IsChangesNull())
                {
                    // Allow cancel task
                    if (bwWriteChanges.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        // Add changes to ARGS file
                        Metadata metadata = new Metadata(row);
                        if (metadata.HasMetadataChanges)
                        {
                            m_ExifTool.AddArgs(metadata);
                        }

                        // Add file to list to change file date of creation and modification
                        m_ExifTool.AddFileDate(metadata.FilePath, metadata.ChangedFileDate);

                        // Clear changes
                        row.SetChangesNull();

                        // If batchCounter exceeded BATCHSIZE execute the changes
                        if (batchCounter >= Properties.Settings.Default.BATCHSIZE)
                        {
                            // Exec the changes
                            if (m_ExifTool.Args.Count > 0)
                            {
                                m_ExifTool.Exec(true);
                            }
                            
                            // Change file dates
                            m_ExifTool.ChangeFilesDate();

                            batchCounter = 0;
                            changed += Properties.Settings.Default.BATCHSIZE;
                            bwWriteChanges.ReportProgress(100 * changed / rowChangedCount);
                        }

                        // increase backCounter
                        batchCounter++;
                    }
                }
            }

            // Exec changes for last package
            if (m_ExifTool.Args.Count > 0)
            {
                m_ExifTool.Exec(true);
            }

            // Change file dates 
            m_ExifTool.ChangeFilesDate();
        }

        /// <summary>
        /// Write changes progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwWriteChanges_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            tsProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Write changes complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwWriteChanges_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Set progress
            tsProgress.Value = 100;

            // Restore icon for Save button from Stop to Save
            tsSave.Image = Properties.Resources.save_24;
            if (!e.Cancelled)
            {
                tsSave.Enabled = false;
            }

            // Reload file properties
            bwLoadProperties_Start();
        }

        #endregion

        #region Settings

        /// <summary>
        /// Load setting from Properties.Settings to form
        /// </summary>
        private void LoadSettings()
        {
            m_gvPropertiesFlag = true;
            gvPropertiesFILE.Checked = Properties.Settings.Default.gvPropertiesFILE;
            gvPropertiesEXIF.Checked = Properties.Settings.Default.gvPropertiesEXIF;
            gvPropertiesIPTC.Checked = Properties.Settings.Default.gvPropertiesIPTC;
            gvPropertiesXMP.Checked = Properties.Settings.Default.gvPropertiesXMP;
            gvPropertiesMAIN.Checked = Properties.Settings.Default.gvPropertiesMAIN;
            gvPropertiesCHANGED.Checked = Properties.Settings.Default.gvPropertiesCHANGED;
            m_gvPropertiesFlag = false;
            WindowState = Properties.Settings.Default.frmMain_WindowsState;
            Location = Properties.Settings.Default.frmMain_Location;
            splitContainerMain.SplitterDistance = Properties.Settings.Default.frmMain_SplitDistance;
            setColumnWidth(gvFiles.Columns[1], Properties.Settings.Default.frmMain_gvFiles_w1, false);
            setColumnWidth(gvFiles.Columns[2], Properties.Settings.Default.frmMain_gvFiles_w2, false);
            setColumnWidth(gvFiles.Columns[3], Properties.Settings.Default.frmMain_gvFiles_w3, true);
            setColumnWidth(gvFiles.Columns[4], Properties.Settings.Default.frmMain_gvFiles_w4, true);
            setColumnWidth(gvFiles.Columns[5], Properties.Settings.Default.frmMain_gvFiles_w5, true);
            setColumnWidth(gvFiles.Columns[6], Properties.Settings.Default.frmMain_gvFiles_w6, true);
            setColumnWidth(gvFiles.Columns[7], Properties.Settings.Default.frmMain_gvFiles_w7, true);
            setColumnWidth(gvFiles.Columns[8], Properties.Settings.Default.frmMain_gvFiles_w8, true);
            setColumnWidth(gvFiles.Columns[9], Properties.Settings.Default.frmMain_gvFiles_w9, true);
            setColumnWidth(gvFiles.Columns[10], Properties.Settings.Default.frmMain_gvFiles_w10, true);
            Settings.ReadSettings();
        }

        /// <summary>
        /// Set width of column for gvFiles
        /// </summary>
        /// <param name="column"></param>
        /// <param name="width"></param>
        /// <param name="allowHide"></param>
        private void setColumnWidth(DataGridViewColumn column, int width, bool allowHide)
        {
            if (width == 0 && allowHide)
            {
                column.Visible = false;
            }
            else if (width == 0)
            {
                column.Visible = true;
                column.Width = 100;
            }
            else
            {
                column.Visible = true;
                column.Width = width;
            }
        }

        /// <summary>
        /// Save form settings and serialized lists from Settings class
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings.Default.gvPropertiesFILE = gvPropertiesFILE.Checked;
            Properties.Settings.Default.gvPropertiesEXIF = gvPropertiesEXIF.Checked;
            Properties.Settings.Default.gvPropertiesIPTC = gvPropertiesIPTC.Checked;
            Properties.Settings.Default.gvPropertiesXMP = gvPropertiesXMP.Checked;
            Properties.Settings.Default.gvPropertiesMAIN = gvPropertiesMAIN.Checked;
            Properties.Settings.Default.gvPropertiesCHANGED = gvPropertiesCHANGED.Checked;
            Properties.Settings.Default.frmMain_WindowsState = WindowState;
            Properties.Settings.Default.frmMain_Location = Location;
            Properties.Settings.Default.frmMain_SplitDistance = splitContainerMain.SplitterDistance;
            Properties.Settings.Default.frmMain_gvFiles_w1 = gvFiles.Columns[1].Width;
            Properties.Settings.Default.frmMain_gvFiles_w2 = gvFiles.Columns[2].Width;
            Properties.Settings.Default.frmMain_gvFiles_w3 = gvFiles.Columns[3].Visible ? gvFiles.Columns[3].Width : 0;
            Properties.Settings.Default.frmMain_gvFiles_w4 = gvFiles.Columns[4].Visible ? gvFiles.Columns[4].Width : 0;
            Properties.Settings.Default.frmMain_gvFiles_w5 = gvFiles.Columns[5].Visible ? gvFiles.Columns[5].Width : 0;
            Properties.Settings.Default.frmMain_gvFiles_w6 = gvFiles.Columns[6].Visible ? gvFiles.Columns[6].Width : 0;
            Properties.Settings.Default.frmMain_gvFiles_w7 = gvFiles.Columns[7].Visible ? gvFiles.Columns[7].Width : 0;
            Properties.Settings.Default.frmMain_gvFiles_w8 = gvFiles.Columns[8].Visible ? gvFiles.Columns[8].Width : 0;
            Properties.Settings.Default.frmMain_gvFiles_w9 = gvFiles.Columns[9].Visible ? gvFiles.Columns[9].Width : 0;
            Properties.Settings.Default.frmMain_gvFiles_w10 = gvFiles.Columns[10].Visible ? gvFiles.Columns[10].Width : 0;

            Settings.SaveSettings(true);
        }

        #endregion

        #region Filter

        /// <summary>
        /// Apply filter to files records
        /// </summary>
        /// <param name="filter"></param>
        public void ApplyFilter(string filter)
        {
            bsFiles.Filter = filter;
        }

        #endregion

    }
}
