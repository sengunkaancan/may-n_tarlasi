using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int hak = 10;
        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] mayinlar = new int[20];
            int hak =10;

            for (int i = 0; i < 20; i++)
            {

                int sayi =rnd.Next(1,101);
                if (!mayinlar.Contains(sayi))
                {
                    mayinlar[i]= sayi;
                }
                else
                {
                    i--;
                }

            }



            this.Size = new Size(340,360);
            for (int i = 1; i < 101; i++)
            {

                PictureBox pcb = new PictureBox();
                pcb.Width = 30;
                pcb.Height = 30;
                //pcb.size = new (30,30);
                pcb.Name = "pcb" + i.ToString();
                //pcb.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                pcb.BackColor = Color.Gray;

                if (mayinlar.Contains(i))
                {
                    pcb.Tag = true;
                }

                pcb.Click += Pcb_Click;


                flowLayoutPanel1.Controls.Add(pcb);
                pcb.Margin = new Padding(1);


                



            }



        }

        private void Pcb_Click(object sender, EventArgs e)
        {
            PictureBox pcb = (PictureBox) sender;
            
            if ( !(pcb.Tag is true) && (pcb.Tag is null))
            {
                pcb.BackColor = Color.White;
                

            }
            else
            {
                pcb.BackColor = Color.Black;
                hak--;
            }

            if (hak==0)
            {
                MessageBox.Show("game is ended :(");
                timer1.Start();
                
            }



        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Text = this.Size.ToString();
            //timer1.Start();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;




            foreach (Control item in flowLayoutPanel1.Controls)
            {
                if (item is PictureBox)
                {
                    if (item.Tag!=null)
                    {
                        item.BackColor = Color.Black;

                    }

                    else
                    {

                        item.BackColor = Color.White;
                        //item.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    }

                    //item.BackColor=  Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }
            }

        }
    }
}
