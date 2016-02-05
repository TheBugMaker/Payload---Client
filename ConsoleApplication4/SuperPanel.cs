using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml; 

namespace ConsoleApplication4
{
    public partial class SuperPanel : UserControl
    {
        public SuperPanel(String name)
        {
            InitializeComponent();
            pagesList.SelectedIndex = 0; 
            this.Dock = DockStyle.Fill;
            this.Tag = name; 
            if (File.Exists(name)) {
                XmlReaderSettings readerSettings = new XmlReaderSettings();
                readerSettings.IgnoreComments = false;
                using (XmlReader reader = XmlReader.Create(name, readerSettings))
                {
                    String date = "" ; 
                    while (reader.Read()) {
                        switch (reader.NodeType) { 
                            case XmlNodeType.Element :
                                String nom = reader.Name;
                                if (!nom.Equals("doc")) {
                                    reader.Read(); 
                                    if (!pagesList.Items.Contains(nom))
                                    {
                                        pagesList.Items.Add(nom);
                                        addpage(nom);

                                        if (date.Length > 0) {
                                            addTextToPage(nom, date, 1);
                                            date = ""; 
                                        }
                                        addTextToPage(nom, reader.Value, 0);

                                    }
                                    else {
                                        if (date.Length > 0)
                                        {
                                            addTextToPage(nom, date, 1);
                                            date = "";
                                        }
                                        addTextToPage(nom, reader.Value, 0);
                                    }
                                }
                                break;
                            case XmlNodeType.Comment:
                                date = reader.Value; 
                                break;
                        }
                              
                        

                    }
                }
            
            }

        }


        private void addpage(String tag)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Visible = false;
            flp.Dock = DockStyle.Fill;
            flp.BackColor = Color.FromArgb(28);
            flp.Tag = tag ;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Padding = new Padding(10); 
           
            pagesHolder.Controls.Add(flp);
             
        }


        
        private void addTextToPage(String tag , String text , byte type) {

            FlowLayoutPanel page = null; 
            foreach (FlowLayoutPanel c in pagesHolder.Controls)
            {
                if (((String)c.Tag).Equals(tag)) {
                    page = c;
                    break; 
                }
            }

            if (page != null) {
                Label l = new Label();
                Label l2 = new Label(); 
                l.Text = text;
                l2.Text = text;
                l.Margin = new Padding(0);
                l.Padding = new Padding(0);
                
                l2.Padding = new Padding(0);
                l2.Margin = new Padding(0);
                


                switch (type) {
                    case 0:
                        l.Font = new Font("Pt Serif", 8);
                        l.ForeColor = Color.AntiqueWhite;
                        l.Tag = "0";
                        l2.Font = new Font("Pt Serif", 8);
                        l2.ForeColor = Color.AntiqueWhite;         
                        l2.Tag = "0"; 
                        break; 
                    case 1 :
                        l.Font = new Font("Lucida Console", 8);
                        l.ForeColor = Color.FromArgb(140, 197, 200);
                        l.Width = 200;
                        l.Tag = "1"; 
                        l2.Font = new Font("Lucida Console", 8);
                        l2.ForeColor = Color.FromArgb(140, 197, 200);
                        l2.Width = 200;
                        l2.Tag = "1"; 
                        break; 
                }

                
               
                page.Controls.Add(l2);
                allPage.Controls.Add(l);

                
            }

        }

        private void pagesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String page = (String)pagesList.SelectedItem; 
            foreach(FlowLayoutPanel fp in pagesHolder.Controls){
                if (((String)fp.Tag).Equals(page))
                {
                    fp.Visible = true;
                }
                else {
                    fp.Visible = false; 
                }
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            bool visible = ((CheckBox)sender).Checked ; 
          
               foreach(FlowLayoutPanel c in pagesHolder.Controls){
                   foreach(Control l in c.Controls){
                        if(((String)l.Tag).Equals("1")){
                            l.Visible = visible; 
                        }
                    }
               }
            
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
            {
                foreach (FlowLayoutPanel c in pagesHolder.Controls)
                {
                    foreach (Control l in c.Controls)
                    {
                        Label la = l as Label;
                        if (la != null && ((String)la.Tag) == "0")
                        {
                            la.Text = la.Text.Replace(" CTRL +", "");
                            la.Text = la.Text.Replace(" ALT +", "");
                            la.Text = la.Text.Replace(" ALTGR +", "");

                        }
                    }
                }

            }
            else { 
                // TODO : somehow return deleted strings  :( 
            }
        }

        
    }
}
