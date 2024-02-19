
namespace WinExifTool.WorkTasks.Controls
{
    partial class ControlPattern
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
            this.editModifyPatterns = new System.Windows.Forms.Button();
            this.editPattern = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // editModifyPatterns
            // 
            this.editModifyPatterns.FlatAppearance.BorderSize = 0;
            this.editModifyPatterns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editModifyPatterns.Image = global::WinExifTool.Properties.Resources.edit_24;
            this.editModifyPatterns.Location = new System.Drawing.Point(268, 8);
            this.editModifyPatterns.Name = "editModifyPatterns";
            this.editModifyPatterns.Size = new System.Drawing.Size(34, 21);
            this.editModifyPatterns.TabIndex = 34;
            this.editModifyPatterns.UseVisualStyleBackColor = true;
            this.editModifyPatterns.Click += new System.EventHandler(this.editModifyPatterns_Click);
            // 
            // editPattern
            // 
            this.editPattern.FormattingEnabled = true;
            this.editPattern.Items.AddRange(new object[] {
            "yyyyMMdd_hhmmss"});
            this.editPattern.Location = new System.Drawing.Point(99, 9);
            this.editPattern.Name = "editPattern";
            this.editPattern.Size = new System.Drawing.Size(163, 21);
            this.editPattern.TabIndex = 33;
            this.editPattern.Text = "yyyyMMdd_hhmmss";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Maska daty";
            // 
            // ControlPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editModifyPatterns);
            this.Controls.Add(this.editPattern);
            this.Controls.Add(this.label1);
            this.Name = "ControlPattern";
            this.Size = new System.Drawing.Size(303, 38);
            this.Load += new System.EventHandler(this.ControlPattern_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editModifyPatterns;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox editPattern;
    }
}
