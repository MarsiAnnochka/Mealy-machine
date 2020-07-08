using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            if (radioButton3.Checked == true)
                textBox2.Visible = true;
            else
                textBox2.Visible = false;
            if (radioButton5.Checked == true)
                textBox4.Visible = true;
            else
                textBox4.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int s = 1, x = 1, y = 1;
            if (radioButton3.Checked == true)
                s = 2;
            if (radioButton5.Checked == true)
                y = 2;
            if (radioButton1.Checked == true)
                x = 2;
            
            if (Exceptions(x, s, y))
            {
                textBox1.Text.Replace(" ", string.Empty);
                textBox2.Text.Replace(" ", string.Empty);
                textBox3.Text.Replace(" ", string.Empty);
                textBox4.Text.Replace(" ", string.Empty);
                Table1 newTable = new Table1(x, s, y, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                newTable.Show();
            }
            else
                MessageBox.Show("Некорректно набрана функция!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int s = 1, x = 1, y = 1;
            if (radioButton3.Checked == true)
                s = 2;
            if (radioButton5.Checked == true)
                y = 2;
            if (radioButton1.Checked == true)
                x = 2;
            if (Exceptions(x, s, y))
            {
                textBox1.Text.Replace(" ", string.Empty);
                textBox2.Text.Replace(" ", string.Empty);
                textBox3.Text.Replace(" ", string.Empty);
                textBox4.Text.Replace(" ", string.Empty);
                Graph graph = new Graph(x, s, y, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                graph.Show();
            }
            else
                MessageBox.Show("Некорректно набрана функция!");
           
        }

        private bool Exceptions(int x, int s, int y)
        {
            bool flag = true;
            foreach (char c in textBox1.Text)
                if ((c != 'x') && (c != 's') && (c != '0') && (c != '1') && (c != '2') && (c != '+') && (c != '*') && (c != ' ') && (c != '(') && (c != ')')) { flag = false; break; }
            foreach (char c in textBox2.Text)
                if ((c != 'x') && (c != 's') && (c != '0') && (c != '1') && (c != '2') && (c != '+') && (c != '*') && (c != ' ') && (c != '(') && (c != ')')) { flag = false; break; }
            foreach (char c in textBox3.Text)
                if ((c != 'x') && (c != 's') && (c != '0') && (c != '1') && (c != '2') && (c != '+') && (c != '*') && (c != ' ') && (c != '(') && (c != ')')) { flag = false; break; }
            foreach (char c in textBox4.Text)
                if ((c != 'x') && (c != 's') && (c != '0') && (c != '1') && (c != '2') && (c != '+') && (c != '*') && (c != ' ') && (c != '(') && (c != ')')) { flag = false; break; }
            if (textBox1.Text.Contains("s0") || textBox1.Text.Contains("x0") || textBox1.Text.Contains("0x") || textBox1.Text.Contains("0s") || textBox1.Text.Contains("1x") || textBox1.Text.Contains("1s") || textBox1.Text.Contains("2x") || textBox1.Text.Contains("2s"))
                flag = false;
            if (textBox2.Text.Contains("s0") || textBox2.Text.Contains("x0") || textBox2.Text.Contains("0x") || textBox2.Text.Contains("0s") || textBox2.Text.Contains("1x") || textBox2.Text.Contains("1s") || textBox2.Text.Contains("2x") || textBox2.Text.Contains("2s"))
                flag = false;
            if (textBox3.Text.Contains("s0") || textBox3.Text.Contains("x0") || textBox3.Text.Contains("0x") || textBox3.Text.Contains("0s") || textBox3.Text.Contains("1x") || textBox3.Text.Contains("1s") || textBox3.Text.Contains("2x") || textBox3.Text.Contains("2s"))
                flag = false;
            if (textBox4.Text.Contains("s0") || textBox4.Text.Contains("x0") || textBox4.Text.Contains("0x") || textBox4.Text.Contains("0s") || textBox4.Text.Contains("1x") || textBox4.Text.Contains("1s") || textBox4.Text.Contains("2x") || textBox4.Text.Contains("2s"))
                flag = false;
            if (((x == 1) && textBox1.Text.Contains("x2")) || ((s == 1) && textBox1.Text.Contains("s2")))
                flag = false;
            if (((x == 1) && textBox2.Text.Contains("x2")) || ((s == 1) && textBox2.Text.Contains("s2")))
                flag = false;
            if (((x == 1) && textBox3.Text.Contains("x2")) || ((s == 1) && textBox3.Text.Contains("s2")))
                flag = false;
            if (((x == 1) && textBox4.Text.Contains("x2")) || ((s == 1) && textBox4.Text.Contains("s2")))
                flag = false;
            return flag;
        }
        
    }
}

