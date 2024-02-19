
namespace WinExifTool
{
    partial class frmMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMap));
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsStatus = new System.Windows.Forms.StatusStrip();
            this.tsMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.mapContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAllTagged = new System.Windows.Forms.ToolStripMenuItem();
            this.miCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.miNoGPS = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenGpx = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miHeader1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHeader2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miGpxAllTagged = new System.Windows.Forms.ToolStripMenuItem();
            this.miGpxCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.miGpxNoGPS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTimezone = new System.Windows.Forms.ToolStripComboBox();
            this.tsZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsFixPos = new System.Windows.Forms.ToolStripButton();
            this.tsFind = new System.Windows.Forms.ToolStripButton();
            this.btnLoadGpx = new System.Windows.Forms.ToolStripButton();
            this.tsToolbar.SuspendLayout();
            this.tsStatus.SuspendLayout();
            this.mapContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemory = 5;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 20;
            this.map.MinZoom = 4;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(1177, 772);
            this.map.TabIndex = 0;
            this.map.Zoom = 0D;
            this.map.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.map_OnMarkerClick);
            this.map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map_MouseClick);
            this.map.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.map_MouseDoubleClick);
            // 
            // tsToolbar
            // 
            this.tsToolbar.AutoSize = false;
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsZoomIn,
            this.tsZoomOut,
            this.tsFixPos,
            this.toolStripSeparator1,
            this.tsKeyword,
            this.tsFind,
            this.toolStripSeparator2,
            this.btnLoadGpx,
            this.tsTimezone});
            this.tsToolbar.Location = new System.Drawing.Point(0, 0);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Size = new System.Drawing.Size(1177, 48);
            this.tsToolbar.TabIndex = 1;
            this.tsToolbar.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsKeyword
            // 
            this.tsKeyword.AutoSize = false;
            this.tsKeyword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsKeyword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tsKeyword.Name = "tsKeyword";
            this.tsKeyword.Size = new System.Drawing.Size(200, 48);
            this.tsKeyword.ToolTipText = "Wyszukaj lokalizację";
            this.tsKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsKeyword_KeyDown);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tsStatus
            // 
            this.tsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMessage,
            this.tsCurrent});
            this.tsStatus.Location = new System.Drawing.Point(0, 750);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(1177, 22);
            this.tsStatus.TabIndex = 29;
            this.tsStatus.Text = "statusStrip1";
            // 
            // tsMessage
            // 
            this.tsMessage.AutoSize = false;
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.Size = new System.Drawing.Size(400, 17);
            this.tsMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsCurrent
            // 
            this.tsCurrent.AutoSize = false;
            this.tsCurrent.Name = "tsCurrent";
            this.tsCurrent.Size = new System.Drawing.Size(200, 17);
            // 
            // mapContextMenu
            // 
            this.mapContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHeader1,
            this.miAllTagged,
            this.miCurrent,
            this.miNoGPS,
            this.toolStripMenuItem1,
            this.tsHeader2,
            this.miGpxAllTagged,
            this.miGpxCurrent,
            this.miGpxNoGPS});
            this.mapContextMenu.Name = "mapContextMenu";
            this.mapContextMenu.Size = new System.Drawing.Size(219, 186);
            // 
            // miAllTagged
            // 
            this.miAllTagged.Name = "miAllTagged";
            this.miAllTagged.Size = new System.Drawing.Size(218, 22);
            this.miAllTagged.Text = "Zaznaczone pliki";
            this.miAllTagged.Click += new System.EventHandler(this.miAllTagged_Click);
            // 
            // miCurrent
            // 
            this.miCurrent.Name = "miCurrent";
            this.miCurrent.Size = new System.Drawing.Size(218, 22);
            this.miCurrent.Text = "Bieżący";
            this.miCurrent.Click += new System.EventHandler(this.miCurrent_Click);
            // 
            // miNoGPS
            // 
            this.miNoGPS.Name = "miNoGPS";
            this.miNoGPS.Size = new System.Drawing.Size(218, 22);
            this.miNoGPS.Text = "Zaznaczone bez lokalizacji";
            this.miNoGPS.Click += new System.EventHandler(this.miNoGPS_Click);
            // 
            // dlgOpenGpx
            // 
            this.dlgOpenGpx.DefaultExt = "*.gpx";
            this.dlgOpenGpx.FileName = "openFileDialog1";
            this.dlgOpenGpx.Filter = "Pliki GPX (*.gpx)|*.gpx";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(215, 6);
            // 
            // miHeader1
            // 
            this.miHeader1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.miHeader1.Enabled = false;
            this.miHeader1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.miHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.miHeader1.Name = "miHeader1";
            this.miHeader1.Size = new System.Drawing.Size(218, 22);
            this.miHeader1.Text = "Ustawianie pozycji z mapy";
            // 
            // tsHeader2
            // 
            this.tsHeader2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tsHeader2.Enabled = false;
            this.tsHeader2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsHeader2.Name = "tsHeader2";
            this.tsHeader2.Size = new System.Drawing.Size(218, 22);
            this.tsHeader2.Text = "Geokodowanie";
            // 
            // miGpxAllTagged
            // 
            this.miGpxAllTagged.Enabled = false;
            this.miGpxAllTagged.Name = "miGpxAllTagged";
            this.miGpxAllTagged.Size = new System.Drawing.Size(218, 22);
            this.miGpxAllTagged.Text = "Zaznaczone pliki";
            this.miGpxAllTagged.Click += new System.EventHandler(this.miGpxAllTagged_Click);
            // 
            // miGpxCurrent
            // 
            this.miGpxCurrent.Enabled = false;
            this.miGpxCurrent.Name = "miGpxCurrent";
            this.miGpxCurrent.Size = new System.Drawing.Size(218, 22);
            this.miGpxCurrent.Text = "Bieżący";
            this.miGpxCurrent.Click += new System.EventHandler(this.miGpxCurrent_Click);
            // 
            // miGpxNoGPS
            // 
            this.miGpxNoGPS.Enabled = false;
            this.miGpxNoGPS.Name = "miGpxNoGPS";
            this.miGpxNoGPS.Size = new System.Drawing.Size(218, 22);
            this.miGpxNoGPS.Text = "Zaznaczone bez lokalizacji";
            this.miGpxNoGPS.Click += new System.EventHandler(this.miGpxNoGPS_Click);
            // 
            // tsTimezone
            // 
            this.tsTimezone.AutoSize = false;
            this.tsTimezone.Name = "tsTimezone";
            this.tsTimezone.Size = new System.Drawing.Size(400, 48);
            this.tsTimezone.ToolTipText = "Strefa czasowa zrobienia zdjęcia";
            // 
            // tsZoomIn
            // 
            this.tsZoomIn.AutoSize = false;
            this.tsZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsZoomIn.Image = global::WinExifTool.Properties.Resources.magnifying_glass_plus_24;
            this.tsZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsZoomIn.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsZoomIn.Name = "tsZoomIn";
            this.tsZoomIn.Size = new System.Drawing.Size(32, 32);
            this.tsZoomIn.Text = "Zoom in";
            this.tsZoomIn.Click += new System.EventHandler(this.tsZoomIn_Click);
            // 
            // tsZoomOut
            // 
            this.tsZoomOut.AutoSize = false;
            this.tsZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsZoomOut.Image = global::WinExifTool.Properties.Resources.magnifying_glass_minus_24;
            this.tsZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsZoomOut.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsZoomOut.Name = "tsZoomOut";
            this.tsZoomOut.Size = new System.Drawing.Size(32, 32);
            this.tsZoomOut.Text = "Zoom out";
            this.tsZoomOut.Click += new System.EventHandler(this.tsZoomOut_Click);
            // 
            // tsFixPos
            // 
            this.tsFixPos.AutoSize = false;
            this.tsFixPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFixPos.Image = global::WinExifTool.Properties.Resources.push_pin_24;
            this.tsFixPos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsFixPos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFixPos.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsFixPos.Name = "tsFixPos";
            this.tsFixPos.Size = new System.Drawing.Size(32, 32);
            this.tsFixPos.Text = "Zamróź centrowanie mapy";
            this.tsFixPos.Click += new System.EventHandler(this.tsFixPos_Click);
            // 
            // tsFind
            // 
            this.tsFind.AutoSize = false;
            this.tsFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFind.Image = global::WinExifTool.Properties.Resources.search_24;
            this.tsFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFind.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsFind.Name = "tsFind";
            this.tsFind.Size = new System.Drawing.Size(32, 32);
            this.tsFind.Text = "Szukaj";
            this.tsFind.Click += new System.EventHandler(this.tsFind_Click);
            // 
            // btnLoadGpx
            // 
            this.btnLoadGpx.AutoSize = false;
            this.btnLoadGpx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadGpx.Image = global::WinExifTool.Properties.Resources.open_folder_24;
            this.btnLoadGpx.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLoadGpx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadGpx.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.btnLoadGpx.Name = "btnLoadGpx";
            this.btnLoadGpx.Size = new System.Drawing.Size(32, 32);
            this.btnLoadGpx.Text = "Load GPX";
            this.btnLoadGpx.Click += new System.EventHandler(this.btnLoadGpx_Click);
            // 
            // frmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 772);
            this.Controls.Add(this.tsStatus);
            this.Controls.Add(this.tsToolbar);
            this.Controls.Add(this.map);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMap";
            this.Text = "Mapa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMap_FormClosing);
            this.Load += new System.EventHandler(this.frmMap_Load);
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.tsStatus.ResumeLayout(false);
            this.tsStatus.PerformLayout();
            this.mapContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton tsZoomIn;
        private System.Windows.Forms.ToolStripButton tsZoomOut;
        private System.Windows.Forms.StatusStrip tsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsMessage;
        private System.Windows.Forms.ContextMenuStrip mapContextMenu;
        private System.Windows.Forms.ToolStripMenuItem miCurrent;
        private System.Windows.Forms.ToolStripMenuItem miNoGPS;
        private System.Windows.Forms.ToolStripMenuItem miAllTagged;
        private System.Windows.Forms.ToolStripStatusLabel tsCurrent;
        private System.Windows.Forms.ToolStripTextBox tsKeyword;
        private System.Windows.Forms.ToolStripButton tsFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsFixPos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnLoadGpx;
        private System.Windows.Forms.OpenFileDialog dlgOpenGpx;
        private System.Windows.Forms.ToolStripMenuItem miHeader1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsHeader2;
        private System.Windows.Forms.ToolStripMenuItem miGpxAllTagged;
        private System.Windows.Forms.ToolStripMenuItem miGpxCurrent;
        private System.Windows.Forms.ToolStripMenuItem miGpxNoGPS;
        private System.Windows.Forms.ToolStripComboBox tsTimezone;
    }
}