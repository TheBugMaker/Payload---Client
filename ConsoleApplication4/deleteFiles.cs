using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace ConsoleApplication4
{    
    public partial class deleteFiles : Form
    {   
        Writer wr;
        Listener ls;
        public deleteFiles(Writer wr , Listener ls)
        {
            this.wr = wr; this.ls = ls;
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
             
            wr.sendString("03");
             
            e.Result = ls.fileNmaesOut();

        }
        public void addCheckbox(String ch)
        {
            CheckBox cb = new CheckBox();
            cb.Width = 151;
            String name = Convert.ToBase64String(Encoding.ASCII.GetBytes(ch));
            name += ".gh";
            if (File.Exists(name))
            {
                cb.ForeColor = Color.FromArgb(69, 97, 157);
            }
            else
            {
                cb.ForeColor = Color.WhiteSmoke;
            }


            cb.Text = ch;
            cb.Font = new Font("QuartZ", 8);
            flowLayoutPanel1.Controls.Add(cb);

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String[] a = e.Result as String[];

            if (a == null)
            {
                errorpanel.Visible = true;

            }
            else
            {
                int n = 0;
                foreach (String fileName in a)
                {
                    if (fileName.Trim().Length > 0) { addCheckbox(fileName); n++; }

                }
                if (n == 0)
                {
                    errorpanel.Visible = true;
                }

            } 
            
        }
    }
}
