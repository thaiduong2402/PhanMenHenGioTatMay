using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMenHenGioTatMay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        decimal dem = 0;
        void tinhdem()
        {
            dem = (numericUpDown3.Value) + (numericUpDown2.Value * 60) + (numericUpDown1.Value * 60 * 60);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 60)
            {
                numericUpDown3.Value = 0;
                numericUpDown2.Value++;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 60)
            {
                numericUpDown2.Value = 0;
                numericUpDown1.Value++;
            }
        }
        //"-s -t" + 100
        void shutdown(string thoigian)
        {
            System.Diagnostics.Process.Start("shutdown", thoigian);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            shutdown("-a");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            tinhdem();
            shutdown("-s -t " + dem);
            trangthai = 1;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            tinhdem();
            shutdown("-r -t " + dem);
            trangthai = 0;
        }
        int trangthai;

        /* void kiemtra()
         {
             if (trangthai == "shutdown")
             {
                 label4.Text = trangthai + "ing.... : " + dem.ToString();
             }
             else if (trangthai == "restart")
             {
                 label4.Text = trangthai + "ing.... : " + dem.ToString();
             }
         }*/


        string h = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            dem--;
            ThanhGio(dem);
            if (trangthai == 1)
            {
                label4.Text = "Shutdiwning..............:              " + h;
            }
            else if (trangthai == 0)
            {
                
                label4.Text = "Restarting..............:              " + h;
            }

        }
           void ThanhGio(decimal s)
        {
            while (true)
            {
                if (s > 60)
                {
                    decimal gio = 0;
                    decimal phut = Math.Floor(s / 60);
                    decimal giay = Math.Floor(s % 60);
                    if (phut > 60)
                    {
                        gio = Math.Floor(phut / 60);
                        phut = Math.Floor(phut % 60);
                    }
                    h = gio.ToString() + " Gio   " + phut.ToString() + " Phut     " + giay.ToString() + " giay";
                    break;
                }
                else 
                {
                    h = s.ToString() + " giay";
                    break;

                }
                    
            }
        }
    }
}