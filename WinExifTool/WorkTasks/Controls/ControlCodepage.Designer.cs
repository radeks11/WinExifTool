
namespace WinExifTool.WorkTasks.Controls
{
    partial class ControlCodepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCodepage));
            this.editFrom = new System.Windows.Forms.ComboBox();
            this.editTo = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editFrom
            // 
            this.editFrom.DisplayMember = "Key";
            this.editFrom.FormattingEnabled = true;
            resources.ApplyResources(this.editFrom, "editFrom");
            this.editFrom.Name = "editFrom";
            this.editFrom.ValueMember = "Key";
            // 
            // editTo
            // 
            this.editTo.DisplayMember = "Key";
            this.editTo.FormattingEnabled = true;
            resources.ApplyResources(this.editTo, "editTo");
            this.editTo.Name = "editTo";
            this.editTo.ValueMember = "Key";
            // 
            // lbl1
            // 
            resources.ApplyResources(this.lbl1, "lbl1");
            this.lbl1.Name = "lbl1";
            // 
            // ControlCodepage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editTo);
            this.Controls.Add(this.editFrom);
            this.Controls.Add(this.lbl1);
            this.Name = "ControlCodepage";
            this.Load += new System.EventHandler(this.ControlCodepage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox editFrom;
        public System.Windows.Forms.ComboBox editTo;
        private System.Windows.Forms.Label lbl1;
    }
}
