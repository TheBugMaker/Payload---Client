using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets; 
namespace ConsoleApplication4
{
    public partial class MyConsole : Form
    {
   
        private Listener ls;
        private Writer wr;
        private Thread th; 
        
        public MyConsole(Listener ls ,Writer wr)
        {
           
            
            this.ls = ls;
            this.wr = wr; 
            InitializeComponent();
            th = new Thread( () => run() ) ;
            th.IsBackground = true; 
            th.Start(); 
        }

        public void run() {
            do
            {
                write(ls.cmdOutput());

            } while (true); 
        }

        public void write(String st) {
            Label l = new Label() ;
            l.Margin = new Padding(3,0,0,0); 
            l.Text = st;
            l.AutoSize = true; 
            l.Font = new Font( "lucida Console", 9);
            l.ForeColor = Color.WhiteSmoke;
            this.Invoke((MethodInvoker)delegate
                     {
                     this.flowLayoutPanel1.Controls.Add(l);
                      });
            

        }

        
        public void writeL(String st ) {
            label1.Text = st; 
        }
        public String readL() {
            return label1.Text;
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox1.Text = textBox1.Text.Trim('\n');
                if (textBox1.Text.Length > 0)
                {
                    
                    wr.sendString("00" + textBox1.Text);
                    textBox1.Text = "";    
                 
                }
            }
        }

        private void MyConsole_FormClosed(object sender, FormClosedEventArgs e)
        {   
            wr.sendString("0a");
            th.Abort(); 
        }

        
    }
}
