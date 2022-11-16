using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int u = int.Parse(textBox1.Text);
            dataGridView1.Rows.Add(u);
            for (int i = 0; i < u; i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[1].Value = "u" + (i + 1);
            }
            int w = int.Parse(textBox2.Text);
            dataGridView2.Rows.Add(w);
            for (int i = 0; i < w; i++)
            {
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[1].Value = "w" + (i + 1);
            }
            int k = int.Parse(textBox4.Text);
            dataGridView3.Rows.Add(k);
            for (int i = 0; i < k; i++)
            {
                dataGridView3.Rows.Add(1);
                dataGridView3.Rows[i].Cells[1].Value = "k" + (i + 1);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int u = int.Parse(textBox1.Text);
            int w = int.Parse(textBox2.Text);
            int k = int.Parse(textBox4.Text);
            dataGridView4.Rows.Add(u);
            for (int i = 0; i < u; i++)
            {
                dataGridView4.Rows[i].Cells[0].Value = "u" + (i + 1);
            }
            for (int i = 0; i < w; i++)
            {
                dataGridView4.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "w " + i.ToString() });
            }
            dataGridView5.Rows.Add(u);
            for (int i = 0; i < u; i++)
            {
                dataGridView5.Rows[i].Cells[0].Value = "k" + (i + 1);
            }
            for (int i = 0; i < k; i++)
            {
                dataGridView5.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "k " + i.ToString() });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int u = int.Parse(textBox1.Text);
            int w = int.Parse(textBox2.Text);
            int k = int.Parse(textBox4.Text);

            string[,] table_one = new string[u, w];
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    table_one[i, j] = dataGridView4.Rows[i].Cells[j+1].Value.ToString();
                }
            }
            int[,] mass_one = new int[u, w];
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    mass_one[i, j] = int.Parse(table_one[i, j]);
                }
            }
            string[,] table_two = new string[u, w];
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    table_two[i, j] = dataGridView5.Rows[i].Cells[j + 1].Value.ToString();
                }
            }
            int[,] mass_two = new int[u, w];
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    mass_two[i, j] = int.Parse(table_two[i, j]);
                }
            }

            int[,] mass = new int [u,w];
            for(int i = 0; i < u; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    mass[i, j] = mass_two[i, 2] * mass_one[i, j] - mass_two[i, 0] * mass_two[i, 1];
                }
            }
            

            

            int [,] array_savage = new int[u,w];
            int[] sav_max = new int[w];
            sav_max[0] = mass[0,0];
            int[] ar_max = new int[u];
            for (int j = 0; j < w; j++)
            {
                for(int i = 0; i < u; i++)
                {
                    if (sav_max[j] < mass[i, j])
                    {
                        sav_max[j] = mass[i,j];
                    }
                }
            }
            for (int j = 0; j < w; j++)
            {
                for (int i = 0; i < u; i++)
                {
                    array_savage[i, j] = sav_max[j] - mass[i, j];
                    
                }
            }
            for (int j = 0; j < u; j++) { ar_max[j] = 0; }
            for (int i = 0; i < u; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if(ar_max[i] < array_savage[i,j]) { ar_max[i] = array_savage[i, j]; }
                }
            }
            int sav_min = int.MaxValue;
            int sav = 0;
            for (int i = 0; i< u; i++)
            {
                if(sav_min > ar_max[i]) { sav_min = ar_max[i];
                    sav = i+1;
                }
            }
            textBox3.Text = "u"+sav.ToString();



            dataGridView6.Rows.Add(u);
            for (int i = 0; i < u; i++)
            {
                dataGridView6.Rows[i].Cells[0].Value = "u" + (i + 1);
            }
            for (int i = 0; i < w; i++)
            {
                dataGridView6.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "w " + i.ToString() });
            }
            dataGridView7.Rows.Add(u);
            for (int i = 0; i < u; i++)
            {
                dataGridView7.Rows[i].Cells[0].Value = "u" + (i + 1);
            }
            for (int i = 0; i < w; i++)
            {
                dataGridView7.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "w " + i.ToString() });
            }
            dataGridView8.Rows.Add(u);
            for (int i = 0; i < u; i++)
            {
                dataGridView8.Rows[i].Cells[0].Value = "u" + (i + 1);
            }
            for (int i = 0; i < 1; i++)
            {
                dataGridView8.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "max " });
            }
            
            string[,] mass_str = new string[u, w];
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    mass_str[i, j] = mass[i,j].ToString();
                }
            }
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < w; j++)
                {
                     dataGridView6.Rows[i].Cells[j + 1].Value = mass_str[i, j] ;
                }
            }
            
            string[,] array_savage_str = new string[u, w];
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    array_savage_str[i, j] = array_savage[i, j].ToString();
                }
            }
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    dataGridView7.Rows[i].Cells[j + 1].Value = array_savage_str[i, j];
                }
            }
            
            string[,] ar_max_str = new string[u,2];
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    ar_max_str[i, j] = ar_max[i].ToString();
                }
            }
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    dataGridView8.Rows[i].Cells[j + 1].Value = ar_max_str[i, j];
                }
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
