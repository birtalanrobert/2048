using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Random random = new Random();
        static int szam, rand_x, rand_y,lepes=1;
        static public int score = 0;
        static public int[,] matrix=new int[100,100];
        static public int n=4; //mert a 4x4 az alapertelmezett
        static public int kilep = 0;
        static public int valaszt=1;
        static public Image[] kepek1 = new Image[12];
        static public Image[] kepek2 = new Image[12];
        static public string utvonal_kep1, utvonal_kep2;
       

        public void veletlen()
        {
            szam = random.Next(1, 4096) % 2;
            rand_x = random.Next(1, 4096) % n;
            rand_y = random.Next(1, 4096) % n;
            if ((szam == 0) && (matrix[rand_x, rand_y] == 0))
                matrix[rand_x, rand_y] = 2;
            else
                if ((szam == 1) && (matrix[rand_x, rand_y] == 0)) matrix[rand_x, rand_y] = 4;
                else veletlen();
        }

        public int lepes_ellenor_bal()
        {
            lepes = 0;
                for (int i = 0; i < n-1; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if ((matrix[i, j] == 0) && (matrix[i+1, j] != 0))//rakas
                            lepes++;
                        else
                        if ((matrix[i, j] == matrix[i+1, j])&&(matrix[i,j]!=0))
                            lepes++;
                    }
            if (lepes == 0) return 0;
            else return 1;
        }

        public int lepes_ellenor_jobb()
        {
            lepes = 0;
                for (int i = n-1; i >= 1; i--)
                    for (int j = n-1; j >= 0; j--)
                    {
                        if ((matrix[i, j] == 0) && (matrix[i - 1, j] != 0))
                            lepes++;
                        else
                            if ((matrix[i, j] == matrix[i - 1, j]) && (matrix[i, j] != 0))
                                lepes++;
                    }
            if (lepes == 0) return 0;
            else return 1;
        }

        public int lepes_ellenor_fel()
        {
            lepes = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n-1; j++)
                {
                    if ((matrix[i, j] == 0) && (matrix[i, j+1] != 0))//rakas
                        lepes++;
                    else
                        if ((matrix[i, j] == matrix[i, j+1]) && (matrix[i, j] != 0))
                            lepes++;
                }
            if (lepes == 0) return 0;
            else return 1;
        }

        public int lepes_ellenor_le()
        {
            lepes = 0;
            for (int i = n-1; i >= 0; i--)
                for (int j = n-1; j >= 1; j--)
                {
                    if ((matrix[i, j] == 0) && (matrix[i, j-1] != 0))//rakas
                        lepes++;
                    else
                        if ((matrix[i, j] == matrix[i, j-1]) && (matrix[i, j] != 0))
                            lepes++;
                }
            if (lepes == 0) return 0;
            else return 1;
        }

        public void game_over()
        {
            if ((lepes_ellenor_bal() == 0) && (lepes_ellenor_jobb() == 0) &&
                (lepes_ellenor_fel() == 0) && (lepes_ellenor_le() == 0))
            {
                Form2 a = new Form2();
                a.ShowDialog();
                Hide();
                kilep = 1;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, i * 50, j * 50, 50, 50);
                    if (matrix[i, j] != 0)
                    {
                        if (matrix[i, j] == 2)
                        {
                            if(valaszt==1)
                            e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[0], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[0], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 4)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.LightYellow, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[1], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[1], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 8)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.Orange, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[2], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[2], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 16)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.DarkOrange, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[3], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[3], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 32)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.OrangeRed, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[4], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[4], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 64)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.Red, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[5], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[5], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 128)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[6], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[6], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 256)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.Gold, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[7], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[7], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 512)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.DarkGoldenrod, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[8], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[8], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 1024)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.Yellow, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[9], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[9], i * 50, j * 50, 50, 50);
                        }
                        if (matrix[i, j] == 2048)
                        {
                            if (valaszt == 1)
                            {
                                e.Graphics.FillRectangle(Brushes.Yellow, i * 50, j * 50, 50, 50);
                                e.Graphics.DrawString(matrix[i, j].ToString(), new Font("Arial", 18), Brushes.Black, i * 50, j * 50);
                            }
                            if(valaszt==2)
                                e.Graphics.DrawImage(kepek1[10], i * 50, j * 50, 50, 50);
                            if(valaszt==3)
                                e.Graphics.DrawImage(kepek2[10], i * 50, j * 50, 50, 50);
                        }
                    }

                }
            label1.Text = score.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (lepes_ellenor_bal() == 1)
            {
                for (int k = 0; k < n-1; k++)
                {
                    for (int i = 0; i < n-1; i++)
                        for (int j = 0; j < n; j++)
                            if (matrix[i, j] == 0)
                            {
                                matrix[i, j] = matrix[i + 1, j];
                                matrix[i + 1, j] = 0;
                            }
                }
                for (int i = 0; i < n-1; i++)
                    for (int j = 0; j < n; j++)
                        if (matrix[i, j] == matrix[i + 1, j])
                        {
                            matrix[i, j] = matrix[i, j] + matrix[i + 1, j];
                            score = score + matrix[i, j];
                            matrix[i + 1, j] = 0;
                        }
                for (int k = 0; k < n-1; k++)
                {
                    for (int i = 0; i < n-1; i++)
                        for (int j = 0; j < n; j++)
                            if (matrix[i, j] == 0)
                            {
                                matrix[i, j] = matrix[i + 1, j];
                                matrix[i + 1, j] = 0;
                            }
                }
                veletlen();
                pictureBox1.Refresh();
            }
            else ;
            game_over();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lepes_ellenor_jobb() == 1)
            {
                for (int k = 0; k < n-1; k++)
                {
                    for (int i = n-1; i >= 1; i--)
                        for (int j = n-1; j >= 0; j--)
                            if (matrix[i, j] == 0)
                            {
                                matrix[i, j] = matrix[i - 1, j];
                                matrix[i - 1, j] = 0;
                            }
                }
                for (int i = n-1; i >= 1; i--)
                    for (int j = n-1; j >= 0; j--)
                    {
                        if (matrix[i, j] == matrix[i - 1, j])
                        {
                            matrix[i, j] = matrix[i, j] + matrix[i - 1, j];
                            score = score + matrix[i, j];
                            matrix[i - 1, j] = 0;
                        }
                    }
                for (int k = 0; k < n-1; k++)
                {
                    for (int i = n-1; i >= 1; i--)
                        for (int j = n-1; j >= 0; j--)
                            if (matrix[i, j] == 0)
                            {
                                matrix[i, j] = matrix[i - 1, j];
                                matrix[i - 1, j] = 0;
                            }
                }
                veletlen();
                pictureBox1.Refresh();
            }
            else ;
            game_over();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lepes_ellenor_fel() == 1)
            {
                for (int k = 0; k < n-1; k++)
                {
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n-1; j++)
                            if (matrix[i, j] == 0)
                            {
                                matrix[i, j] = matrix[i, j + 1];
                                matrix[i, j + 1] = 0;
                            }
                }
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n-1; j++)
                    {
                        if (matrix[i, j] == matrix[i, j + 1])
                        {
                            matrix[i, j] = matrix[i, j] + matrix[i, j + 1];
                            score = score + matrix[i, j];
                            matrix[i, j + 1] = 0;
                        }
                    }
                for (int k = 0; k < n-1; k++)
                {
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n-1; j++)
                            if (matrix[i, j] == 0)
                            {
                                matrix[i, j] = matrix[i, j + 1];
                                matrix[i, j + 1] = 0;
                            }
                }
                veletlen();
                pictureBox1.Refresh();
            }
            else ;
            game_over();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lepes_ellenor_le() == 1)
            {
                for (int k = 0; k < n-1; k++)
                {
                    for (int i = n-1; i >= 0; i--)
                        for (int j = n-1; j >= 1; j--)
                            if (matrix[i, j] == 0)
                            {
                                matrix[i, j] = matrix[i, j - 1];
                                matrix[i, j - 1] = 0;
                            }
                }
                for (int i = n-1; i >= 0; i--)
                    for (int j = n-1; j >= 1; j--)
                    {
                        if (matrix[i, j] == matrix[i, j - 1])
                        {
                            matrix[i, j] = matrix[i, j] + matrix[i, j - 1];
                            score = score + matrix[i, j];
                            matrix[i, j - 1] = 0;
                        }
                    }
                for (int k = 0; k < n-1; k++)
                {
                    for (int i = n-1; i >= 0; i--)
                        for (int j = n-1; j >= 1; j--)
                            if (matrix[i, j] == 0)
                            {
                                matrix[i, j] = matrix[i, j - 1];
                                matrix[i, j - 1] = 0;
                            }
                }
                veletlen();
                pictureBox1.Refresh();
            }
            else ;
            game_over();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form4 a = new Form4();

            if (Form4.vissza == 1)//vissza gomb miatt
            {
                veletlen();
                veletlen();
            }

           utvonal_kep1 = "c:\\Users\\Robert\\Desktop\\2048\\kepek1\\";
           utvonal_kep2 = "c:\\Users\\Robert\\Desktop\\2048\\kepek2\\";

                    kepek1[0] = Image.FromFile(utvonal_kep1 + 1 + "kep.png");
                    kepek1[1] = Image.FromFile(utvonal_kep1 + 2 + "kep.png");
                    kepek1[2] = Image.FromFile(utvonal_kep1 + 3 + "kep.png");
                    kepek1[3] = Image.FromFile(utvonal_kep1 + 4 + "kep.png");
                    kepek1[4] = Image.FromFile(utvonal_kep1 + 5 + "kep.png");
                    kepek1[5] = Image.FromFile(utvonal_kep1 + 6 + "kep.png");
                    kepek1[6] = Image.FromFile(utvonal_kep1 + 7 + "kep.png");
                    kepek1[7] = Image.FromFile(utvonal_kep1 + 8 + "kep.png");
                    kepek1[8] = Image.FromFile(utvonal_kep1 + 9 + "kep.png");
                    kepek1[9] = Image.FromFile(utvonal_kep1 + 10 + "kep.png");
                    kepek1[10] = Image.FromFile(utvonal_kep1 + 11 + "kep.png");

                    kepek2[0] = Image.FromFile(utvonal_kep2 + 1 + "kep.jpg");
                    kepek2[1] = Image.FromFile(utvonal_kep2 + 2 + "kep.jpg");
                    kepek2[2] = Image.FromFile(utvonal_kep2 + 3 + "kep.jpg");
                    kepek2[3] = Image.FromFile(utvonal_kep2 + 4 + "kep.jpg");
                    kepek2[4] = Image.FromFile(utvonal_kep2 + 5 + "kep.jpg");
                    kepek2[5] = Image.FromFile(utvonal_kep2 + 6 + "kep.jpg");
                    kepek2[6] = Image.FromFile(utvonal_kep2 + 7 + "kep.jpg");
                    kepek2[7] = Image.FromFile(utvonal_kep2 + 8 + "kep.jpg");
                    kepek2[8] = Image.FromFile(utvonal_kep2 + 9 + "kep.jpg");
                    kepek2[9] = Image.FromFile(utvonal_kep2 + 10 + "kep.jpg");
                    kepek2[10] = Image.FromFile(utvonal_kep2 + 11 + "kep.jpg");
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            kilep = 1;
            a.Show();
            Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kilep == 0)
                Application.Exit();//kilepes
        }
    }
}
