
namespace WinExifTool
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblExifTool = new System.Windows.Forms.Label();
            this.editExifToolPath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.openFileExifToolDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblExifToolDownload = new System.Windows.Forms.Label();
            this.editLanguage = new System.Windows.Forms.ComboBox();
            this.bsLanguages = new System.Windows.Forms.BindingSource(this.components);
            this.lblLanguage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editExtensions = new System.Windows.Forms.TextBox();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.btnShowExecFolder = new System.Windows.Forms.Button();
            this.editGOOGLEAPIKEY = new System.Windows.Forms.TextBox();
            this.lblGOOGLEAPIKEY = new System.Windows.Forms.Label();
            this.editMapProvider = new System.Windows.Forms.ComboBox();
            this.lblMapProvider = new System.Windows.Forms.Label();
            this.lblGenerateGOOGLEAPIKEY = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDownload = new System.Windows.Forms.Label();
            this.lblExifToolTUF8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsLanguages)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblExifTool
            // 
            resources.ApplyResources(this.lblExifTool, "lblExifTool");
            this.lblExifTool.Name = "lblExifTool";
            // 
            // editExifToolPath
            // 
            resources.ApplyResources(this.editExifToolPath, "editExifToolPath");
            this.editExifToolPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editExifToolPath.Name = "editExifToolPath";
            // 
            // btnSelectFile
            // 
            resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
            this.btnSelectFile.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectFile.Image = global::WinExifTool.Properties.Resources.folder_open_16;
            this.btnSelectFile.Name = "btnSelectFile";
            this.toolTip1.SetToolTip(this.btnSelectFile, resources.GetString("btnSelectFile.ToolTip"));
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // openFileExifToolDialog
            // 
            this.openFileExifToolDialog.AddExtension = false;
            this.openFileExifToolDialog.DefaultExt = "exe";
            this.openFileExifToolDialog.FileName = "ExifTool.exe";
            resources.ApplyResources(this.openFileExifToolDialog, "openFileExifToolDialog");
            // 
            // lblExifToolDownload
            // 
            resources.ApplyResources(this.lblExifToolDownload, "lblExifToolDownload");
            this.lblExifToolDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExifToolDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblExifToolDownload.Name = "lblExifToolDownload";
            this.lblExifToolDownload.Click += new System.EventHandler(this.lblExifToolDownload_Click);
            // 
            // editLanguage
            // 
            this.editLanguage.DataSource = this.bsLanguages;
            this.editLanguage.DisplayMember = "Key";
            this.editLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.editLanguage, "editLanguage");
            this.editLanguage.Name = "editLanguage";
            this.editLanguage.ValueMember = "Key";
            // 
            // bsLanguages
            // 
            this.bsLanguages.DataSource = typeof(WinExifTool.Utils.Languages);
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // editExtensions
            // 
            this.editExtensions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.editExtensions, "editExtensions");
            this.editExtensions.Name = "editExtensions";
            // 
            // btnOpenLog
            // 
            resources.ApplyResources(this.btnOpenLog, "btnOpenLog");
            this.btnOpenLog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // btnShowExecFolder
            // 
            resources.ApplyResources(this.btnShowExecFolder, "btnShowExecFolder");
            this.btnShowExecFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnShowExecFolder.Name = "btnShowExecFolder";
            this.btnShowExecFolder.UseVisualStyleBackColor = true;
            this.btnShowExecFolder.Click += new System.EventHandler(this.btnShowExecFolder_Click);
            // 
            // editGOOGLEAPIKEY
            // 
            this.editGOOGLEAPIKEY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.editGOOGLEAPIKEY, "editGOOGLEAPIKEY");
            this.editGOOGLEAPIKEY.Name = "editGOOGLEAPIKEY";
            // 
            // lblGOOGLEAPIKEY
            // 
            resources.ApplyResources(this.lblGOOGLEAPIKEY, "lblGOOGLEAPIKEY");
            this.lblGOOGLEAPIKEY.Name = "lblGOOGLEAPIKEY";
            // 
            // editMapProvider
            // 
            this.editMapProvider.FormattingEnabled = true;
            this.editMapProvider.Items.AddRange(new object[] {
            resources.GetString("editMapProvider.Items"),
            resources.GetString("editMapProvider.Items1")});
            resources.ApplyResources(this.editMapProvider, "editMapProvider");
            this.editMapProvider.Name = "editMapProvider";
            // 
            // lblMapProvider
            // 
            resources.ApplyResources(this.lblMapProvider, "lblMapProvider");
            this.lblMapProvider.Name = "lblMapProvider";
            // 
            // lblGenerateGOOGLEAPIKEY
            // 
            resources.ApplyResources(this.lblGenerateGOOGLEAPIKEY, "lblGenerateGOOGLEAPIKEY");
            this.lblGenerateGOOGLEAPIKEY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGenerateGOOGLEAPIKEY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblGenerateGOOGLEAPIKEY.Name = "lblGenerateGOOGLEAPIKEY";
            this.lblGenerateGOOGLEAPIKEY.Click += new System.EventHandler(this.lblGenerateGOOGLEAPIKEY_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // lblDownload
            // 
            resources.ApplyResources(this.lblDownload, "lblDownload");
            this.lblDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Click += new System.EventHandler(this.lblDownload_Click);
            // 
            // lblExifToolTUF8
            // 
            this.lblExifToolTUF8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.lblExifToolTUF8, "lblExifToolTUF8");
            this.lblExifToolTUF8.Name = "lblExifToolTUF8";
            this.lblExifToolTUF8.Click += new System.EventHandler(this.lblExifToolTUF8_Click);
            // 
            // frmConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblExifToolTUF8);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGenerateGOOGLEAPIKEY);
            this.Controls.Add(this.lblMapProvider);
            this.Controls.Add(this.editMapProvider);
            this.Controls.Add(this.editGOOGLEAPIKEY);
            this.Controls.Add(this.lblGOOGLEAPIKEY);
            this.Controls.Add(this.btnShowExecFolder);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.editExtensions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.editLanguage);
            this.Controls.Add(this.lblExifToolDownload);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.editExifToolPath);
            this.Controls.Add(this.lblExifTool);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmConfig";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsLanguages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileExifToolDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblExifToolDownload;
        private System.Windows.Forms.ComboBox editLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.BindingSource bsLanguages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editExtensions;
        private System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.Button btnShowExecFolder;
        private System.Windows.Forms.TextBox editGOOGLEAPIKEY;
        private System.Windows.Forms.Label lblGOOGLEAPIKEY;
        private System.Windows.Forms.ComboBox editMapProvider;
        private System.Windows.Forms.Label lblMapProvider;
        public System.Windows.Forms.TextBox editExifToolPath;
        public System.Windows.Forms.Label lblExifTool;
        private System.Windows.Forms.Label lblGenerateGOOGLEAPIKEY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Label lblExifToolTUF8;
    }
}