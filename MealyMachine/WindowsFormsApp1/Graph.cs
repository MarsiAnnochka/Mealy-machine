using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Graph : Form
    {
        public Graph(int x, int s, int y, string h_1, string h_2, string f_1, string f_2)
        {
            InitializeComponent();
            string writePath = @"C:\Users\Аня Егорова\source\repos\WindowsFormsApp1\graph.txt";
            StreamWriter sw = new StreamWriter(writePath, false);
            sw.Write("@startuml\n");
            sw.WriteLine();
            Table1 table = new Table1(x, s, y, h_1, h_2, f_1, f_2);
                for (int i = 0; i < table.dataGridView1.RowCount; i++)
                    for (int k = 0; k < table.dataGridView1.RowCount; k++)
                    {
                        string str_1 = table.dataGridView1.Rows[i].HeaderCell.Value.ToString();
                        string str_2 = table.dataGridView1.Rows[k].HeaderCell.Value.ToString();
                        string str = "";
                        bool found = false;
                        int j;
                        for (j = 0; j < Math.Pow(2, x); j++)
                            if (str_2 == table.dataGridView1[j, i].Value.ToString())
                            {
                                sw.Write("(" + str_1 + ") --> (" + str_2 + ") : " + table.dataGridView1.Columns[j].HeaderText);
                            for (int p = Convert.ToInt32(Math.Pow(2, x)) + 1; p < table.dataGridView1.ColumnCount; p++)
                            {
                                str = table.dataGridView1.Columns[j].HeaderText == table.dataGridView1.Columns[p].HeaderText ? table.dataGridView1[p, i].Value.ToString() : "";
                                if (!str.Equals("")) break;
                            }
                                sw.Write("/" + str);
                                found = true;
                                break;
                            }
                        if (found)
                            for (int p = j+1; p < Math.Pow(2, x); p++)
                                if (str_2 == table.dataGridView1[p, i].Value.ToString())
                                {
                                    sw.Write(", " + table.dataGridView1.Columns[p].HeaderText);
                                for (int h = Convert.ToInt32(Math.Pow(2, x)) + 1; h < table.dataGridView1.ColumnCount; h++)
                                {
                                    str = table.dataGridView1.Columns[p].HeaderText == table.dataGridView1.Columns[h].HeaderText ? table.dataGridView1[h, i].Value.ToString() : "";
                                    if (!str.Equals("")) break;
                                }
                                    sw.Write("/" + str);
                                }
                    if (found) sw.WriteLine();
                    }
                sw.Write("@enduml");
            sw.Close();
    }
        

        private void Graph_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            System.IO.FileStream fs = new System.IO.FileStream(@"C:\Users\Аня Егорова\source\repos\WindowsFormsApp1\graph.png", System.IO.FileMode.Open);
            System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
            fs.Close();
            pictureBox1.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
    
    
}
