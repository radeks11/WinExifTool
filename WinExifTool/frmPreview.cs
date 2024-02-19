using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinExifTool
{
    public partial class frmPreview : Form
    {
        private frmMain m_MainForm;

        /// <summary>
        /// MainForm 
        /// </summary>
        public frmMain MainForm
        {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }

        public frmPreview()
        {
            InitializeComponent();
        }

        public void setImage(Bitmap bitmap)
        {
            imagePreview.Image = bitmap;
        }

        public void setImage(Image image)
        {
            imagePreview.Image = image;
        }

        private void frmPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
