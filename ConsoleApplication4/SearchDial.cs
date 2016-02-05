using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication4
{
    public partial class SearchDial : Form
    {
        private LinkedList<victim> l; 
        public SearchDial()
        {
            InitializeComponent();
        }

        public SearchDial(LinkedList<victim> l)
        {
            InitializeComponent();
            this.l = l; 
        }

        private async void searchB_Click(object sender, EventArgs e)
        {   if(l.Count ==0 ) return ; 
            String search = searched.Text   ;
            String path = pathText.Text ; 
            Task<Msg>[] tasks = new Task<Msg>[l.Count];
            int i = 0; 
            foreach (var v in l) {
                tasks[i] = v.getSearchResult(path, search); 
            }
            try
            {
                Msg[] msg = await Task.WhenAll<Msg>(tasks);

                foreach (var item in msg)
                {
                    addEntry(item.b, item.a);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void addEntry(string name , String path ) {


            this.tableLayoutPanel2.RowCount++;
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.AutoSize) ) ;
            Label nameL = new Label();
            nameL.AutoSize = true;
            nameL.Dock = System.Windows.Forms.DockStyle.Fill;
            nameL.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameL.ForeColor = System.Drawing.Color.WhiteSmoke;
            
            nameL.Size = new System.Drawing.Size(165, 30);
            nameL.TabIndex = 0;
            nameL.Text = name;
            nameL.TextAlign = System.Drawing.ContentAlignment.TopLeft;


            Label pathL = new Label();
            pathL.AutoSize = true;
            pathL.Dock = System.Windows.Forms.DockStyle.Fill;
            pathL.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pathL.ForeColor = System.Drawing.Color.WhiteSmoke;
            
            pathL.Size = new System.Drawing.Size(165, 30);
            pathL.TabIndex = 0;
            pathL.Text = path;
            pathL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;


            this.tableLayoutPanel2.Controls.Add(nameL);
            this.tableLayoutPanel2.Controls.Add(pathL);

        }
    }
}
