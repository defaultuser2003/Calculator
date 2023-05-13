using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBinary;
using IUnary;

namespace UI
{
    public partial class Form1 : Form
    {
        private IBinaryOperation currentOperation;

        public Form1()
        {
            InitializeComponent();
        }

        private void zero_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void one_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void two_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void three_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void four_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void five_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void six_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void seven_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
            formation.Text += button.Text;
        }

        private void eight_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void nine_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void point_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void sub_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void mul_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void div_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void log_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                formation.Text += button.Text;
            }
        }

        private void equal_Click(object sender, EventArgs e)
        {

            // 获取文本框中的表达式
            string expression = formation.Text;

            // 定义正则表达式来提取数字和运算符
            string pattern = @"(\d+\.?\d*)([\+\-\*/]|Log)(\d+\.?\d*)";

            // 使用正则表达式匹配表达式并提取数字和运算符
            Match match = Regex.Match(expression, pattern);

            if (match.Success)
            {
                // 提取第一个数字、第二个数字和运算符
                double num1 = double.Parse(match.Groups[1].Value);
                double num2 = double.Parse(match.Groups[3].Value);
                string op = match.Groups[2].Value;

                // 根据运算符创建对应的IBinaryOperation对象
                IBinaryOperation binaryOperation = null;
                switch (op)
                {
                    case "+":
                        binaryOperation = new Addition();
                        break;
                    case "-":
                        binaryOperation = new Subtraction();
                        break;
                    case "*":
                        binaryOperation = new Multiplication();
                        break;
                    case "/":
                        binaryOperation = new Division();
                        break;
                    case "Log":
                        binaryOperation = new Logarithm();
                        break;
                }

                // 如果找到了匹配项，计算结果
                if (binaryOperation != null)
                {
                    double result = binaryOperation.Calculate(num1, num2);

                    // 将结果写回到文本框中
                    formation.Text = result.ToString();
                }
            }
        }

        private void rec_Click(object sender, EventArgs e)
        {
            double inputNum;
            if (double.TryParse(formation.Text, out inputNum))
            {
                IUnaryOperation operation = new ReciprocalOperation();
                double result = operation.Calculate(inputNum);
                formation.Text = result.ToString();
            }
        }

        private void square_Click(object sender, EventArgs e)
        {
            double inputNum;
            if (double.TryParse(formation.Text, out inputNum))
            {
                IUnaryOperation operation = new SquareOperation();
                double result = operation.Calculate(inputNum);
                formation.Text = result.ToString();
            }
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            double inputNum;
            if (double.TryParse(formation.Text, out inputNum))
            {
                IUnaryOperation operation = new SqrtOperation();
                double result = operation.Calculate(inputNum);
                formation.Text = result.ToString();
            }
        }

        private void abs_Click(object sender, EventArgs e)
        {
            double inputNum;
            if (double.TryParse(formation.Text, out inputNum))
            {
                IUnaryOperation operation = new AbsoluteOperation();
                double result = operation.Calculate(inputNum);
                formation.Text = result.ToString();
            }
        }
        private void neg_Click(object sender, EventArgs e)
        {
            double inputNum;
            if (double.TryParse(formation.Text, out inputNum))
            {
                IUnaryOperation operation = new NegateOperation();
                double result = operation.Calculate(inputNum);
                formation.Text = result.ToString();
            }
        }


        private void clear_Click(object sender, EventArgs e)
        {
            formation.Text = "";
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (formation.Text.Length > 0)
            {
                formation.Text = formation.Text.Substring(0, formation.Text.Length - 1);
            }
        }

        private void per_Click(object sender, EventArgs e)
        {
            double num;
            if (double.TryParse(formation.Text, out num))
            {
                num /= 100;
                formation.Text = num.ToString();
            }
        }
    }
}
