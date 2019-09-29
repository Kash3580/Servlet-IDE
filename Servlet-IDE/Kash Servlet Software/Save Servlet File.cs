using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kash_Servlet_Software
{
    public partial class Save_Servlet_File : Form
    {
        string path;
        public Save_Servlet_File(string cpath)
        {
            InitializeComponent();
            path = cpath;

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; 
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Save_Servlet_File_Load(object sender, EventArgs e)
        {
            this.txtfilename.Text = path; 
              
        }
    }
}
