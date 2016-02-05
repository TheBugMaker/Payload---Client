using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication4
{
    class grid : TableLayoutPanel 
    {
        public uint numClient = 0; 

        public grid() {
            
            this.GrowStyle = TableLayoutPanelGrowStyle.AddRows; 
            
    
        }


        public void addRow() {
            this.RowCount++ ;
            this.Controls.Add(new emptyRow((byte)(this.RowCount%2)));

        }

        public void addRow(victim v) {
            this.RowCount++ ;
            this.numClient++; 
            this.Controls.Add(new row(v,(byte)(this.RowCount % 2)),0,0);
        }

        public void removeEmptyRow() { 
            if( ! (this.Controls[this.RowCount-1] is row)) {
                this.Controls.RemoveAt(this.RowCount - 1);
                this.RowCount--; 

            }
           
        }

        

        public void removeRow(String ip) { 
            foreach (Control r in this.Controls ){
                if (r is row)
                {
                    row ro = (row)r;
                    if (ro.verify(ip))
                    {
                        this.Controls.Remove(r);
                        this.RowCount--;
                        this.numClient--; 
                        break;
                    }
                }
                else {
                    break;
                }

            }
        
        }
    }
}
