using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _2048
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public string utvonal;
        static int kilep = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "insert into jatekosok (Nev,Eredmeny) values (\""+textBox1.Text+"\","+Form1.score+")";
            cmd.ExecuteNonQuery();
            kilep = 1;
            Form3 a = new Form3();
            a.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             utvonal = "c:\\Users\\Robert\\Desktop\\2048\\highscore.accdb ";
            String connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+utvonal;
            con = new OleDbConnection(connect);
            con.Open();
            cmd = con.CreateCommand();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kilep == 0)
                Application.Exit();//kilepes
        }
    }
}
