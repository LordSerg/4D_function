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
        int k = 7200;
        Bitmap b;
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            d4.reset();//инизиализируем базис
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            a = new d4[k*10];
            //строим функцию
            int q = 0;
            panel2.Height = 35;
            panel3.Height = 35;
            panel4.Height = 35;
            panel3.Location = new Point(panel3.Location.X, 10 + panel2.Height + panel2.Location.Y);
            panel4.Location = new Point(panel4.Location.X, 10 + panel3.Height + panel3.Location.Y);
            
            //for (int i = 0; i < k; i++)
            //{
            //    a[i] = new d4(300 * Math.Cos(i * Math.PI / 180) * Math.Cos(i * Math.PI / 180) * Math.Cos(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180) * Math.Cos(i * Math.PI / 180) * Math.Cos(i * Math.PI / 180),
            //        300 * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Sin(i * Math.PI / 180));
            //    /*
            //    a[i] = new d4(300 * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180));
                
            //    a[i] = new d4(300 * Math.Sin(i * Math.PI / 180) * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180) * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180) * Math.Cos(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180)); */
            //    /*
            //    a[i] = new d4(300 * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Sin(i * Math.PI / 180));*/
            //    /*
            //    a[i] = new d4(300 * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180) * Math.Sin(i * Math.PI / 180),
            //        300 * Math.Cos(i * Math.PI / 180));*/
            //}
            pictureBox1.Image = b;
            timer1.Enabled = true;
            timer1.Interval = 1;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.LightGoldenrodYellow);
            //d4.reset();
            d4.rotate(trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value, trackBar5.Value, trackBar6.Value);
            //d4 zero = new d4(0, 0, 0, 0);
            if(a[0]!=null)
            for (int i = 0; i < k; i++)
            {
                /*if (Math.Abs(a[i].X) < 2000 && Math.Abs(a[i].Y) < 2000 && Math.Abs(a[i].Z) < 2000 && Math.Abs(a[i].T) < 2000)
                    d4.draw_line(a[i],a[i+1], pictureBox1, g);*/

                if (Math.Abs(a[i].X) < 2000 && Math.Abs(a[i].Y) < 2000 && Math.Abs(a[i].Z) < 2000 && Math.Abs(a[i].T) < 2000)
                    d4.draw_point(a[i], pictureBox1, g);

                //d4.draw_line(a[i], a[i+k/4], pictureBox1, g);
                //d4.draw_line(a[i+k/4], a[i + k / 2], pictureBox1, g);
                //d4.draw_line(a[i + k / 2], a[i + 3*k / 4], pictureBox1, g);
            }
            d4.draw_basis(pictureBox1, g);
            pictureBox1.Image = b;
        }

        private void Button1_Click(object sender, EventArgs e)
        {//поворот пространства_кнопка

            if (panel2.Height < 40)//35-285
            {//открываем
                panel2.Height = 285;
                panel3.Height = 35;
                panel3.Location = new Point(panel3.Location.X, 10 + panel2.Height + panel2.Location.Y);
                panel4.Height = 35;
                panel4.Location = new Point(panel4.Location.X, 10 + panel3.Height + panel3.Location.Y);
                if(checkBox1.Checked)
                    Read_functions();
                //if (panel3.Height > 40)
                //{//если соседнее меню было развернуто, то сварачиваем его
                //    for (int i = 0; i < 250; i += 5)
                //    {
                //        if (panel3.Height > 36)
                //        {
                //            panel3.Height -= 5;
                //        }
                //        panel3.Location = new Point(panel3.Location.X, panel3.Location.Y + 5);
                //        panel2.Height++;
                //    }
                //}
                //else if(panel4.Height > 40)
                //{
                //    for (int i = 0; i < 250; i += 5)
                //    {
                //        if (panel4.Height > 36)
                //        {
                //            panel4.Height -= 5;
                //        }
                //        panel4.Location = new Point(panel3.Location.X, panel3.Location.Y + 5);
                //        panel2.Height++;
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i < 250; i += 5)
                //    {
                //        panel3.Location = new Point(panel3.Location.X, panel3.Location.Y + 5);
                //        panel2.Height += 5;
                //    }
                //}
            }
            else
            {//закрываем
                panel2.Height = 35;
                panel3.Height = 35;
                panel3.Location = new Point(panel3.Location.X, 10 + panel2.Height + panel2.Location.Y);
                panel4.Height = 35;
                panel4.Location = new Point(panel4.Location.X, 10 + panel3.Height + panel3.Location.Y);
                //for (int i = 0; i < 250; i += 5)
                //{
                //    panel3.Location = new Point(panel3.Location.X, panel3.Location.Y - 5);
                //    panel2.Height -= 5;
                //}
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {//масштаб по осям_кнопка
            if (panel3.Height < 40)//35-200
            {//открываем
                panel2.Height = 35;
                panel3.Height = 200;
                panel4.Height = 35;
                panel3.Location = new Point(panel3.Location.X, 10 + panel2.Height + panel2.Location.Y);
                panel4.Location = new Point(panel4.Location.X, 10 + panel3.Height + panel3.Location.Y);
                if(checkBox1.Checked)
                    Read_functions();
            }
            else
            {//закрываем
                panel2.Height = 35;
                panel3.Height = 35;
                panel4.Height = 35;
                panel3.Location = new Point(panel3.Location.X, 10 + panel2.Height + panel2.Location.Y);
                panel4.Location = new Point(panel4.Location.X, 10 + panel3.Height + panel3.Location.Y);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (panel4.Height < 40)//35-305
            {//открываем
                panel2.Height = 35;
                panel3.Height = 35;
                panel4.Height = 305;
                panel3.Location = new Point(panel3.Location.X, 10 + panel2.Height + panel2.Location.Y);
                panel4.Location = new Point(panel4.Location.X, 10 + panel3.Height + panel3.Location.Y);
                timer1.Enabled = false;
                pictureBox1.BackColor = Color.White;
                g.Clear(Color.White);
            }
            else
            {//закрываем
                panel2.Height = 35;
                panel3.Height = 35;
                panel4.Height = 35;
                panel3.Location = new Point(panel3.Location.X, 10 + panel2.Height + panel2.Location.Y);
                panel4.Location = new Point(panel4.Location.X, 10 + panel3.Height + panel3.Location.Y);
                timer1.Enabled = true;
                Read_functions();
            }
        }

        //чтение функций:
        static int[] convert_to_function(string s)
        {
            int[] a = new int[s.Length];
            int length = s.Length, k1 = 0;
            char[] c = new char[s.Length];
            for (int i = 0; i < length; i++)
                c[i] = s[i];
            bool b = false;
            int breck = -100;
            for (int i = 0; i < s.Length; i++)
            {
                if (c[i] == ' ')
                {
                    k1++;
                    length--;
                }
                else if (c[i] == 'k')
                {
                    a[i - k1] = -1;
                    b = false;
                }
                else if (c[i] == '+')
                {
                    a[i - k1] = -2;
                    b = false;
                }
                else if (c[i] == '-')
                {
                    a[i - k1] = -3;
                    b = false;
                }
                else if (c[i] == '*')
                {
                    a[i - k1] = -4;
                    b = false;
                }
                else if (c[i] == '/')
                {
                    a[i - k1] = -5;
                    b = false;
                }
                else if (c[i] == '^')
                {
                    a[i - k1] = -6;
                    b = false;
                }
                else if (c[i] == 'c' || c[i] == 'C')//тригонометрические функции
                {//косинус или котангенс
                    length -= 2;
                    b = false;
                    if (c[i + 1] == 'o')
                    {//косинус cos
                        a[i - k1] = -7;
                    }
                    else if (c[i + 1] == 't')
                    {//котангенс ctg
                        a[i - k1] = -10;
                    }
                    i += 2;
                    k1 += 2;
                }
                else if (c[i] == 's' || c[i] == 'S')
                {//синус sin
                    b = false;
                    length -= 2;
                    a[i - k1] = -8;
                    i += 2;
                    k1 += 2;
                }
                else if (c[i] == 't' || c[i] == 'T')
                {//тангенс
                    b = false;
                    if (c[i + 1] == 'g')//разновидности написания
                    {//tg
                        length--;
                        a[i - k1] = -9;
                        i++;
                        k1++;
                    }
                    else if (c[i + 1] == 'a')
                    {//tan
                        length -= 2;
                        a[i - k1] = -9;
                        i += 2;
                        k1 += 2;
                    }
                }
                else if (c[i] == '(')
                {
                    b = false;
                    a[i - k1] = breck;
                    breck--;
                }
                else if (c[i] == ')')
                {
                    b = false;
                    breck++;
                    a[i - k1] = breck;
                }
                else if (c[i] >= '0' && c[i] <= '9')
                {
                    if (b == false)
                    {
                        a[i - k1] = Convert.ToInt32(c[i] - '0');
                        b = true;
                    }
                    else
                    {
                        k1++;
                        a[i - k1] *= 10;
                        a[i - k1] += Convert.ToInt32(c[i] - '0');
                        length--;
                    }
                }
            }
            int[] a1 = new int[length];
            for (int i = 0; i < length; i++)
                a1[i] = a[i];
            return a1;
        }

        double f(double x, int[] n, int i_start, int i_end)
        {
            double answer = 0;
            if (i_start < 0)
            {//если первым действием - отрицательное число, например: -5+4х, то
                //"-" в данном случае - действие: 0-5
                answer = 0;
            }
            else if (i_start == i_end)
            {
                if (n[i_start] == -1)
                    answer = x;
                else
                    answer = n[i_start];
            }
            else if (n[i_start] <= -100 && n[i_end] <= -100 && n[i_end] == n[i_start] && min(n, n[i_end], i_start + 1, i_end - 1))
            {//если пришла функция в скобочках,
                answer = f(x, n, i_start + 1, i_end - 1);//то обкусываем их
            }
            else
            {
                int max = -50, imax = i_start;
                for (int i = i_start; i <= i_end; i++)
                {//поиск последнего действия
                    if (n[i] <= -100)
                    {//игнорируем скобочки
                        int j = i + 1;
                        while (n[i] != n[j])
                        {
                            j++;
                        }
                        i = j;
                    }
                    else if (n[i] < -1 && n[i] > max)
                    {
                        max = n[i];
                        imax = i;
                    }
                }
                if (max == -2)
                    answer = f(x, n, i_start, imax - 1) + f(x, n, imax + 1, i_end);
                else if (max == -3)
                    answer = f(x, n, i_start, imax - 1) - f(x, n, imax + 1, i_end);
                else if (max == -4)
                    answer = f(x, n, i_start, imax - 1) * f(x, n, imax + 1, i_end);
                else if (max == -5)
                    answer = f(x, n, i_start, imax - 1) / f(x, n, imax + 1, i_end);
                else if (max == -6)
                    answer = Math.Pow(f(x, n, i_start, imax - 1), f(x, n, imax + 1, i_end));
                else if (max == -7)
                    answer = Math.Cos(f(x, n, imax + 1, i_end));
                else if (max == -8)
                    answer = Math.Sin(f(x, n, imax + 1, i_end));
                else if (max == -9)
                    answer = Math.Tan(f(x, n, imax + 1, i_end));
                else if (max == -10)
                    answer = 1 / Math.Tan(f(x, n, imax + 1, i_end));
            }
            return answer;
        }
        bool min(int[] a, int m, int start, int end)
        {//есть ли в просматриваемых скобочках закрывающиеся скобочки с таким же индексом
            int i = start;
            while (i <= end)
            {
                if (m == a[i])
                    return false;
                i++;
            }
            return true;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                Read_functions();
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Read_functions();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Read_functions();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Read_functions();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Read_functions();
        }
        void Read_functions()
        {
            int[] f1 = convert_to_function(textBox1.Text);
            int[] f2 = convert_to_function(textBox2.Text);
            int[] f3 = convert_to_function(textBox3.Text);
            int[] f4 = convert_to_function(textBox4.Text);
            double x, y, z, t;
            for (double i = 0; i < k; i+=0.1)
            {
                x = f(i - k / 20, f1, 0, f1.Length - 1);
                y = f(i - k / 20, f2, 0, f2.Length - 1);
                z = f(i - k / 20, f3, 0, f3.Length - 1);
                t = f(i - k / 20, f4, 0, f4.Length - 1);
                a[(int)(Math.Round(i*10))] = new d4(x, y, z, t);
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar5.Value.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar6.Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            d4.reset();
        }
    }
}
