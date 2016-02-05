using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets; 

namespace ConsoleApplication4
{
    public class Writer
    {
        private Object lock1 = new Object();
        Socket s;
        public Writer(Socket s) {
            this.s = s; 
        }

        public void sendString(String st) { 
            UTF8Encoding asen = new UTF8Encoding();
            lock (lock1){
                s.Send(BitConverter.GetBytes(asen.GetByteCount(st)),4,SocketFlags.None); 
                s.Send(asen.GetBytes(st));
            }
        }

        public void sendArray(byte [] b , String code ) {
            UTF8Encoding asen = new UTF8Encoding();
            byte []b1 = asen.GetBytes(code);
            byte[] msg = new byte[b.Length + b1.Length];
            b1.CopyTo(msg, 0);
            b.CopyTo(msg, b1.Length);
            
            lock (lock1)
            {
                s.Send(BitConverter.GetBytes(msg.Length), 4, SocketFlags.None);
                s.Send(msg);
            }
        }



    }
}
