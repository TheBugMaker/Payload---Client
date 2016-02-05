using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace ConsoleApplication4
{
    public partial class file_nav : Form
    {
        private Writer wr; private Listener ls; 
        
        public file_nav(Writer wr , Listener ls)
        {
            this.wr = wr; this.ls = ls; 

            wr.sendString("08");

             
            String list = ls.navSettingsOut();
            

            list = list.TrimEnd('\0');
            String[] drives = list.Split('\n');
            InitializeComponent();
            int i=0;

            while ( i < drives.Length && drives[i]!="<" )
            {

                listBox1.Items.Add(drives[i]); i++;
            }
            
            i++;
            textBox1.Text = drives[i];
            i += 2;
            listView1.Items.Add("..").Name="d";
            while (i < drives.Length && drives[i] != "<")
            {
                if (drives[i].Length>1) listView1.Items.Add(drives[i]).Name = "d";
                i++;
            }
            
            i += 2;
            while (i < drives.Length && drives[i] != "<")
            {
                if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "f";
                i++;
            }


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void visit_Click(object sender, EventArgs e)
        {
            
            wr.sendString("92" + textBox1.Text);

            
             
            listView1.Items.Clear();

            String list = ls.navSettingsOut();
            list = list.TrimEnd('\0');
            String[] drives = list.Split('\n');
            int i = 0;
            listView1.Items.Add("..").Name = "d";
            while (i < drives.Length && drives[i] != "<")
            {
                if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "d";
                i++;
            }

            i += 2;
            while (i < drives.Length && drives[i] != "<")
            {
                if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "f";
                i++;
            }
            if (i < drives.Length)textBox1.Text = drives[i+1];

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null) {
                String text = listView1.SelectedItems[0].Text;
                if (listView1.SelectedItems[0].Name == "d")
                {
                    
                    textBox1.Text = textBox1.Text.TrimEnd(Path.DirectorySeparatorChar);


                    textBox1.Text += Path.DirectorySeparatorChar + text;

                   
                    wr.sendString("93" + text);

                    
                    listView1.Items.Clear();

                    String list = ls.navSettingsOut();
                    list = list.TrimEnd('\0');
                    String[] drives = list.Split('\n');
                    int i = 0;
                    listView1.Items.Add("..").Name = "d";
                    while (i < drives.Length && drives[i] != "<")
                    {
                        if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "d";
                        i++;
                    }

                    i += 2;
                    while (i < drives.Length && drives[i] != "<")
                    {
                        if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "f";
                        i++;
                    }
                    if (i < drives.Length) textBox1.Text = drives[i + 1];

                }
                else if (listView1.SelectedItems[0].Name == "f") {
                    get_file(textBox1.Text+Path.DirectorySeparatorChar+text);
                }
              }
        
            }
        async private void get_file(String path )
        {

            wr.sendString("94" + path);

            int timeout = 10000;
            while (timeout > 0 && progressBar1.Value < 100)
            {
                if (progressBar1.Value != ls.getProgesspercent()) { timeout = 5000; }
                progressBar1.Value = ls.getProgesspercent();
                await Task.Delay(200);
                timeout -= 200;
            }
            if (progressBar1.Value == 100)
            {
                MessageBox.Show("File Transfered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Unable to Transfer File", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            progressBar1.Value = 0;
                
        }

               async private void listBox1_DoubleClick(object sender, EventArgs e)
               {
                   if (listBox1.SelectedItems != null)
                   {
                       String text = listBox1.SelectedItems[0].ToString();
                       
                          


                           textBox1.Text =text;

                         
                           wr.sendString("93" + text);

                           listView1.Items.Clear();

                           String list = await Task.Factory.StartNew(()=>ls.navSettingsOut() ) ;
                           list = list.TrimEnd('\0');
                           String[] drives = list.Split('\n');
                           int i = 0;
                           listView1.Items.Add("..").Name = "d";
                           while (i < drives.Length && drives[i] != "<")
                           {
                               if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "d";
                               i++;
                           }

                           i += 2;
                           while (i < drives.Length && drives[i] != "<")
                           {
                               if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "f";
                               i++;
                           }
                           if (i < drives.Length) textBox1.Text = drives[i + 1];

                       
                      
                   }
               }

               private void listView1_DragDrop(object sender, DragEventArgs e)
               {
                   string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                   progressBar1.Maximum = fileList.Length;
                   foreach (String file in fileList) {
                       progressBar1.Increment(1);
                       if (File.Exists(file)) {
                           
                           UTF8Encoding enc = new UTF8Encoding();
                           String[] name = file.Split(Path.DirectorySeparatorChar);
                           
                           sending.Visible = true;
                           sending.Text="Sending "+name[name.Length-1]+" ..." ;

                           //wr.sendString("95" + name[name.Length-1]);  depreched :v 

                           fileTransfer ft = new fileTransfer(wr, ls);
                           ft.add(file);
                           ft.transfer();                          
                           listView1.Items.Add(name[name.Length - 1]).Name="f";
                       }
                   } sending.Visible = false;
                   progressBar1.Value = 0;
                   MessageBox.Show("Sending completed");
               }

               private void listView1_DragEnter(object sender, DragEventArgs e)
               {
                  
                   e.Effect = DragDropEffects.All;

               }

               private void delete_Click(object sender, EventArgs e)
               {
                   if (listView1.CheckedItems.Count > 0)
                   {
                       progressBar1.Maximum = listView1.CheckedItems.Count;
                       sending.Visible = true;
                       for (int i = 0; i < listView1.CheckedItems.Count; i++)
                       {
                           sending.Text = "Deleting " + listView1.CheckedItems[i].Text;

                           UTF8Encoding enc = new UTF8Encoding();
                           wr.sendString("96" + listView1.CheckedItems[i].Text);
                           listView1.CheckedItems[i].Remove();
                           progressBar1.Increment(0);
                       }
                       progressBar1.Value = 0;
                       sending.Visible = false;
                       MessageBox.Show("items has benn deleted");

                   }
                   else
                   {
                       MessageBox.Show("No items have been checked");
                   }
               } 

               private void Open_Click(object sender, EventArgs e)
               {
                   if (listView1.CheckedItems.Count > 0)
                   {
                       for (int i = 0; i < listView1.CheckedItems.Count; i++)
                       {
                           if (listView1.CheckedItems[i].Name == "f")
                           {
                              
                               wr.sendString("97" + listView1.CheckedItems[i].Text);
                           }
                       }
                   }
                   else {
                       MessageBox.Show("No Items have benn checked");
                   }
               }

              async private void search_Click(object sender, EventArgs e)
               {
                   String search = searchBox.Text; 

                   if (search.Length >0){
                       wr.sendString ("98" + search );

                       listView1.Items.Clear();

                       String list = await Task.Factory.StartNew(() => ls.navSettingsOut());
                       MessageBox.Show(list); 
                       list = list.TrimEnd('\0');
                       String[] drives = list.Split('\n');
                       int i = 0;
                       listView1.Items.Add("..").Name = "d";
                       while (i < drives.Length && drives[i] != "<")
                       {
                           if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "d";
                           i++;
                       }

                       i += 1;
                       while (i < drives.Length )
                       {
                           if (drives[i].Length > 1) listView1.Items.Add(drives[i]).Name = "f";
                           i++;
                       }


                   }

               }

               private void panel1_Paint(object sender, PaintEventArgs e)
               {

               }

               private void panel9_Paint(object sender, PaintEventArgs e)
               {

               }

              

              

             

               
              
            

        
    }
}
