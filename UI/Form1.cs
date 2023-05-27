using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;
using IBinary;
using IUnary;
using Logging;
using System.Linq.Expressions;

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

            // Get the expression in the text box
            string expression = formation.Text;

            // Define regular expressions to extract numbers and operators
            string pattern = @"(\d+\.?\d*)([\+\-\*/]|Log)(\d+\.?\d*)";

            // Use regular expressions to match expressions and extract numbers and operators
            Match match = Regex.Match(expression, pattern);

            if (match.Success)
            {
                // Extract the first digit, the second digit, and the operator
                double num1 = double.Parse(match.Groups[1].Value);
                double num2 = double.Parse(match.Groups[3].Value);
                string op = match.Groups[2].Value;

                // Create the corresponding IBinaryOperation object from the operator
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

                // If a match is found, calculate the result
                if (binaryOperation != null)
                {
                    double result = binaryOperation.Calculate(num1, num2);

                    ILogger logger = LoggerFactory.CreateLogger();
                    logger.Log($"Operation {expression} = {result}");

                    // Write the result back into the text box
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

                ILogger logger = LoggerFactory.CreateLogger();
                logger.Log($"Operation rec {inputNum} = {result}");

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

                ILogger logger = LoggerFactory.CreateLogger();
                logger.Log($"Operation square {inputNum} = {result}");

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

                ILogger logger = LoggerFactory.CreateLogger();
                logger.Log($"Operation sqrt {inputNum} = {result}");

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

                ILogger logger = LoggerFactory.CreateLogger();
                logger.Log($"Operation abs {inputNum} = {result}");

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

                ILogger logger = LoggerFactory.CreateLogger();
                logger.Log($"Operation neg {inputNum} = {result}");

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

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILogger logger = LoggerFactory.CreateLogger();
            string logContent = GetLogContentFromLogger(logger); // 从日志记录器对象获取日志内容

            // 显示日志信息
            MessageBox.Show(logContent, "Log Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string GetLogContentFromLogger(ILogger logger)
        {
            // 从配置文件中读取日志文件路径
            string logFilePath = ConfigurationManager.AppSettings["LogFilePath"];

            // 检查日志文件是否存在
            if (!File.Exists(logFilePath))
            {
                return "Log file does not exist.";
            }

            try
            {
                // 读取日志文件内容
                string logContent = File.ReadAllText(logFilePath);

                return logContent;
            }
            catch (IOException ex)
            {
                // 处理读取文件异常
                return $"Failed to read log file: {ex.Message}";
            }
        }
    }
}