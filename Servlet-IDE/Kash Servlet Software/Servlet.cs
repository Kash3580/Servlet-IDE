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
    public partial class Servlet : Form
    {
        public Servlet()
        {
            InitializeComponent();
        }

        string str, str1;
        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Project np = new New_Project();
            DialogResult dr = np.ShowDialog();  
            if (dr== DialogResult.OK)
            {
                try
                {
                   
                    str = "C:\\Program Files\\Apache Software Foundation\\Tomcat 5.0\\webapps\\" + np.txtnewProject.Text;

                    Directory.CreateDirectory(str);

                    str1 = str + "\\WEB-INF";
                    Directory.CreateDirectory(str1);
                    Directory.CreateDirectory(str1 + "\\classes");
                    File.Copy("C:\\Program Files\\Apache Software Foundation\\Tomcat 5.0\\conf\\web.xml", str1 + "\\web.xml");
                    np.Close();
                }
                catch (Exception a)
                {
                    MessageBox.Show("Please install Appache Server", "Error", MessageBoxButtons.OK);  
                }
            }
            if (dr == DialogResult.Cancel)
            {
                //np.Close(); 
            }
        }
        int i = 1;
        private void servletFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i++;
            TabPage tabp = new TabPage();
            tabp.Name = "Default" + i.ToString();
            tabp.Size = new System.Drawing.Size(1019, 685); 
            tabp.TabIndex = i;
            tabp.Text = "Default" + i.ToString()+".java";
            RichTextBox rb = new RichTextBox();
            rb.Location = new System.Drawing.Point(3, 3);
            rb.Name = "richTextBox1";
            rb.Size = new System.Drawing.Size(1013, 676);
            rb.TabIndex = 0;
            rb.Text = "";
            tabp.Controls.Add(rb);

            this.tabControl1.Controls.Add(tabp);
            this.tabControl1.SelectedIndex = i - 1;  
        }

        private void Servlet_Load(object sender, EventArgs e)
        {

        }

        private void existingProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Project op = new Open_Project();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (op.comboBox1.Text == "")
                {
                    MessageBox.Show("Please Select Directory name");

                }
                else
                {


                    str = op.comboBox1.Text;

                    op.Close();
                }
            }
            if (dr == DialogResult.Cancel)
            {
                //closing open project dialog
            }

        }

        private void existingServletFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Open file in(*.java)|*.java|AllFiles(*.*)|*.*";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(fd.FileName);
                i++;
                TabPage tabp = new TabPage();
                tabp.Name = "Default" + i.ToString();
                tabp.Size = new System.Drawing.Size(1019, 685);
                tabp.TabIndex = i;
                tabp.Text = fd.SafeFileName.ToString();
                RichTextBox rb = new RichTextBox();
                rb.Location = new System.Drawing.Point(3, 3);
                rb.Name = "richTextBox1";
                rb.Size = new System.Drawing.Size(1013, 676);
                rb.TabIndex = 0;
                while (!sr.EndOfStream)
                {

                    rb.Text = rb.Text + sr.ReadLine()+"\n";
                   
                    
                }
                tabp.Controls.Add(rb);

                this.tabControl1.Controls.Add(tabp);
                this.tabControl1.SelectedIndex = i - 1; 
                sr.Close();
            }

        }

        private void saveServletFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string p= this.tabControl1.SelectedTab.Name; 
            Save_Servlet_File sf = new Save_Servlet_File(p); 

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string dname = "C:\\Program Files\\Apache Software Foundation\\Tomcat 5.0\\webapps";
                StreamWriter sw = new StreamWriter(str + "\\" + sf.txtfilename.Text + ".java", true);
                sw.Write(richTextBox1.Text);
                MessageBox.Show("file Successfully saved");
                sw.Close();
                string serv = " <servlet-name>" + sf.txtfilename.Text + "</servlet-name> <servlet-class>" + sf.txtfilename.Text + "</servlet-class></servlet>";
                string serv_map = "<servlet-mapping><servlet-name>" + sf.txtfilename.Text + "</servlet-name></servlet-mapping>";
                string servlet1 = serv + serv_map;



                string str4 = str1 + "\\web.xml";
                StreamWriter sw1 = new StreamWriter(str4, true);
             
                 sw1.Write(servlet1);
                 sw1.Close();

            }

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.InitialDirectory = str;
            svd.Filter = "Save file in(*.java)|*.java";
            svd.FilterIndex = 1;
            svd.RestoreDirectory = true;
            if (svd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(svd.FileName, true);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
                this.richTextBox1.Font = fd.Font;
        }

        private void aboutUsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About_us ab = new About_us();
            ab.ShowDialog(); 
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe");
            Runhelp r = new Runhelp();
           
            r.ShowDialog(); 
        }
    }
}
