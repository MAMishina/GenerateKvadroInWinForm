using System.Diagnostics.Metrics;

namespace GenerateKvadroInWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("������� ����������?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        /// <summary>
        /// ������ "������� ���������"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int down = Convert.ToInt32(textBox1.Text);
            int up = Convert.ToInt32(textBox2.Text);
            int count = Convert.ToInt32(textBox3.Text);

            List<string> list = new List<string>();

            if (count < 0 || count > 2)
            {
                list.Add("��� �� ������. ����� ���� 0-2 �������.");
            }
            else
            {
                for (int a = down; a <= up; a++)
                {
                    for (int b = down; b <= up; b++)
                    {
                        for (int c = down; c <= up; c++)
                        {
                            double d = b * b - 4 * a * c;
                            if (count == 0 && d < 0)
                            {
                                list.Add($"{a}*x^2 + {b}*x + {c} - ��������� �� ����� ������, ��� ������������ ����� 0");
                            }
                            else if (count == 1 && d == 0)
                            {
                                list.Add($"{a}*x^2 + {b}*x + {c} - ��������� ����� ���� ������. � = {-b / (2 * a)}, ��� ������������ ����� {d}");
                            }
                            else if (count == 2 && d > 0)
                            {
                                double x1 = (-b - Math.Sqrt(d)) / (2 * a);
                                double x2 = (-b + Math.Sqrt(d)) / (2 * a);
                                list.Add($"{a}*x^2 + {b}*x + {c} - ��������� ����� ��� �����. \n�1 = {x1:#.##}, \nX2 = {x2:#.##}, \n��� ������������ ����� {d:#.##}\n");
                            }
                        }
                    }
                }
            }
            listBox1.DataSource = list;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// ������ "�������� ���"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            listBox1.DataSource = list;

        }
    }
}