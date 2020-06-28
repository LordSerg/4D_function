using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4D_function
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        d4[] a;
        int k = 5000;
        Bitmap b;
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            d4.reset();//инизиализируем базис
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            a = new d4[k];
            //строим функцию
            int q = 0;

            for (int i = 0; i < k; i++)
            {
                a[i] = new d4(300 * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
                    300 * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
                    300 * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
                    300 * Math.Cos(i * Math.PI / 180));
            }
            pictureBox1.Image = b;
            timer1.Enabled = true;
            timer1.Interval = 1;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            d4.reset();
            d4.rotate(trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value, trackBar5.Value, trackBar6.Value);
            d4 zero = new d4(0, 0, 0, 0);
            for (int i = 0; i < k; i++)
            {
                d4.draw_point(a[i], pictureBox1, g);
                //d4.draw_line(a[i], a[i+k/4], pictureBox1, g);
                //d4.draw_line(a[i+k/4], a[i + k / 2], pictureBox1, g);
                //d4.draw_line(a[i + k / 2], a[i + 3*k / 4], pictureBox1, g);
            }
            draw_coordinate_axis();
            pictureBox1.Image = b;
        }

        private void Button1_Click(object sender, EventArgs e)
        {//поворо пространства_кнопка
            if (panel2.Height < 40)//35-285
            {//открываем
                if (panel3.Height > 40)
                {//если соседнее меню было развернуто, то сварачиваем его
                    for (int i = 0; i < 250; i += 5)
                    {
                        if (panel3.Height > 36)
                        {
                            panel3.Height -= 5;
                        }
                        panel3.Location = new Point(panel3.Location.X, panel3.Location.Y + 5);
                        panel2.Height++;
                    }
                }
                else
                {
                    for (int i = 0; i < 250; i += 5)
                    {
                        panel3.Location = new Point(panel3.Location.X, panel3.Location.Y + 5);
                        panel2.Height += 5;
                    }
                }
            }
            else
            {//закрываем
                for (int i = 0; i < 250; i += 5)
                {
                    panel3.Location = new Point(panel3.Location.X, panel3.Location.Y - 5);
                    panel2.Height -= 5;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {//масштаб по осям_кнопка

        }
        void draw_coordinate_axis()
        {
            d4 x, y, z, t,zero;
            x = new d4(100, 0, 0, 0);
            y = new d4(0, 100, 0, 0);
            z = new d4(0, 0, 100, 0);
            t = new d4(0, 0, 0, 100);
            zero = new d4(0, 0, 0, 0);
            
            d4.draw_line_color(zero, x, Color.Red, pictureBox1, g);
            d4.draw_line_color(zero, y, Color.Blue, pictureBox1, g);
            d4.draw_line_color(zero, z, Color.Green, pictureBox1, g);
            d4.draw_line_color(zero, t, Color.Yellow, pictureBox1, g);
        }
    }
}
