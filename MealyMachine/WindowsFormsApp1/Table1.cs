using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Table1 : Form
    {
        private int X_size, Y_size, S_size;
        private List<char> h1, h2, f1, f2;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public Table1(int x, int s, int y, string h_1, string h_2, string f_1, string f_2)
        {
            InitializeComponent();
            X_size = x;
            S_size = s;
            Y_size = y;
            this.h1 = Convert_to_OPZ(h_1);
            this.f1 = Convert_to_OPZ(f_1);
            if (S_size == 2) this.h2 = Convert_to_OPZ(h_2);
            if (Y_size == 2) this.f2 = Convert_to_OPZ(f_2);
            
            for (int i = 0; i < Math.Pow(2, X_size) * 2 + 1; i++)
            {
                DataGridViewTextBoxColumn new_column;
                new_column = new DataGridViewTextBoxColumn();
                if (i == Math.Pow(2, X_size))
                {
                    new_column.HeaderText = " ";
                }
                else
                {
                    int j = Convert.ToInt32(Math.Pow(2, X_size) + 1);
                    new_column.HeaderText = Convert.ToString(i % j, 2).PadLeft(X_size, '0');
                }
                dataGridView1.Columns.Add(new_column);
                dataGridView1.AllowUserToAddRows = false;
            }
            for (int i = 0; i < Math.Pow(2, S_size); i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i, 2).PadLeft(S_size, '0');
            }

           
            for (int i = 0; i < Math.Pow(2, X_size); i++)
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    char[] a = Convert.ToString(i, 2).PadLeft(X_size, '0').ToCharArray();
                    char[] b = Convert.ToString(j, 2).PadLeft(S_size, '0').ToCharArray();
                    if (X_size == 2)
                    {

                        if (S_size == 2)
                        {
                            dataGridView1[i, j].Value = Calculate(h1, a[0], a[1], b[0], b[1]);
                            dataGridView1[i, j].Value = dataGridView1[i, j].Value.ToString() + Calculate(h2, a[0], a[0], b[0], b[1]);
                        }
                        else
                        {
                            dataGridView1[i, j].Value = Calculate(h1, a[0], a[1], b[0], '0');
                        }
                    }
                    else
                    {
                        if (S_size == 2)
                        {
                            dataGridView1[i, j].Value = Calculate(h1, a[0], '0', b[0], b[1]);
                            dataGridView1[i, j].Value = dataGridView1[i, j].Value.ToString() + Calculate(h2, a[0], '0', b[0], b[1]);
                        }
                        else
                        {
                            dataGridView1[i, j].Value = Calculate(h1, a[0], '0', b[0], '0');
                        }
                    }
                }

           

            for (int i = Convert.ToInt32(Math.Pow(2, X_size) + 1); i < dataGridView1.ColumnCount; i++)
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    char[] a = Convert.ToString(i - Convert.ToInt32(Math.Pow(2, X_size)) - 1, 2).PadLeft(X_size, '0').ToCharArray();
                    char[] b = Convert.ToString(j, 2).PadLeft(S_size, '0').ToCharArray();

                    if (X_size == 2)
                    {
                        if (S_size == 2)
                        {
                            dataGridView1[i, j].Value = Calculate(f1, a[0], a[1], b[0], b[1]);
                            if (Y_size == 2)
                                dataGridView1[i, j].Value = dataGridView1[i, j].Value.ToString() + Calculate(f2, a[0], a[0], b[0], b[1]);
                        }
                        else
                        {
                            dataGridView1[i, j].Value = Calculate(f1, a[0], a[1], b[0], '0');
                            if (Y_size == 2)
                                dataGridView1[i, j].Value = dataGridView1[i, j].Value.ToString() + Calculate(f2, a[0], a[0], b[0], '0');

                        }
                    }
                    else
                    {
                        if (S_size == 2)
                        {
                            dataGridView1[i, j].Value = Calculate(f1, a[0], '0', b[0], b[1]);
                            if (Y_size == 2)
                                dataGridView1[i, j].Value = dataGridView1[i, j].Value.ToString() + Calculate(f2, a[0], '0', b[0], b[1]);
                        }
                        else
                        {
                            dataGridView1[i, j].Value = Calculate(f1, a[0], '0', b[0], '0');
                            if (Y_size == 2)
                                dataGridView1[i, j].Value = dataGridView1[i, j].Value.ToString() + Calculate(f2, a[0], '0', b[0], '0');

                        }
                    }
                }
        }

        private void Table_Load(object sender, EventArgs e)
        {
           
           
        }


        private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(':
                case ')':
                    return 0;
                case '+':
                    return 1;
                case '*':
                    return 2;
                default:
                    return 4;
            }
        }

        private List<char> Convert_to_OPZ(string input)
        {
            StringReader reader = new StringReader(input);
            List<char> symbols = new List<char>();
            Stack<char> operations = new Stack<char>();
            foreach (char n in input)
            {
                
                if (n.Equals('x') || n.Equals('s') || n.Equals('1') || n.Equals('2')|| n.Equals('0'))
                {
                   char symbol = symbols.Count!=0 ? symbols[symbols.Count - 1] : 'f';
                    if ((n.Equals('1') || n.Equals('0'))&&(symbol!='x')&&(symbol!='s'))
                    {
                        symbols.Add('y');
                    }
                    symbols.Add(n);
                }
                else if (n.Equals('('))
                {
                    operations.Push(n);
                }
                else if (n.Equals(')'))
                {
                    while (!operations.Peek().Equals('('))
                    {
                        symbols.Add(operations.Pop());
                    }
                    operations.Pop();
                }
                else if (n.Equals((char)32)) { }
                else
                {
                    while(operations.Count!=0)
                    {
                        if (GetPriority(operations.Peek()) >= GetPriority(n))
                        {
                            symbols.Add(operations.Pop());
                        }
                        else break;
                    }
                    operations.Push(n);
                }
            }
            while (operations.Count != 0)
            {
                symbols.Add(operations.Pop());
            }
            return symbols;
        }

        private int Calculate(List<char> opz, char x_1, char x_2, char s_1, char s_2)
        {
            int x1 = x_1 == '1' ? 1 : 0;
            int x2 = x_2 == '1' ? 1 : 0;
            int s1 = s_1 == '1' ? 1 : 0;
            int s2 = s_2 == '1' ? 1 : 0;
            Stack<char> stack = new Stack<char>();
            foreach (char n in opz)
            {
                if (n.Equals('x') || n.Equals('s') || n.Equals('1') || n.Equals('2') || n.Equals('y') || n.Equals('0'))
                {
                    stack.Push(n);
                }
                else
                {
                    int value_1 = 0, value_2 = 0;
                    char number_1 = stack.Pop();
                    char symbol_1 = stack.Pop();
                    char number_2 = stack.Pop();
                    char symbol_2 = stack.Pop();
                    if (symbol_1 == 'y')
                        value_1 = number_1.Equals('1') ? 1 : 0;
                    if (symbol_2 == 'y')
                        value_2 = number_2.Equals('1') ? 1 : 0;
                    if (symbol_1 == 'x')
                        value_1 = number_1.Equals('1') ? x1 : x2;
                    if (symbol_2 == 'x')
                        value_2 = number_2.Equals('1') ? x1 : x2;
                    if (symbol_1 == 's')
                        value_1 = number_1.Equals('1') ? s1 : s2;
                    if (symbol_2 == 's')
                        value_2 = number_2.Equals('1') ? s1 : s2;
                    int new_value;
                    new_value = n.Equals('+') ? (value_1 + value_2) % 2 : value_1*value_2;
                    stack.Push('y');
                    char symbol = new_value == 1 ? '1' : '0';
                    stack.Push(symbol);
                }
            }
            int result = 0;
            char number = stack.Pop();
            char symbolr = stack.Pop();
            if (symbolr == 'y')
                result = number.Equals('1') ? 1 : 0;
            if (symbolr == 'x')
                result = number.Equals('1') ? x1 : x2;
            if (symbolr == 's')
                result = number.Equals('1') ? s1 : s2;
           return result;
        }
    }
}
