
namespace WinExifTool
{
    partial class frmMetadata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMetadata));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tsStatus = new System.Windows.Forms.StatusStrip();
            this.tsMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHeadline = new System.Windows.Forms.Label();
            this.txtHeadline = new System.Windows.Forms.TextBox();
            this.cmKeywords = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddKeyword = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeSection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAddSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtSupplementalCategories = new System.Windows.Forms.TextBox();
            this.lblSupplementalCategories = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.lblProvince = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountryCode = new System.Windows.Forms.TextBox();
            this.lblCountryCode = new System.Windows.Forms.Label();
            this.cbRating1 = new System.Windows.Forms.RadioButton();
            this.cbRating2 = new System.Windows.Forms.RadioButton();
            this.cbRating3 = new System.Windows.Forms.RadioButton();
            this.cbRating4 = new System.Windows.Forms.RadioButton();
            this.cbRating5 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gvKeywords = new System.Windows.Forms.DataGridView();
            this.gvKeywordsTAGColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gvKeywordsCaptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsKeywords = new System.Windows.Forms.BindingSource(this.components);
            this.ds = new WinExifTool.DS();
            this.cbRating = new System.Windows.Forms.CheckBoxEx();
            this.cbTitle = new System.Windows.Forms.CheckBoxEx();
            this.cbCountryCode = new System.Windows.Forms.CheckBoxEx();
            this.cbCountry = new System.Windows.Forms.CheckBoxEx();
            this.cbProvince = new System.Windows.Forms.CheckBoxEx();
            this.cbCity = new System.Windows.Forms.CheckBoxEx();
            this.cbSupplementalCategories = new System.Windows.Forms.CheckBoxEx();
            this.cbCategory = new System.Windows.Forms.CheckBoxEx();
            this.cbAuthor = new System.Windows.Forms.CheckBoxEx();
            this.cbCaption = new System.Windows.Forms.CheckBoxEx();
            this.cbHeadline = new System.Windows.Forms.CheckBoxEx();
            this.tsStatus.SuspendLayout();
            this.cmKeywords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvKeywords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKeywords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(782, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 36);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(782, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(114, 36);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tsStatus
            // 
            this.tsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMessage});
            this.tsStatus.Location = new System.Drawing.Point(0, 647);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(905, 22);
            this.tsStatus.TabIndex = 28;
            this.tsStatus.Text = "statusStrip1";
            // 
            // tsMessage
            // 
            this.tsMessage.AutoSize = false;
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.Size = new System.Drawing.Size(400, 17);
            this.tsMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeadline
            // 
            this.lblHeadline.AutoSize = true;
            this.lblHeadline.Location = new System.Drawing.Point(12, 13);
            this.lblHeadline.Name = "lblHeadline";
            this.lblHeadline.Size = new System.Drawing.Size(57, 13);
            this.lblHeadline.TabIndex = 29;
            this.lblHeadline.Text = "Nagłówek";
            // 
            // txtHeadline
            // 
            this.txtHeadline.ForeColor = System.Drawing.Color.LightGray;
            this.txtHeadline.Location = new System.Drawing.Point(133, 10);
            this.txtHeadline.Name = "txtHeadline";
            this.txtHeadline.Size = new System.Drawing.Size(319, 20);
            this.txtHeadline.TabIndex = 0;
            this.txtHeadline.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // cmKeywords
            // 
            this.cmKeywords.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddKeyword,
            this.miChangeSection,
            this.toolStripSeparator1,
            this.miAddSettings,
            this.miRemoveSettings});
            this.cmKeywords.Name = "cmKeywords";
            this.cmKeywords.Size = new System.Drawing.Size(206, 98);
            // 
            // miAddKeyword
            // 
            this.miAddKeyword.Name = "miAddKeyword";
            this.miAddKeyword.Size = new System.Drawing.Size(205, 22);
            this.miAddKeyword.Text = "Dodaj słowo kluczowe";
            this.miAddKeyword.Click += new System.EventHandler(this.miAddKeyword_Click);
            // 
            // miChangeSection
            // 
            this.miChangeSection.Name = "miChangeSection";
            this.miChangeSection.Size = new System.Drawing.Size(205, 22);
            this.miChangeSection.Text = "Zmień sekcję";
            this.miChangeSection.Click += new System.EventHandler(this.miChangeSection_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // miAddSettings
            // 
            this.miAddSettings.Name = "miAddSettings";
            this.miAddSettings.Size = new System.Drawing.Size(205, 22);
            this.miAddSettings.Text = "Zapisz w zdefiniowanych";
            this.miAddSettings.Click += new System.EventHandler(this.miAddSettings_Click);
            // 
            // miRemoveSettings
            // 
            this.miRemoveSettings.Name = "miRemoveSettings";
            this.miRemoveSettings.Size = new System.Drawing.Size(205, 22);
            this.miRemoveSettings.Text = "Usuń ze zdefiniowanych";
            this.miRemoveSettings.Click += new System.EventHandler(this.miRemoveSettings_Click);
            // 
            // txtCaption
            // 
            this.txtCaption.ForeColor = System.Drawing.Color.LightGray;
            this.txtCaption.Location = new System.Drawing.Point(133, 63);
            this.txtCaption.Multiline = true;
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(319, 54);
            this.txtCaption.TabIndex = 4;
            this.txtCaption.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(12, 66);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(28, 13);
            this.lblCaption.TabIndex = 33;
            this.lblCaption.Text = "Opis";
            // 
            // txtAuthor
            // 
            this.txtAuthor.ForeColor = System.Drawing.Color.LightGray;
            this.txtAuthor.Location = new System.Drawing.Point(133, 124);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(319, 20);
            this.txtAuthor.TabIndex = 6;
            this.txtAuthor.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(12, 127);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(32, 13);
            this.lblAuthor.TabIndex = 36;
            this.lblAuthor.Text = "Autor";
            // 
            // txtCategory
            // 
            this.txtCategory.ForeColor = System.Drawing.Color.LightGray;
            this.txtCategory.Location = new System.Drawing.Point(133, 150);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(319, 20);
            this.txtCategory.TabIndex = 8;
            this.txtCategory.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 153);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 39;
            this.lblCategory.Text = "Kategoria";
            // 
            // txtSupplementalCategories
            // 
            this.txtSupplementalCategories.ForeColor = System.Drawing.Color.LightGray;
            this.txtSupplementalCategories.Location = new System.Drawing.Point(133, 176);
            this.txtSupplementalCategories.Name = "txtSupplementalCategories";
            this.txtSupplementalCategories.Size = new System.Drawing.Size(319, 20);
            this.txtSupplementalCategories.TabIndex = 10;
            this.txtSupplementalCategories.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblSupplementalCategories
            // 
            this.lblSupplementalCategories.AutoSize = true;
            this.lblSupplementalCategories.Location = new System.Drawing.Point(12, 179);
            this.lblSupplementalCategories.Name = "lblSupplementalCategories";
            this.lblSupplementalCategories.Size = new System.Drawing.Size(109, 13);
            this.lblSupplementalCategories.TabIndex = 42;
            this.lblSupplementalCategories.Text = "Dodatkowe kategorie";
            // 
            // txtCity
            // 
            this.txtCity.ForeColor = System.Drawing.Color.LightGray;
            this.txtCity.Location = new System.Drawing.Point(133, 202);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(319, 20);
            this.txtCity.TabIndex = 12;
            this.txtCity.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(12, 205);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 45;
            this.lblCity.Text = "City";
            // 
            // txtProvince
            // 
            this.txtProvince.ForeColor = System.Drawing.Color.LightGray;
            this.txtProvince.Location = new System.Drawing.Point(133, 228);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(319, 20);
            this.txtProvince.TabIndex = 14;
            this.txtProvince.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(12, 231);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(80, 13);
            this.lblProvince.TabIndex = 48;
            this.lblProvince.Text = "Stan/Prowincja";
            // 
            // txtCountry
            // 
            this.txtCountry.ForeColor = System.Drawing.Color.LightGray;
            this.txtCountry.Location = new System.Drawing.Point(133, 254);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(319, 20);
            this.txtCountry.TabIndex = 16;
            this.txtCountry.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(12, 257);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(25, 13);
            this.lblCountry.TabIndex = 51;
            this.lblCountry.Text = "Kraj";
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.ForeColor = System.Drawing.Color.LightGray;
            this.txtCountryCode.Location = new System.Drawing.Point(133, 280);
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(100, 20);
            this.txtCountryCode.TabIndex = 18;
            this.txtCountryCode.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.AutoSize = true;
            this.lblCountryCode.Location = new System.Drawing.Point(12, 283);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(52, 13);
            this.lblCountryCode.TabIndex = 54;
            this.lblCountryCode.Text = "Kod kraju";
            // 
            // cbRating1
            // 
            this.cbRating1.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRating1.AutoCheck = false;
            this.cbRating1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbRating1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRating1.FlatAppearance.BorderSize = 0;
            this.cbRating1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRating1.Image = global::WinExifTool.Properties.Resources.start_empty_16;
            this.cbRating1.Location = new System.Drawing.Point(133, 309);
            this.cbRating1.Name = "cbRating1";
            this.cbRating1.Size = new System.Drawing.Size(24, 24);
            this.cbRating1.TabIndex = 63;
            this.cbRating1.UseVisualStyleBackColor = true;
            this.cbRating1.CheckedChanged += new System.EventHandler(this.cbRating_CheckedChanged);
            this.cbRating1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbRating_MouseClick);
            // 
            // cbRating2
            // 
            this.cbRating2.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRating2.AutoCheck = false;
            this.cbRating2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbRating2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRating2.FlatAppearance.BorderSize = 0;
            this.cbRating2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRating2.Image = ((System.Drawing.Image)(resources.GetObject("cbRating2.Image")));
            this.cbRating2.Location = new System.Drawing.Point(169, 309);
            this.cbRating2.Name = "cbRating2";
            this.cbRating2.Size = new System.Drawing.Size(24, 24);
            this.cbRating2.TabIndex = 64;
            this.cbRating2.UseVisualStyleBackColor = true;
            this.cbRating2.CheckedChanged += new System.EventHandler(this.cbRating_CheckedChanged);
            this.cbRating2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbRating_MouseClick);
            // 
            // cbRating3
            // 
            this.cbRating3.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRating3.AutoCheck = false;
            this.cbRating3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbRating3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRating3.FlatAppearance.BorderSize = 0;
            this.cbRating3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRating3.Image = ((System.Drawing.Image)(resources.GetObject("cbRating3.Image")));
            this.cbRating3.Location = new System.Drawing.Point(205, 309);
            this.cbRating3.Name = "cbRating3";
            this.cbRating3.Size = new System.Drawing.Size(24, 24);
            this.cbRating3.TabIndex = 65;
            this.cbRating3.UseVisualStyleBackColor = true;
            this.cbRating3.CheckedChanged += new System.EventHandler(this.cbRating_CheckedChanged);
            this.cbRating3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbRating_MouseClick);
            // 
            // cbRating4
            // 
            this.cbRating4.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRating4.AutoCheck = false;
            this.cbRating4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbRating4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRating4.FlatAppearance.BorderSize = 0;
            this.cbRating4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRating4.Image = ((System.Drawing.Image)(resources.GetObject("cbRating4.Image")));
            this.cbRating4.Location = new System.Drawing.Point(238, 309);
            this.cbRating4.Name = "cbRating4";
            this.cbRating4.Size = new System.Drawing.Size(24, 24);
            this.cbRating4.TabIndex = 66;
            this.cbRating4.UseVisualStyleBackColor = true;
            this.cbRating4.CheckedChanged += new System.EventHandler(this.cbRating_CheckedChanged);
            this.cbRating4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbRating_MouseClick);
            // 
            // cbRating5
            // 
            this.cbRating5.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRating5.AutoCheck = false;
            this.cbRating5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cbRating5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRating5.FlatAppearance.BorderSize = 0;
            this.cbRating5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRating5.Image = ((System.Drawing.Image)(resources.GetObject("cbRating5.Image")));
            this.cbRating5.Location = new System.Drawing.Point(274, 309);
            this.cbRating5.Name = "cbRating5";
            this.cbRating5.Size = new System.Drawing.Size(24, 24);
            this.cbRating5.TabIndex = 67;
            this.cbRating5.UseVisualStyleBackColor = true;
            this.cbRating5.CheckedChanged += new System.EventHandler(this.cbRating_CheckedChanged);
            this.cbRating5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbRating_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Ocena";
            // 
            // txtTitle
            // 
            this.txtTitle.ForeColor = System.Drawing.Color.LightGray;
            this.txtTitle.Location = new System.Drawing.Point(133, 36);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(319, 20);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 39);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 13);
            this.lblTitle.TabIndex = 70;
            this.lblTitle.Text = "Tytuł";
            // 
            // gvKeywords
            // 
            this.gvKeywords.AllowUserToAddRows = false;
            this.gvKeywords.AllowUserToDeleteRows = false;
            this.gvKeywords.AllowUserToResizeColumns = false;
            this.gvKeywords.AllowUserToResizeRows = false;
            this.gvKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvKeywords.BackgroundColor = System.Drawing.Color.White;
            this.gvKeywords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvKeywords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvKeywords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKeywords.ColumnHeadersVisible = false;
            this.gvKeywords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvKeywordsTAGColumn,
            this.gvKeywordsCaptionColumn});
            this.gvKeywords.ContextMenuStrip = this.cmKeywords;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvKeywords.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvKeywords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvKeywords.Location = new System.Drawing.Point(482, 10);
            this.gvKeywords.MultiSelect = false;
            this.gvKeywords.Name = "gvKeywords";
            this.gvKeywords.RowHeadersVisible = false;
            this.gvKeywords.RowTemplate.Height = 18;
            this.gvKeywords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvKeywords.ShowCellErrors = false;
            this.gvKeywords.ShowEditingIcon = false;
            this.gvKeywords.ShowRowErrors = false;
            this.gvKeywords.Size = new System.Drawing.Size(293, 634);
            this.gvKeywords.TabIndex = 71;
            this.gvKeywords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvKeywords_CellContentClick);
            this.gvKeywords.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvKeywords_CellFormatting);
            this.gvKeywords.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvKeywords_CellMouseDown);
            this.gvKeywords.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gvKeywords_CellPainting);
            this.gvKeywords.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvKeywords_CellValueChanged);
            this.gvKeywords.Resize += new System.EventHandler(this.gvKeywords_Resize);
            // 
            // gvKeywordsTAGColumn
            // 
            this.gvKeywordsTAGColumn.DataPropertyName = "TAG";
            this.gvKeywordsTAGColumn.FalseValue = System.Windows.Forms.CheckState.Unchecked;
            this.gvKeywordsTAGColumn.HeaderText = "TAG";
            this.gvKeywordsTAGColumn.IndeterminateValue = System.Windows.Forms.CheckState.Indeterminate;
            this.gvKeywordsTAGColumn.Name = "gvKeywordsTAGColumn";
            this.gvKeywordsTAGColumn.ThreeState = true;
            this.gvKeywordsTAGColumn.TrueValue = System.Windows.Forms.CheckState.Checked;
            this.gvKeywordsTAGColumn.Width = 60;
            // 
            // gvKeywordsCaptionColumn
            // 
            this.gvKeywordsCaptionColumn.DataPropertyName = "Caption";
            this.gvKeywordsCaptionColumn.HeaderText = "Caption";
            this.gvKeywordsCaptionColumn.Name = "gvKeywordsCaptionColumn";
            this.gvKeywordsCaptionColumn.ReadOnly = true;
            this.gvKeywordsCaptionColumn.Width = 160;
            // 
            // bsKeywords
            // 
            this.bsKeywords.DataMember = "Keywords";
            this.bsKeywords.DataSource = this.ds;
            this.bsKeywords.Sort = "Section, Keyword";
            // 
            // ds
            // 
            this.ds.DataSetName = "DS";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbRating
            // 
            this.cbRating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRating.AutoSize = true;
            this.cbRating.Checked = true;
            this.cbRating.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbRating.InvertCheckStateOrder = true;
            this.cbRating.Location = new System.Drawing.Point(461, 314);
            this.cbRating.Name = "cbRating";
            this.cbRating.Size = new System.Drawing.Size(15, 14);
            this.cbRating.TabIndex = 20;
            this.cbRating.Tag = "0";
            this.cbRating.ThreeState = true;
            this.cbRating.UseVisualStyleBackColor = true;
            // 
            // cbTitle
            // 
            this.cbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTitle.AutoSize = true;
            this.cbTitle.Checked = true;
            this.cbTitle.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbTitle.InvertCheckStateOrder = true;
            this.cbTitle.Location = new System.Drawing.Point(461, 39);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(15, 14);
            this.cbTitle.TabIndex = 3;
            this.cbTitle.ThreeState = true;
            this.cbTitle.UseVisualStyleBackColor = true;
            this.cbTitle.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbCountryCode
            // 
            this.cbCountryCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCountryCode.AutoSize = true;
            this.cbCountryCode.Checked = true;
            this.cbCountryCode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbCountryCode.InvertCheckStateOrder = true;
            this.cbCountryCode.Location = new System.Drawing.Point(461, 283);
            this.cbCountryCode.Name = "cbCountryCode";
            this.cbCountryCode.Size = new System.Drawing.Size(15, 14);
            this.cbCountryCode.TabIndex = 19;
            this.cbCountryCode.ThreeState = true;
            this.cbCountryCode.UseVisualStyleBackColor = true;
            this.cbCountryCode.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbCountry
            // 
            this.cbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCountry.AutoSize = true;
            this.cbCountry.Checked = true;
            this.cbCountry.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbCountry.InvertCheckStateOrder = true;
            this.cbCountry.Location = new System.Drawing.Point(461, 257);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(15, 14);
            this.cbCountry.TabIndex = 17;
            this.cbCountry.ThreeState = true;
            this.cbCountry.UseVisualStyleBackColor = true;
            this.cbCountry.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbProvince
            // 
            this.cbProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProvince.AutoSize = true;
            this.cbProvince.Checked = true;
            this.cbProvince.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbProvince.InvertCheckStateOrder = true;
            this.cbProvince.Location = new System.Drawing.Point(461, 231);
            this.cbProvince.Name = "cbProvince";
            this.cbProvince.Size = new System.Drawing.Size(15, 14);
            this.cbProvince.TabIndex = 15;
            this.cbProvince.ThreeState = true;
            this.cbProvince.UseVisualStyleBackColor = true;
            this.cbProvince.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbCity
            // 
            this.cbCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCity.AutoSize = true;
            this.cbCity.Checked = true;
            this.cbCity.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbCity.InvertCheckStateOrder = true;
            this.cbCity.Location = new System.Drawing.Point(461, 205);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(15, 14);
            this.cbCity.TabIndex = 13;
            this.cbCity.ThreeState = true;
            this.cbCity.UseVisualStyleBackColor = true;
            this.cbCity.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbSupplementalCategories
            // 
            this.cbSupplementalCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSupplementalCategories.AutoSize = true;
            this.cbSupplementalCategories.Checked = true;
            this.cbSupplementalCategories.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbSupplementalCategories.InvertCheckStateOrder = true;
            this.cbSupplementalCategories.Location = new System.Drawing.Point(461, 179);
            this.cbSupplementalCategories.Name = "cbSupplementalCategories";
            this.cbSupplementalCategories.Size = new System.Drawing.Size(15, 14);
            this.cbSupplementalCategories.TabIndex = 11;
            this.cbSupplementalCategories.ThreeState = true;
            this.cbSupplementalCategories.UseVisualStyleBackColor = true;
            this.cbSupplementalCategories.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbCategory
            // 
            this.cbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategory.AutoSize = true;
            this.cbCategory.Checked = true;
            this.cbCategory.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbCategory.InvertCheckStateOrder = true;
            this.cbCategory.Location = new System.Drawing.Point(461, 153);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(15, 14);
            this.cbCategory.TabIndex = 9;
            this.cbCategory.ThreeState = true;
            this.cbCategory.UseVisualStyleBackColor = true;
            this.cbCategory.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbAuthor
            // 
            this.cbAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAuthor.AutoSize = true;
            this.cbAuthor.Checked = true;
            this.cbAuthor.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbAuthor.InvertCheckStateOrder = true;
            this.cbAuthor.Location = new System.Drawing.Point(461, 127);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(15, 14);
            this.cbAuthor.TabIndex = 7;
            this.cbAuthor.ThreeState = true;
            this.cbAuthor.UseVisualStyleBackColor = true;
            this.cbAuthor.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbCaption
            // 
            this.cbCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCaption.AutoSize = true;
            this.cbCaption.Checked = true;
            this.cbCaption.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbCaption.InvertCheckStateOrder = true;
            this.cbCaption.Location = new System.Drawing.Point(461, 66);
            this.cbCaption.Name = "cbCaption";
            this.cbCaption.Size = new System.Drawing.Size(15, 14);
            this.cbCaption.TabIndex = 5;
            this.cbCaption.ThreeState = true;
            this.cbCaption.UseVisualStyleBackColor = true;
            this.cbCaption.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // cbHeadline
            // 
            this.cbHeadline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHeadline.AutoSize = true;
            this.cbHeadline.Checked = true;
            this.cbHeadline.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbHeadline.InvertCheckStateOrder = true;
            this.cbHeadline.Location = new System.Drawing.Point(461, 13);
            this.cbHeadline.Name = "cbHeadline";
            this.cbHeadline.Size = new System.Drawing.Size(15, 14);
            this.cbHeadline.TabIndex = 1;
            this.cbHeadline.ThreeState = true;
            this.cbHeadline.UseVisualStyleBackColor = true;
            this.cbHeadline.CheckStateChanged += new System.EventHandler(this.CheckBox_CheckStateChanged);
            // 
            // frmMetadata
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(905, 669);
            this.Controls.Add(this.gvKeywords);
            this.Controls.Add(this.cbRating);
            this.Controls.Add(this.cbTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRating5);
            this.Controls.Add(this.cbRating4);
            this.Controls.Add(this.cbRating3);
            this.Controls.Add(this.cbRating2);
            this.Controls.Add(this.cbRating1);
            this.Controls.Add(this.cbCountryCode);
            this.Controls.Add(this.txtCountryCode);
            this.Controls.Add(this.lblCountryCode);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.cbProvince);
            this.Controls.Add(this.txtProvince);
            this.Controls.Add(this.lblProvince);
            this.Controls.Add(this.cbCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.cbSupplementalCategories);
            this.Controls.Add(this.txtSupplementalCategories);
            this.Controls.Add(this.lblSupplementalCategories);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cbAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.cbCaption);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cbHeadline);
            this.Controls.Add(this.txtHeadline);
            this.Controls.Add(this.lblHeadline);
            this.Controls.Add(this.tsStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMetadata";
            this.Text = "Edycja danych";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEdit_FormClosing);
            this.Load += new System.EventHandler(this.frmEditIPTC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMetadata_KeyDown);
            this.tsStatus.ResumeLayout(false);
            this.tsStatus.PerformLayout();
            this.cmKeywords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvKeywords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKeywords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bsKeywords;
        private DS ds;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.StatusStrip tsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsMessage;
        private System.Windows.Forms.Label lblHeadline;
        private System.Windows.Forms.TextBox txtHeadline;
        private System.Windows.Forms.CheckBoxEx cbHeadline;
        private System.Windows.Forms.ContextMenuStrip cmKeywords;
        private System.Windows.Forms.ToolStripMenuItem miAddSettings;
        private System.Windows.Forms.ToolStripMenuItem miRemoveSettings;
        private System.Windows.Forms.ToolStripMenuItem miAddKeyword;
        private System.Windows.Forms.ToolStripMenuItem miChangeSection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBoxEx cbCaption;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.CheckBoxEx cbAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.CheckBoxEx cbCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.CheckBoxEx cbSupplementalCategories;
        private System.Windows.Forms.TextBox txtSupplementalCategories;
        private System.Windows.Forms.Label lblSupplementalCategories;
        private System.Windows.Forms.CheckBoxEx cbCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.CheckBoxEx cbProvince;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.CheckBoxEx cbCountry;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.CheckBoxEx cbCountryCode;
        private System.Windows.Forms.TextBox txtCountryCode;
        private System.Windows.Forms.Label lblCountryCode;
        private System.Windows.Forms.RadioButton cbRating1;
        private System.Windows.Forms.RadioButton cbRating2;
        private System.Windows.Forms.RadioButton cbRating3;
        private System.Windows.Forms.RadioButton cbRating4;
        private System.Windows.Forms.RadioButton cbRating5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBoxEx cbTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBoxEx cbRating;
        private System.Windows.Forms.DataGridView gvKeywords;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gvKeywordsTAGColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvKeywordsCaptionColumn;
    }
}