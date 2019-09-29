using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; 

namespace Kash_Servlet_Software
{
    public partial class New_Project : Form
    {
        public New_Project()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;  
           
        }

        private void New_Project_Load(object sender, EventArgs e)
        {
            try
            {
                string path;
                path = "C:\\Program Files\\Apache Software Foundation\\Tomcat 5.0\\webapps\\";

                txtlocation.Text = path;
            }
            catch (Exception a)
            {
                MessageBox.Show("Please install Appache Server", "System Error", MessageBoxButtons.OK);  
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
