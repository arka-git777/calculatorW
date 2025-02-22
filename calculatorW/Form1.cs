using System.Linq.Expressions;

namespace calculatorW
{
    public partial class Form1 : Form
    {
        List<string> history = new List<string>();
        string text = "";
        string FileName = "history.txt";
        public Form1()
        {
            InitializeComponent();
            LoadHistyory();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            text += "0";
            textBox1.Text = text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            text += "1";
            textBox1.Text = text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            text += "2";
            textBox1.Text = text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            text += "3";
            textBox1.Text = text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            text += "4";
            textBox1.Text = text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            text += "5";
            textBox1.Text = text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            text += "6";
            textBox1.Text = text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            text += "7";
            textBox1.Text = text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            text += "8";
            textBox1.Text = text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            text += "9";
            textBox1.Text = text;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            text += "+";
            textBox1.Text = text;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            text += "-";
            textBox1.Text = text;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            text += "x";
            textBox1.Text = text;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            text += "/";
            textBox1.Text = text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text))
                text = text.Remove(text.Length - 1);
            textBox1.Text = text;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            text = "";
            textBox1.Text = "";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            text += ".";
            textBox1.Text = text;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '0' && text[i - 1] == '/')
                {
                    history.Add(text + "=" + "divide by zero");
                    textHistoryBox.Text = string.Join(Environment.NewLine, history);
                    text = "";
                    return;
                }
            }
            history.Add(text + "=" + Count());
            textHistoryBox.Text = string.Join(Environment.NewLine, history);
            text = "";
        }
        private double Count()
        {
            double currentNum = 0;
            char lastOperator = '+';

            List<double> numbers = new List<double>();
            List<char> operators = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (char.IsDigit(currentChar))
                    currentNum = currentNum * 10 + (currentChar - '0');

                if (i == text.Length - 1 || currentChar == '+' || currentChar == '-' || currentChar == 'x' || currentChar == '/')
                {
                    if (lastOperator == '+')
                        numbers.Add(currentNum);
                    else if (lastOperator == '-')
                        numbers.Add(-currentNum);
                    else if (lastOperator == 'x')
                        numbers[numbers.Count - 1] *= currentNum;
                    else if (lastOperator == '/')
                    {
                        if (currentNum != 0)
                            numbers[numbers.Count - 1] /= currentNum;
                        else
                        {
                            MessageBox.Show("You cannot divide by zero!!!", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            text = "";
                            textBox1.Text = text;
                        }
                    }

                    currentNum = 0;
                    lastOperator = currentChar;
                }
            }

            return numbers.Sum();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(FileName, history);
            MessageBox.Show("History saved!");
        }
        private void LoadHistyory()
        {
            if (File.Exists(FileName))
            {
                history = new List<string>(File.ReadAllLines(FileName));
                textHistoryBox.Text = string.Join(Environment.NewLine, history);
            }
            else
                MessageBox.Show("No history file found.");
        }

    }
}
