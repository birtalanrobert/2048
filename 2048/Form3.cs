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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        static int kilep = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.n; i++)
                for (int j = 0; j < Form1.n; j++)
                    Form1.matrix[i, j] = 0;
            Form1.score = 0;
            kilep = 1;
            Form1 a = new Form1();
            a.ShowDialog();
            Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string utvonal ="c:\\Users\\Robert\\Desktop\\2048\\highscore.accdb ";
            String connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + utvonal;
            con = new OleDbConnection(connect);
            con.Open();
            cmd = con.CreateCommand();

            listView1.Items.Clear();
            cmd.CommandText = "select * from jatekosok order by Eredmeny desc";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem sor = new ListViewItem();
                sor.Text = dr["ID"].ToString();
                sor.SubItems.Add(dr["Nev"].ToString());
                sor.SubItems.Add(dr["Eredmeny"].ToString());
                listView1.Items.Add(sor);
            }
            dr.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kilep == 0)
                Application.Exit();//kilepes
        }
    }
}
