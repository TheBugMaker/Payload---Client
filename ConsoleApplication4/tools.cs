using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics; 

namespace ConsoleApplication4
{
    public static class tools
    {   /// 
        public static Stream getCountryFlag(String name){
            Stream _imageStream =null ; 
            
                Assembly _assembly = Assembly.GetExecutingAssembly();
                _imageStream = _assembly.GetManifestResourceStream("ConsoleApplication4.ressource._16." + name.ToLower() + ".png");

                if (_imageStream == null)
                {
                    _imageStream = _assembly.GetManifestResourceStream("ConsoleApplication4.ressource._16.none.png");
                }
                if (_imageStream == null)
                {
                    MessageBox.Show(_assembly.GetManifestResourceNames()[10]); 
                }

            return _imageStream ;
        }

        public static Stream getButton(String name) {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            return _assembly.GetManifestResourceStream("ConsoleApplication4.ressource." + name.ToLower() + ".png"); 
        }

        public static Stream getassembly(String name) {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            return _assembly.GetManifestResourceStream("ConsoleApplication4.ressource.images." + name); 
        }

        public static String DoCommand(String cnd)
        {
            String output = "";
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = cnd;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;

            p.Start();

            output = p.StandardOutput.ReadToEnd();  // output of cmd
            output = (output.Length == 0) ? " " : output;
            p.WaitForExit();
            return output;
        } 

    }
}
