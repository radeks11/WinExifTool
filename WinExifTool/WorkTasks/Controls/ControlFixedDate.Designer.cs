
namespace WinExifTool.WorkTasks.Controls
{
    partial class ControlFixedDate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlFixedDate));
            this.editWriteExif = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editShift = new System.Windows.Forms.DateTimePicker();
            this.editStartTime = new System.Windows.Forms.DateTimePicker();
            this.editStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editWriteExif
            // 
            resources.ApplyResources(this.editWriteExif, "editWriteExif");
            this.editWriteExif.Checked = true;
            this.editWriteExif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.editWriteExif.Name = "editWriteExif";
            this.editWriteExif.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // editShift
            // 
            this.editShift.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.editShift, "editShift");
            this.editShift.Name = "editShift";
            this.editShift.ShowCheckBox = true;
            this.editShift.ShowUpDown = true;
            this.editShift.Value = new System.DateTime(1753, 1, 1, 0, 0, 15, 0);
            // 
            // editStartTime
            // 
            this.editStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.editStartTime, "editStartTime");
            this.editStartTime.Name = "editStartTime";
            this.editStartTime.ShowUpDown = true;
            // 
            // editStartDate
            // 
            resources.ApplyResources(this.editStartDate, "editStartDate");
            this.editStartDate.Name = "editStartDate";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // ControlFixedDate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.editWriteExif);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editShift);
            this.Controls.Add(this.editStartTime);
            this.Controls.Add(this.editStartDate);
            this.Name = "ControlFixedDate";
            this.Load += new System.EventHandler(this.ControlFixedDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox editWriteExif;
        public System.Windows.Forms.DateTimePicker editShift;
        public System.Windows.Forms.DateTimePicker editStartTime;
        public System.Windows.Forms.DateTimePicker editStartDate;
        private System.Windows.Forms.Label label3;
    }
}
