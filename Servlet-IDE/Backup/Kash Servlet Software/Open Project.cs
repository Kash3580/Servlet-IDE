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
    public partial class Open_Project : Form
    {
        public Open_Project()
        {
            InitializeComponent();
        }

      

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Open_Project_Load(object sender, EventArgs e)
        {

            try
            {
                string[] a = Directory.GetDirectories("C:\\Program Files\\Apache Software Foundation\\Tomcat 5.0\\webapps\\");
                
                foreach (string i in a)
                {
                    comboBox1.Items.Add(i);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Process failed");
            }
        }

     
      

    

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedText;    

        }

       

       
    }
}
