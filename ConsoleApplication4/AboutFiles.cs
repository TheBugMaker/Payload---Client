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
    public partial class AboutFiles : Form
    {
        private bool downloading = false; 
        Writer wr;
        Listener ls; 
        public AboutFiles(Writer wr , Listener ls)
        {
            this.wr = wr; this.ls = ls;
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync(); 
        }

        public void addCheckbox(String ch ){
            CheckBox cb = new CheckBox();
            cb.Width = 151; 
            String name = Convert.ToBase64String(Encoding.ASCII.GetBytes(ch));
            name += ".gh"; 
            if (File.Exists(name))
            {
                cb.ForeColor = Color.FromArgb(69,97,157);
            }
            else { 
                cb.ForeColor = Color.WhiteSmoke ;  
            }

            
            cb.Text = ch;         
            cb.Font = new Font("QuartZ",8);
            flowLayoutPanel1.Controls.Add(cb); 

        }

        private void addLabel(String ch) { // Not in use 
            Label l = new Label();
            l.Font = new Font("Pt Serif", 10);
         //   l.Dock = DockStyle.Fill;
         //   l.TextAlign = ContentAlignment.MiddleCenter;
            l.ForeColor = Color.WhiteSmoke;
            l.Text = ch;
            flowLayoutPanel1.Controls.Add(l); 
        }

      
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(10);
            wr.sendString("03");
            backgroundWorker1.ReportProgress(60);
            e.Result = ls.fileNmaesOut();
            backgroundWorker1.ReportProgress(100);

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {   String[] a = e.Result as String[];

            if (a == null)
            {
                errorpanel.Visible = true; 
                
            }
            else {      
                int n = 0; 
                foreach (String fileName in a) {
                    if (fileName.Trim().Length > 0) { addCheckbox(fileName); n++; } 

                }
                if(n == 0 ){
                    errorpanel.Visible = true;
                } 
                
            } 
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            while (progressBar1.Value < e.ProgressPercentage)
            {
                progressBar1.PerformStep();
                Task.Delay(50); 
            }

            if (progressBar1.Value == 100) {
                progressBar1.Value = 0; 
            }
        }

        private async void download_Click(object sender, EventArgs e)
        {   if(!downloading){
            downloading = true; 
            int a = 0;
            foreach (Component c in flowLayoutPanel1.Controls)
            {
                CheckBox cb = c as CheckBox;
                if (cb != null && cb.Checked)
                {
                    String name = cb.Text;
                    name = Convert.ToBase64String(Encoding.ASCII.GetBytes(name));
                    name += ".gh";
                    wr.sendString("tr" + name);
                   
                    a++;
                }
            }
            if (a == 0)
            {
                MessageBox.Show("no logs were selected", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int timeout = 10000;
                while (timeout > 0)
                {
                    if (progressBar1.Value != ls.getProgesspercent()) { timeout = 1000; }
                    progressBar1.Value = ls.getProgesspercent();
                    await Task.Delay(200);
                    timeout -= 200;
                }
                progressBar1.Value = 0;
            }
            downloading = false; 
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {   // FOOD For THAUGHT :  delete local  
            int a = 0;
            foreach (Component c in flowLayoutPanel1.Controls)
            {
                CheckBox cb = c as CheckBox;
                if (cb != null && cb.Checked)
                {
                    String name = cb.Text;
                    name = Convert.ToBase64String(Encoding.ASCII.GetBytes(name));
                    name += ".gh";
                    wr.sendString("dl" + name); 
                    cb.Dispose(); 
                    a++;
                }
            }
            if (a == 0)
            {
                MessageBox.Show("no logs were selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}
