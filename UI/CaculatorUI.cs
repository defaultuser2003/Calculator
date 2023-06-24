using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;
using IBinary;
using IUnary;
using Logging;
using CalculatorThemes;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace UI
{
    public partial class CaculatorUI : Form
    {
        [ImportMany]
        public IEnumerable<ILogger> Loggers { get; set; }

        public CaculatorUI()
        {
            InitializeComponent();
            _themeFactory = new LightThemeFactory();

            // Configure the MEF container
            try
            {
                var catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                Console.WriteLine("CompositionException: " + ex.ToString());
            }

        }
        private ILogger GetLogger()
        {
            string loggerType = ConfigurationManager.AppSettings["LoggerType"];

            if (loggerType == "FileLogger")
            {
                string logFilePath = ConfigurationManager.AppSettings["LogFilePath"];
                return new FileLogger(logFilePath);
            }
            else if (loggerType == "AdoNetLogger")
            {
                string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                return new AdoNetLogger(connectionString);
            }
            else if (loggerType == "EfLogger")
            {
                var dbContext = new LogDbContext();
                return new EfLogger(dbContext);
            }
            else
            {
                throw new Exception("Invalid logger type specified in configuration.");
            }
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
                string operationClassName = ConfigurationManager.AppSettings[op];
                if (!string.IsNullOrEmpty(operationClassName))
                {
                    binaryOperation = (IBinaryOperation)Activator.CreateInstance(Type.GetType(operationClassName));
                }


                // If a match is found, calculate the result
                if (binaryOperation != null)
                {
                    double result = binaryOperation.Calculate(num1, num2);

                    ILogger logger = GetLogger();
                    logger.Log($"Operation {expression} = {result}");

                    // Write the result back into the text box
                    formation.Text = result.ToString();
                }
            }
        }

        private void rec_Click(object sender, EventArgs e)
        {
            PerformUnaryOperation("rec");
        }

        private void square_Click(object sender, EventArgs e)
        {
            PerformUnaryOperation("square");
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            PerformUnaryOperation("sqrt");
        }

        private void abs_Click(object sender, EventArgs e)
        {
            PerformUnaryOperation("abs");
        }

        private void neg_Click(object sender, EventArgs e)
        {
            PerformUnaryOperation("neg");
        }

        private void PerformUnaryOperation(string operationKey)
        {
            double inputNum;
            if (double.TryParse(formation.Text, out inputNum))
            {
                string operationClassName = ConfigurationManager.AppSettings[operationKey];
                IUnaryOperation operation = null;
                if (!string.IsNullOrEmpty(operationClassName))
                {
                    operation = (IUnaryOperation)Activator.CreateInstance(Type.GetType(operationClassName));
                }
                if (operation != null)
                {
                    double result = operation.Calculate(inputNum);

                    ILogger logger = GetLogger();
                    logger.Log($"Operation {operationKey} {inputNum} = {result}");

                    formation.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("The operation is not defined in the configuration file.");
                }
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
            ILogger logger = GetLogger();
            string logContent = GetLogContentFromLogger(logger); // Get log content from logger object

            // Display log information
            MessageBox.Show(logContent, "Log Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string GetLogContentFromLogger(ILogger logger)
        {
            // Read the log file path from the configuration file
            string logFilePath = ConfigurationManager.AppSettings["LogFilePath"];

            // Check if the log file exists
            if (!File.Exists(logFilePath))
            {
                return "Log file does not exist.";
            }

            try
            {
                // Read the contents of the log file
                string logContent = File.ReadAllText(logFilePath);

                return logContent;
            }
            catch (IOException ex)
            {
                // Handling read file exceptions
                return $"Failed to read log file: {ex.Message}";
            }
        }

        private IThemeFactory _themeFactory;
        private void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_themeFactory is LightThemeFactory)
            {
                _themeFactory = new DarkThemeFactory();
            }
            else
            {
                _themeFactory = new LightThemeFactory();
            }

            this.BackColor = _themeFactory.GetBackgroundColor();
            label1.Font = _themeFactory.GetFont();
            label1.ForeColor = _themeFactory.GetFontColor();
        }
    }
}