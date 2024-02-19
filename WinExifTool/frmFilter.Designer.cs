
namespace WinExifTool
{
    partial class frmFilter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.gvFilter = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tAGDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.captionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsFilter = new System.Windows.Forms.BindingSource(this.components);
            this.ds = new WinExifTool.DS();
            this.dataGridViewCheckBoxColumnEx1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.SuspendLayout();
            // 
            // gvFilter
            // 
            this.gvFilter.AllowUserToAddRows = false;
            this.gvFilter.AllowUserToDeleteRows = false;
            this.gvFilter.AllowUserToResizeColumns = false;
            this.gvFilter.AllowUserToResizeRows = false;
            this.gvFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFilter.AutoGenerateColumns = false;
            this.gvFilter.BackgroundColor = System.Drawing.Color.White;
            this.gvFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvFilter.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFilter.ColumnHeadersVisible = false;
            this.gvFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.valueDataGridViewTextBoxColumn,
            this.tAGDataGridViewCheckBoxColumn,
            this.captionDataGridViewTextBoxColumn,
            this.test});
            this.gvFilter.DataSource = this.bsFilter;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvFilter.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvFilter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvFilter.Enabled = false;
            this.gvFilter.Location = new System.Drawing.Point(2, 2);
            this.gvFilter.MultiSelect = false;
            this.gvFilter.Name = "gvFilter";
            this.gvFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFilter.ShowCellErrors = false;
            this.gvFilter.ShowEditingIcon = false;
            this.gvFilter.ShowRowErrors = false;
            this.gvFilter.Size = new System.Drawing.Size(507, 705);
            this.gvFilter.TabIndex = 0;
            this.gvFilter.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFilter_CellContentClick);
            this.gvFilter.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gv_CellFormatting);
            this.gvFilter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFilter_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Key";
            this.dataGridViewTextBoxColumn1.HeaderText = "Key";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Visible = false;
            // 
            // tAGDataGridViewCheckBoxColumn
            // 
            this.tAGDataGridViewCheckBoxColumn.DataPropertyName = "TAG";
            this.tAGDataGridViewCheckBoxColumn.HeaderText = "TAG";
            this.tAGDataGridViewCheckBoxColumn.Name = "tAGDataGridViewCheckBoxColumn";
            this.tAGDataGridViewCheckBoxColumn.Width = 60;
            // 
            // captionDataGridViewTextBoxColumn
            // 
            this.captionDataGridViewTextBoxColumn.DataPropertyName = "Caption";
            this.captionDataGridViewTextBoxColumn.HeaderText = "Caption";
            this.captionDataGridViewTextBoxColumn.Name = "captionDataGridViewTextBoxColumn";
            this.captionDataGridViewTextBoxColumn.ReadOnly = true;
            this.captionDataGridViewTextBoxColumn.Width = 300;
            // 
            // test
            // 
            this.test.DataPropertyName = "test";
            this.test.FalseValue = System.Windows.Forms.CheckState.Unchecked;
            this.test.HeaderText = "test";
            this.test.IndeterminateValue = System.Windows.Forms.CheckState.Indeterminate;
            this.test.Name = "test";
            this.test.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.test.ThreeState = true;
            this.test.TrueValue = System.Windows.Forms.CheckState.Checked;
            // 
            // bsFilter
            // 
            this.bsFilter.DataMember = "Filter";
            this.bsFilter.DataSource = this.ds;
            // 
            // ds
            // 
            this.ds.DataSetName = "DS";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewCheckBoxColumnEx1
            // 
            this.dataGridViewCheckBoxColumnEx1.DataPropertyName = "test";
            this.dataGridViewCheckBoxColumnEx1.FalseValue = "false";
            this.dataGridViewCheckBoxColumnEx1.HeaderText = "test";
            this.dataGridViewCheckBoxColumnEx1.IndeterminateValue = "DBNull.Value";
            this.dataGridViewCheckBoxColumnEx1.Name = "dataGridViewCheckBoxColumnEx1";
            this.dataGridViewCheckBoxColumnEx1.ThreeState = true;
            this.dataGridViewCheckBoxColumnEx1.TrueValue = "true";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(606, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 709);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gvFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFilter";
            this.Text = "frmFilter";
            this.Load += new System.EventHandler(this.frmFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvFilter;
        private DS ds;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsFilter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumnEx1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tAGDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn captionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn test;
        private System.Windows.Forms.Button button1;
    }
}