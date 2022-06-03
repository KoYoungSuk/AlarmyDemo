using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmyDemo
{
    public partial class Form1 : Form
    {
        Boolean setting = false;
        SoundPlayer alarmp;
        int time = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            if(setting == true)
            {
                time = time - 1;
                label8.Text = time + "초";
                if(time <= 0)
                {
                    setting = false;
                    time = 0;
                    MessageBox.Show("알람 가동");
                    if(label6.Text == "Default")
                    {
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                    }
                    alarmp = new SoundPlayer(label6.Text);
                    alarmp.PlayLooping();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String file = null;
            openFileDialog1.InitialDirectory = "C:\\";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                label6.Text = file;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String file_path = label6.Text;
            if(file_path == "Default")
            {
                Console.Beep();
            }
            else
            {
                SoundPlayer sp = new SoundPlayer(file_path);
                sp.Play();
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String file_path = label6.Text;
            SoundPlayer sp = new SoundPlayer(file_path);
            sp.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int hour;
            int min;
            hour = (int)numericUpDown1.Value;
            min = (int)numericUpDown2.Value;
            for(; hour>=1; hour--)
            {
                time = time + 3600; 
            }
            for(; min>=1; min--)
            {
                time = time + 60; 
            }
            setting = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            alarmp.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setting = false;
            label8.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
