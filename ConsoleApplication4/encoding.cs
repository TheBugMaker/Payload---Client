using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    static class encoding
    {
        public static String Sha1(String ch)
        {
            using (System.Security.Cryptography.SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed())
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                var hash = sha1.ComputeHash(asen.GetBytes(ch));
                return System.Text.Encoding.ASCII.GetString(hash);
            }


        }
        public static String Md5(String ch)
        {
            using (System.Security.Cryptography.MD5 sha1 = new System.Security.Cryptography.MD5Cng())
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                var hash = sha1.ComputeHash(asen.GetBytes(ch));
                var s = new StringBuilder();
                foreach (byte b in hash)
                    s.Append(b.ToString("x2").ToLower());

                
                return s.ToString() ;
            }


        }


    }
}
