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
    public partial class user_controle : Form
    {
        private Socket s;


        private bool stop = true;
        private bool mouse = false;
        private bool keyb = false;

        private static bool shift = false;
        private static bool ctrl = false;
        private static bool alt = false;

        private List<byte> str = new List<byte>();
        static private short wait = 0;

        private Listener ls; private Writer wr;

        public user_controle(Socket s, Listener ls, Writer wr)
        {
            this.s = s; 
            this.ls = ls;
            this.wr = wr;
            wr.sendString("05"); 
            
            
            str.Add(57);
            str.Add(49);

            SetStyle(ControlStyles.DoubleBuffer,true);
            SetStyle(ControlStyles.UserPaint ,true);
            SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();
            timer1.Start(); 
            
        }

        
        public void change_back(Bitmap img) {
            img = new Bitmap(img , backg.Size);
            backg.Image =(Image) img ; 
        }

        public void animate() // animates the back screen 
        {   
            do
            {
                Bitmap bitmap1 = ls.picOutput();
                this.change_back(bitmap1);
                

            } while (!stop);
        }
        private void user_controle_Load(object sender, EventArgs e)
        {
            stop = false;
            Thread anime_back = new Thread(new ThreadStart(animate));
            anime_back.Start();

        }

        
        
        // start and stop changing back 
        private void onOff_Click_1(object sender, EventArgs e)
        {
            stop = !stop;
            onOff.Text = (stop) ? "Start" : "Stop";
            if (!stop)
            {
                timer1.Start(); 
                Thread anime_back = new Thread(new ThreadStart(animate));
                anime_back.Start();
                wr.sendString("05");
            }
            else {
                timer1.Stop(); 
                wr.sendString("e5"); //  stop working  ; 
            }
        }

        private void enableMouse_CheckedChanged(object sender, EventArgs e)
        {
            mouse = enableMouse.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            keyb = enableKeyboard.Checked; 
        }

        private void backg_MouseClick(object sender, MouseEventArgs e)
        {
            // TODO  Mouse Middle 
           if(mouse){

               int b = 2;
               if (e.Button == MouseButtons.Left) { b=1;}
               else if(e.Button == MouseButtons.Right){b = 3 ;}
               float x = (float)e.X / (float)this.backg.Size.Width;
               


               x = ((int)(x * 10000f) )/ 10000f;  // 4 number decimal
               
               float y =(float) e.Y / (float)this.backg.Size.Height;
               y = ((int)(y * 10000f) ) / 10000f;  // 4 number decimal 
                 
              String cmd = "90" + x + "-" + y+ "-" + b;
              wr.sendString(cmd); 
           }
        }

        private void backg_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mouse)
            {   
                float x =(float) e.X / (float)this.backg.Size.Width;
        
                
                x = ((int)(x * 10000f) )  / 10000f;  // 4 number decimal 
                float y =(float) e.Y /(float)this.backg.Size.Height;
                y = ((int)(y * 10000f)) / 10000f;  // 4 number decimal 
               
                String cmd = "90" + x + "-" + y + "-4";
                
                wr.sendString(cmd); 
                
            }
        }

        private void user_controle_KeyUp(object sender, KeyEventArgs e)
        {   if (keyb){
                switch ((byte)e.KeyValue)
                {
                    case 16:
                        shift = false;
                        str.Add((byte)e.KeyValue);
                        break;
                    case 17:
                        ctrl = false;
                        str.Add((byte)e.KeyValue);
                        break;
                    case 18:
                        alt = false;
                        str.Add((byte)e.KeyValue);
                        break;
                        
                      
                }
                if (wait <= 0)
                {
                    wait = 3;
                 Thread send = new Thread(new ThreadStart(sendkey_sync));
                 send.Start(); 
                }
                else {
                    wait += 1;
                }
            }
        }

        private void user_controle_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyb)
            {
                if ((byte)e.KeyValue == 8 && str.Count > 0) { str.RemoveAt(str.Count - 1); }
                else
                {
                    switch ((byte)e.KeyValue)
                    {
                        case 16:
                            if (!shift)
                            {
                                shift = true;
                                str.Add((byte)e.KeyValue);
                            }
                            break;
                        case 17:
                            if (!ctrl)
                            {
                                ctrl = true;
                                str.Add((byte)e.KeyValue);
                            }
                            break;
                        case 18:
                            if (!alt)
                            {
                                alt = true;
                                str.Add((byte)e.KeyValue);
                            }
                            break;
                        default:  
                            str.Add((byte)e.KeyValue);
                            break;

                    }
                   
                
                }
             }
        }
        private void sendkey_sync() // synchronizes the send key command  
        {  
            
            do {
                System.Threading.Thread.Sleep(3000);
                 wait-=5;
            } while(wait>0);
            sendKey();
            
        
        }
        private void sendKey() { 
            ASCIIEncoding asce = new ASCIIEncoding();
            
            byte []b = str.ToArray<byte>() ; 
            str.Clear() ; 
            wr.sendArray(b,"91"); 

        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            wr.sendString("b5"); 
        }

        private void compression_ud_ValueChanged(object sender, EventArgs e)
        {
            wr.sendString("c5" + compressionUpDown.Value);  
        }

        private void frameUpDown_ValueChanged(object sender, EventArgs e)
        {
           int a = (int)  (1000 / frameUpDown.Value  ) ;
           wr.sendString("f5" + a); 
        }

        // change the quality f background 
        private void qlt_ud_ValueChanged(object sender, EventArgs e)
        {
            wr.sendString("q5"+qlt_ud.Value);
        }

        private void user_controle_FormClosing(object sender, FormClosingEventArgs e)
        {
            wr.sendString("e5"); 
        }


       
        
    }
}
