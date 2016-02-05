using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApplication4
{
    public static class internet
    {
        public static String countryCode(string ip)
        {string result = "TN" ; 
            try
            {
                String Url = "http://api.hostip.info/country.php?ip=" + ip;
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
                myRequest.Method = "GET";
                myRequest.Timeout = 3000; 
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();

            }
            catch (Exception)
            {
                
                
            }
            return result;
        }

    }
}
