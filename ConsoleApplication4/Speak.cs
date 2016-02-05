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
    public partial class Speak : Form
    {
        Writer wr; Listener ls;

        private bool num1 = true;
        private bool num2 = true; 
        public Speak(Writer wr , Listener ls)
        {   this.wr = wr ; 
            this.ls = ls ; 
            InitializeComponent();

            if(!ls.checkSpeak())wr.sendString("i7"); // initialise liste 

            String[] voices = ls.VoicesOut().Split('\0'); 
            foreach(String a in voices){
                if (a.Length != 0) {
                    comboBox1.Items.Add(a); 
                }
            }
            wr.sendString("e7");
            String []Settings = ls.speakSettingsOut().Split('\0');
            numericUpDown1.Value = int.Parse(Settings[2]);
            numericUpDown2.Value = int.Parse(Settings[1]);
            comboBox1.SelectedItem = Settings[1]; 
        }

        private void Speak_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            wr.sendString("07" + textBox1.Text);
            textBox1.Text = "";
        }

        async private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (num1) {
                num1 = false; 
                await Task.Delay(1000);
                wr.sendString("r7"+numericUpDown1.Value);
                num1 = true; 
            }
        }

       async private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (num2)
            {
                num2 = false;
                await Task.Delay(1000);
                wr.sendString("v7" + numericUpDown2.Value);
                num2 = true;
            }

        }

       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
       {
           wr.sendString("s7"+comboBox1.SelectedItem.ToString ()); 
       }
    }
}
