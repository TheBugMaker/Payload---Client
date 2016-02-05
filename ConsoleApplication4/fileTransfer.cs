using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms; 

namespace ConsoleApplication4
{
       public class fileTransfer
    {
         private   bool work { get; set; }   
         private   List<String> toDownload = new List<String>();
         private Writer wr ;
         private Listener ls; 
         
         public fileTransfer(Writer wr , Listener ls){
             this.wr = wr; this.ls = ls; 
            work = false ; 
         }

         public  void transfer() {
             if (!work) {
                 work = true; 
                 byte[] buffer = new byte[9000] ;
                 

                 while (toDownload.Count() > 0 && work) { 
                     String name ; 
                         lock (toDownload) {
                             name = toDownload[0]; 
                             toDownload.RemoveAt(0);
                         }
                     
                    var paths = name.Split(Path.DirectorySeparatorChar);
                    var id = encoding.Md5(new Random().Next(int.MaxValue) + "_" + paths[paths.Length - 1] ) ; 
                   using (FileStream fsSource = new FileStream(name, FileMode.Open, FileAccess.Read))
                       {

                        
                       wr.sendString("s0"+paths[paths.Length - 1 ]+":"+fsSource.Length.ToString()+":"+id);
                       int a = 0; 
                       do
                       {
                          a = fsSource.Read(buffer, 0, buffer.Length);
                          
                          if (a == 0) break; 
                          wr.sendArray(buffer.Take(a).ToArray<byte>(),"s1"+id); // open and send stuff 
                       } while (a > 0);  
                   }

                   wr.sendString("s2" + id);
                  
                 }
                 work = false; 
             }            
         }


         public  void add(String a){
            lock(toDownload)
            {
                toDownload.Add(a) ; 
            }
         }

         public void stop() {
             work = false; 
         } 
    }
}
