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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        static public int kilep = 0,vissza=1;

        private void Form4_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) Form1.n = 3; //3x3
            else
                if (radioButton2.Checked == true) Form1.n = 4;//4x4
                else
                    if (radioButton3.Checked == true) Form1.n = 5;//5x5
                    else
                        if (radioButton4.Checked == true) Form1.n = 6;//6x6
                        else
                            if (radioButton5.Checked == true) Form1.n = 7;//7x7

            if (radioButton6.Checked == true) Form1.valaszt = 1;//szamok
            else
                if (radioButton7.Checked == true) Form1.valaszt = 2;//poharak
                else
                    if (radioButton8.Checked == true) Form1.valaszt = 3;//mortal kombat
            kilep = 1;
            vissza = 1;
            Form1.score = 0;
            for (int i = 0; i < Form1.n; i++)
                for (int j = 0; j < Form1.n; j++)
                    Form1.matrix[i, j] = 0;
            Form1 a = new Form1();
            a.Show();
            //Hide();
            Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kilep == 0)
                Application.Exit();//kilepes
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kilep = 1;
            vissza = 0;
            Form1 a = new Form1();
            a.Show();
            Close();
        }
    }
}
