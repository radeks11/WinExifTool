
namespace WinExifTool
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dlgOpenFiles = new System.Windows.Forms.OpenFileDialog();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.tsOpenFiles = new System.Windows.Forms.ToolStripButton();
            this.tsClear = new System.Windows.Forms.ToolStripButton();
            this.tsUndo = new System.Windows.Forms.ToolStripButton();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSetTAG = new System.Windows.Forms.ToolStripButton();
            this.tsUnsetTAG = new System.Windows.Forms.ToolStripButton();
            this.tsSetAllTAG = new System.Windows.Forms.ToolStripButton();
            this.tsClearAllTAG = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFilter = new System.Windows.Forms.ToolStripButton();
            this.tsPreview = new System.Windows.Forms.ToolStripButton();
            this.tsMetadata = new System.Windows.Forms.ToolStripButton();
            this.tsMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsConfig = new System.Windows.Forms.ToolStripButton();
            this.tsStatus = new System.Windows.Forms.StatusStrip();
            this.tsWorkModeDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.gvFiles = new System.Windows.Forms.DataGridView();
            this.gvFilesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bsFiles = new System.Windows.Forms.BindingSource(this.components);
            this.ds = new WinExifTool.DS();
            this.splitContainerProperties = new System.Windows.Forms.SplitContainer();
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.gvPropertiesCHANGED = new System.Windows.Forms.CheckBox();
            this.gvPropertiesMAIN = new System.Windows.Forms.CheckBox();
            this.gvPropertiesXMP = new System.Windows.Forms.CheckBox();
            this.gvPropertiesIPTC = new System.Windows.Forms.CheckBox();
            this.gvPropertiesEXIF = new System.Windows.Forms.CheckBox();
            this.gvPropertiesFILE = new System.Windows.Forms.CheckBox();
            this.gvProperties = new System.Windows.Forms.DataGridView();
            this.sectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvPropertiesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miMain = new System.Windows.Forms.ToolStripMenuItem();
            this.miExclude = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.bsProperties = new System.Windows.Forms.BindingSource(this.components);
            this.bwLoadProperties = new System.ComponentModel.BackgroundWorker();
            this.bwWriteChanges = new System.ComponentModel.BackgroundWorker();
            this.filePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileOrgDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Headline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keywords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsToolbar.SuspendLayout();
            this.tsStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerProperties)).BeginInit();
            this.splitContainerProperties.Panel1.SuspendLayout();
            this.splitContainerProperties.Panel2.SuspendLayout();
            this.splitContainerProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProperties)).BeginInit();
            this.gvPropertiesMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgOpenFiles
            // 
            this.dlgOpenFiles.Multiselect = true;
            // 
            // tsToolbar
            // 
            resources.ApplyResources(this.tsToolbar, "tsToolbar");
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpenFiles,
            this.tsClear,
            this.tsUndo,
            this.tsRefresh,
            this.tsSave,
            this.toolStripSeparator1,
            this.tsSetTAG,
            this.tsUnsetTAG,
            this.tsSetAllTAG,
            this.tsClearAllTAG,
            this.toolStripSeparator3,
            this.tsFilter,
            this.tsPreview,
            this.tsMetadata,
            this.tsMap,
            this.toolStripSeparator2,
            this.miTools,
            this.toolStripSeparator4,
            this.tsConfig});
            this.tsToolbar.Name = "tsToolbar";
            // 
            // tsOpenFiles
            // 
            resources.ApplyResources(this.tsOpenFiles, "tsOpenFiles");
            this.tsOpenFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsOpenFiles.Image = global::WinExifTool.Properties.Resources.folder_plus_24;
            this.tsOpenFiles.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsOpenFiles.Name = "tsOpenFiles";
            this.tsOpenFiles.Click += new System.EventHandler(this.tsOpenFiles_Click);
            // 
            // tsClear
            // 
            resources.ApplyResources(this.tsClear, "tsClear");
            this.tsClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsClear.Image = global::WinExifTool.Properties.Resources.folder_minus_24;
            this.tsClear.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsClear.Name = "tsClear";
            this.tsClear.Click += new System.EventHandler(this.tsClear_Click);
            // 
            // tsUndo
            // 
            resources.ApplyResources(this.tsUndo, "tsUndo");
            this.tsUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUndo.Image = global::WinExifTool.Properties.Resources.undo_24;
            this.tsUndo.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsUndo.Name = "tsUndo";
            this.tsUndo.Click += new System.EventHandler(this.tsUndo_Click);
            // 
            // tsRefresh
            // 
            resources.ApplyResources(this.tsRefresh, "tsRefresh");
            this.tsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRefresh.Image = global::WinExifTool.Properties.Resources.refresh_24;
            this.tsRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsSave, "tsSave");
            this.tsSave.Image = global::WinExifTool.Properties.Resources.save_24;
            this.tsSave.Name = "tsSave";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsSetTAG
            // 
            resources.ApplyResources(this.tsSetTAG, "tsSetTAG");
            this.tsSetTAG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSetTAG.Image = global::WinExifTool.Properties.Resources.select_24;
            this.tsSetTAG.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsSetTAG.Name = "tsSetTAG";
            this.tsSetTAG.Click += new System.EventHandler(this.tsSetTAG_Click);
            // 
            // tsUnsetTAG
            // 
            resources.ApplyResources(this.tsUnsetTAG, "tsUnsetTAG");
            this.tsUnsetTAG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUnsetTAG.Image = global::WinExifTool.Properties.Resources.unselect_24;
            this.tsUnsetTAG.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsUnsetTAG.Name = "tsUnsetTAG";
            this.tsUnsetTAG.Click += new System.EventHandler(this.tsUnsetTAG_Click);
            // 
            // tsSetAllTAG
            // 
            resources.ApplyResources(this.tsSetAllTAG, "tsSetAllTAG");
            this.tsSetAllTAG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSetAllTAG.Image = global::WinExifTool.Properties.Resources.select_all_24;
            this.tsSetAllTAG.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsSetAllTAG.Name = "tsSetAllTAG";
            this.tsSetAllTAG.Click += new System.EventHandler(this.tsSetAllTAG_Click);
            // 
            // tsClearAllTAG
            // 
            resources.ApplyResources(this.tsClearAllTAG, "tsClearAllTAG");
            this.tsClearAllTAG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsClearAllTAG.Image = global::WinExifTool.Properties.Resources.unselect_all_24;
            this.tsClearAllTAG.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsClearAllTAG.Name = "tsClearAllTAG";
            this.tsClearAllTAG.Click += new System.EventHandler(this.tsClearAllTAG_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsFilter
            // 
            resources.ApplyResources(this.tsFilter, "tsFilter");
            this.tsFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFilter.Image = global::WinExifTool.Properties.Resources.filter_24;
            this.tsFilter.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsFilter.Name = "tsFilter";
            this.tsFilter.Click += new System.EventHandler(this.tsFilter_Click);
            // 
            // tsPreview
            // 
            resources.ApplyResources(this.tsPreview, "tsPreview");
            this.tsPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPreview.Image = global::WinExifTool.Properties.Resources.image_24;
            this.tsPreview.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsPreview.Name = "tsPreview";
            this.tsPreview.Click += new System.EventHandler(this.tsPreview_Click);
            // 
            // tsMetadata
            // 
            resources.ApplyResources(this.tsMetadata, "tsMetadata");
            this.tsMetadata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMetadata.Image = global::WinExifTool.Properties.Resources.edit_24;
            this.tsMetadata.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsMetadata.Name = "tsMetadata";
            this.tsMetadata.Click += new System.EventHandler(this.tsMetadata_Click);
            // 
            // tsMap
            // 
            resources.ApplyResources(this.tsMap, "tsMap");
            this.tsMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsMap.Image = global::WinExifTool.Properties.Resources.map_24;
            this.tsMap.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsMap.Name = "tsMap";
            this.tsMap.Click += new System.EventHandler(this.tsMap_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // miTools
            // 
            resources.ApplyResources(this.miTools, "miTools");
            this.miTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.miTools.Image = global::WinExifTool.Properties.Resources.wrench_24;
            this.miTools.Name = "miTools";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // tsConfig
            // 
            resources.ApplyResources(this.tsConfig, "tsConfig");
            this.tsConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsConfig.Image = global::WinExifTool.Properties.Resources.config_24;
            this.tsConfig.Name = "tsConfig";
            this.tsConfig.Click += new System.EventHandler(this.tsConfig_Click);
            // 
            // tsStatus
            // 
            this.tsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsWorkModeDescription,
            this.tsProgress,
            this.tsFileCount,
            this.tsMessage});
            resources.ApplyResources(this.tsStatus, "tsStatus");
            this.tsStatus.Name = "tsStatus";
            // 
            // tsWorkModeDescription
            // 
            this.tsWorkModeDescription.Name = "tsWorkModeDescription";
            resources.ApplyResources(this.tsWorkModeDescription, "tsWorkModeDescription");
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            resources.ApplyResources(this.tsProgress, "tsProgress");
            // 
            // tsFileCount
            // 
            resources.ApplyResources(this.tsFileCount, "tsFileCount");
            this.tsFileCount.Name = "tsFileCount";
            // 
            // tsMessage
            // 
            resources.ApplyResources(this.tsMessage, "tsMessage");
            this.tsMessage.Name = "tsMessage";
            // 
            // splitContainerMain
            // 
            resources.ApplyResources(this.splitContainerMain, "splitContainerMain");
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.gvFiles);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerProperties);
            // 
            // gvFiles
            // 
            this.gvFiles.AllowDrop = true;
            this.gvFiles.AllowUserToAddRows = false;
            this.gvFiles.AutoGenerateColumns = false;
            this.gvFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filePathDataGridViewTextBoxColumn,
            this.TAG,
            this.fileNameDataGridViewTextBoxColumn,
            this.FileOrgDate,
            this.CreateDate,
            this.Rating,
            this.Headline,
            this.Title,
            this.Caption,
            this.Keywords,
            this.GPS});
            this.gvFiles.ContextMenuStrip = this.gvFilesMenu;
            this.gvFiles.DataSource = this.bsFiles;
            resources.ApplyResources(this.gvFiles, "gvFiles");
            this.gvFiles.Name = "gvFiles";
            this.gvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFiles_CellContentClick);
            this.gvFiles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFiles_CellEndEdit);
            this.gvFiles.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvFiles_CellFormatting);
            this.gvFiles.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvFiles_CellMouseDoubleClick);
            this.gvFiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFiles_CellValueChanged);
            this.gvFiles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFiles_RowEnter);
            this.gvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.gvFiles_DragDrop);
            this.gvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.gvFiles_DragEnter);
            this.gvFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvFiles_KeyDown);
            // 
            // gvFilesMenu
            // 
            this.gvFilesMenu.Name = "gvFilesMenu";
            resources.ApplyResources(this.gvFilesMenu, "gvFilesMenu");
            // 
            // bsFiles
            // 
            this.bsFiles.AllowNew = false;
            this.bsFiles.DataMember = "Files";
            this.bsFiles.DataSource = this.ds;
            // 
            // ds
            // 
            this.ds.DataSetName = "DS";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainerProperties
            // 
            resources.ApplyResources(this.splitContainerProperties, "splitContainerProperties");
            this.splitContainerProperties.Name = "splitContainerProperties";
            // 
            // splitContainerProperties.Panel1
            // 
            this.splitContainerProperties.Panel1.Controls.Add(this.imagePreview);
            // 
            // splitContainerProperties.Panel2
            // 
            this.splitContainerProperties.Panel2.Controls.Add(this.gvPropertiesCHANGED);
            this.splitContainerProperties.Panel2.Controls.Add(this.gvPropertiesMAIN);
            this.splitContainerProperties.Panel2.Controls.Add(this.gvPropertiesXMP);
            this.splitContainerProperties.Panel2.Controls.Add(this.gvPropertiesIPTC);
            this.splitContainerProperties.Panel2.Controls.Add(this.gvPropertiesEXIF);
            this.splitContainerProperties.Panel2.Controls.Add(this.gvPropertiesFILE);
            this.splitContainerProperties.Panel2.Controls.Add(this.gvProperties);
            // 
            // imagePreview
            // 
            resources.ApplyResources(this.imagePreview, "imagePreview");
            this.imagePreview.Name = "imagePreview";
            this.imagePreview.TabStop = false;
            // 
            // gvPropertiesCHANGED
            // 
            resources.ApplyResources(this.gvPropertiesCHANGED, "gvPropertiesCHANGED");
            this.gvPropertiesCHANGED.Checked = true;
            this.gvPropertiesCHANGED.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gvPropertiesCHANGED.Name = "gvPropertiesCHANGED";
            this.gvPropertiesCHANGED.Tag = "Changed";
            this.gvPropertiesCHANGED.UseVisualStyleBackColor = true;
            this.gvPropertiesCHANGED.CheckedChanged += new System.EventHandler(this.gvProperties_CheckedChanged);
            // 
            // gvPropertiesMAIN
            // 
            resources.ApplyResources(this.gvPropertiesMAIN, "gvPropertiesMAIN");
            this.gvPropertiesMAIN.Checked = true;
            this.gvPropertiesMAIN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gvPropertiesMAIN.Name = "gvPropertiesMAIN";
            this.gvPropertiesMAIN.Tag = "Main";
            this.gvPropertiesMAIN.UseVisualStyleBackColor = true;
            this.gvPropertiesMAIN.CheckedChanged += new System.EventHandler(this.gvProperties_CheckedChanged);
            // 
            // gvPropertiesXMP
            // 
            resources.ApplyResources(this.gvPropertiesXMP, "gvPropertiesXMP");
            this.gvPropertiesXMP.Checked = true;
            this.gvPropertiesXMP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gvPropertiesXMP.Name = "gvPropertiesXMP";
            this.gvPropertiesXMP.Tag = "XMP";
            this.gvPropertiesXMP.UseVisualStyleBackColor = true;
            this.gvPropertiesXMP.CheckedChanged += new System.EventHandler(this.gvProperties_CheckedChanged);
            this.gvPropertiesXMP.Click += new System.EventHandler(this.gvProperties_CheckedChanged);
            // 
            // gvPropertiesIPTC
            // 
            resources.ApplyResources(this.gvPropertiesIPTC, "gvPropertiesIPTC");
            this.gvPropertiesIPTC.Checked = true;
            this.gvPropertiesIPTC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gvPropertiesIPTC.Name = "gvPropertiesIPTC";
            this.gvPropertiesIPTC.Tag = "IPTC";
            this.gvPropertiesIPTC.UseVisualStyleBackColor = true;
            this.gvPropertiesIPTC.Click += new System.EventHandler(this.gvProperties_CheckedChanged);
            // 
            // gvPropertiesEXIF
            // 
            resources.ApplyResources(this.gvPropertiesEXIF, "gvPropertiesEXIF");
            this.gvPropertiesEXIF.Checked = true;
            this.gvPropertiesEXIF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gvPropertiesEXIF.Name = "gvPropertiesEXIF";
            this.gvPropertiesEXIF.Tag = "EXIF";
            this.gvPropertiesEXIF.UseVisualStyleBackColor = true;
            this.gvPropertiesEXIF.Click += new System.EventHandler(this.gvProperties_CheckedChanged);
            // 
            // gvPropertiesFILE
            // 
            resources.ApplyResources(this.gvPropertiesFILE, "gvPropertiesFILE");
            this.gvPropertiesFILE.Checked = true;
            this.gvPropertiesFILE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gvPropertiesFILE.Name = "gvPropertiesFILE";
            this.gvPropertiesFILE.Tag = "File";
            this.gvPropertiesFILE.UseVisualStyleBackColor = true;
            this.gvPropertiesFILE.CheckedChanged += new System.EventHandler(this.gvProperties_CheckedChanged);
            // 
            // gvProperties
            // 
            this.gvProperties.AllowUserToAddRows = false;
            this.gvProperties.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.gvProperties, "gvProperties");
            this.gvProperties.AutoGenerateColumns = false;
            this.gvProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sectionDataGridViewTextBoxColumn,
            this.fieldDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.gvProperties.ContextMenuStrip = this.gvPropertiesMenu;
            this.gvProperties.DataSource = this.bsProperties;
            this.gvProperties.Name = "gvProperties";
            this.gvProperties.ReadOnly = true;
            this.gvProperties.RowHeadersVisible = false;
            this.gvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProperties.ShowRowErrors = false;
            this.gvProperties.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvProperties_CellFormatting);
            this.gvProperties.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvProperties_MouseDown);
            this.gvProperties.Resize += new System.EventHandler(this.gvProperties_Resize);
            // 
            // sectionDataGridViewTextBoxColumn
            // 
            this.sectionDataGridViewTextBoxColumn.DataPropertyName = "Section";
            resources.ApplyResources(this.sectionDataGridViewTextBoxColumn, "sectionDataGridViewTextBoxColumn");
            this.sectionDataGridViewTextBoxColumn.Name = "sectionDataGridViewTextBoxColumn";
            this.sectionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fieldDataGridViewTextBoxColumn
            // 
            this.fieldDataGridViewTextBoxColumn.DataPropertyName = "Field";
            resources.ApplyResources(this.fieldDataGridViewTextBoxColumn, "fieldDataGridViewTextBoxColumn");
            this.fieldDataGridViewTextBoxColumn.Name = "fieldDataGridViewTextBoxColumn";
            this.fieldDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            resources.ApplyResources(this.valueDataGridViewTextBoxColumn, "valueDataGridViewTextBoxColumn");
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gvPropertiesMenu
            // 
            this.gvPropertiesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMain,
            this.miExclude,
            this.miCopy});
            this.gvPropertiesMenu.Name = "gvPropertiesMenu";
            resources.ApplyResources(this.gvPropertiesMenu, "gvPropertiesMenu");
            this.gvPropertiesMenu.Opening += new System.ComponentModel.CancelEventHandler(this.gvPropertiesMenu_Opening);
            // 
            // miMain
            // 
            this.miMain.Name = "miMain";
            resources.ApplyResources(this.miMain, "miMain");
            this.miMain.Click += new System.EventHandler(this.miMain_Click);
            // 
            // miExclude
            // 
            this.miExclude.Name = "miExclude";
            resources.ApplyResources(this.miExclude, "miExclude");
            this.miExclude.Click += new System.EventHandler(this.miExclude_Click);
            // 
            // miCopy
            // 
            this.miCopy.Name = "miCopy";
            resources.ApplyResources(this.miCopy, "miCopy");
            this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
            // 
            // bsProperties
            // 
            this.bsProperties.DataMember = "Properties";
            this.bsProperties.DataSource = this.ds;
            this.bsProperties.Filter = "Section IN (\'File\', \'EXIF\')";
            // 
            // bwLoadProperties
            // 
            this.bwLoadProperties.WorkerReportsProgress = true;
            this.bwLoadProperties.WorkerSupportsCancellation = true;
            this.bwLoadProperties.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoadProperties_DoWork);
            this.bwLoadProperties.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwLoadProperties_ProgressChanged);
            this.bwLoadProperties.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoadProperties_RunWorkerCompleted);
            // 
            // bwWriteChanges
            // 
            this.bwWriteChanges.WorkerReportsProgress = true;
            this.bwWriteChanges.WorkerSupportsCancellation = true;
            this.bwWriteChanges.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwWriteChanges_DoWork);
            this.bwWriteChanges.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwWriteChanges_ProgressChanged);
            this.bwWriteChanges.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwWriteChanges_RunWorkerCompleted);
            // 
            // filePathDataGridViewTextBoxColumn
            // 
            this.filePathDataGridViewTextBoxColumn.DataPropertyName = "FilePath";
            resources.ApplyResources(this.filePathDataGridViewTextBoxColumn, "filePathDataGridViewTextBoxColumn");
            this.filePathDataGridViewTextBoxColumn.Name = "filePathDataGridViewTextBoxColumn";
            // 
            // TAG
            // 
            this.TAG.DataPropertyName = "TAG";
            resources.ApplyResources(this.TAG, "TAG");
            this.TAG.Name = "TAG";
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            resources.ApplyResources(this.fileNameDataGridViewTextBoxColumn, "fileNameDataGridViewTextBoxColumn");
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FileOrgDate
            // 
            this.FileOrgDate.DataPropertyName = "FileOrgDate";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy HH:mm:ss";
            this.FileOrgDate.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.FileOrgDate, "FileOrgDate");
            this.FileOrgDate.Name = "FileOrgDate";
            this.FileOrgDate.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            dataGridViewCellStyle2.Format = "dd-MM-yyyy HH:mm:ss";
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.CreateDate, "CreateDate");
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // Rating
            // 
            this.Rating.DataPropertyName = "Rating";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Rating.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Rating, "Rating");
            this.Rating.Name = "Rating";
            this.Rating.ReadOnly = true;
            // 
            // Headline
            // 
            this.Headline.DataPropertyName = "Headline";
            resources.ApplyResources(this.Headline, "Headline");
            this.Headline.Name = "Headline";
            this.Headline.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            resources.ApplyResources(this.Title, "Title");
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Caption
            // 
            this.Caption.DataPropertyName = "Caption";
            resources.ApplyResources(this.Caption, "Caption");
            this.Caption.Name = "Caption";
            this.Caption.ReadOnly = true;
            // 
            // Keywords
            // 
            this.Keywords.DataPropertyName = "Keywords";
            resources.ApplyResources(this.Keywords, "Keywords");
            this.Keywords.Name = "Keywords";
            this.Keywords.ReadOnly = true;
            // 
            // GPS
            // 
            this.GPS.DataPropertyName = "GPS";
            resources.ApplyResources(this.GPS, "GPS");
            this.GPS.Name = "GPS";
            this.GPS.ReadOnly = true;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.tsStatus);
            this.Controls.Add(this.tsToolbar);
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.tsStatus.ResumeLayout(false);
            this.tsStatus.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.splitContainerProperties.Panel1.ResumeLayout(false);
            this.splitContainerProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerProperties)).EndInit();
            this.splitContainerProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProperties)).EndInit();
            this.gvPropertiesMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DS ds;
        private System.Windows.Forms.BindingSource bsFiles;
        private System.Windows.Forms.OpenFileDialog dlgOpenFiles;
        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.StatusStrip tsStatus;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.DataGridView gvFiles;
        private System.Windows.Forms.ToolStripButton tsOpenFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsConfig;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.SplitContainer splitContainerProperties;
        private System.Windows.Forms.ToolStripButton tsClear;
        private System.Windows.Forms.ToolStripStatusLabel tsFileCount;
        private System.Windows.Forms.PictureBox imagePreview;
        private System.Windows.Forms.ToolStripStatusLabel tsWorkModeDescription;
        private System.Windows.Forms.ToolStripStatusLabel tsMessage;
        private System.Windows.Forms.DataGridView gvProperties;
        private System.Windows.Forms.BindingSource bsProperties;
        private System.Windows.Forms.CheckBox gvPropertiesXMP;
        private System.Windows.Forms.CheckBox gvPropertiesIPTC;
        private System.Windows.Forms.CheckBox gvPropertiesEXIF;
        private System.Windows.Forms.CheckBox gvPropertiesFILE;
        private System.Windows.Forms.ContextMenuStrip gvPropertiesMenu;
        private System.Windows.Forms.ToolStripMenuItem miExclude;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsSetTAG;
        private System.Windows.Forms.ToolStripButton tsUnsetTAG;
        private System.Windows.Forms.ToolStripButton tsClearAllTAG;
        private System.ComponentModel.BackgroundWorker bwLoadProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn orgDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton tsMap;
        private System.Windows.Forms.ToolStripButton tsPreview;
        private System.Windows.Forms.ToolStripButton tsMetadata;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripButton tsFilter;
        private System.ComponentModel.BackgroundWorker bwWriteChanges;
        private System.Windows.Forms.ToolStripDropDownButton miTools;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox gvPropertiesCHANGED;
        private System.Windows.Forms.CheckBox gvPropertiesMAIN;
        private System.Windows.Forms.ToolStripMenuItem miMain;
        private System.Windows.Forms.ToolStripButton tsSetAllTAG;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton tsUndo;
        private System.Windows.Forms.ContextMenuStrip gvFilesMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileOrgDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Headline;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caption;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keywords;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPS;
    }
}