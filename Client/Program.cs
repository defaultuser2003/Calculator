using SimpleCalculator;
using System;
using System.Configuration;
using System.Reflection;

namespace SimpleCalculator.Configuration
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2;
            Console.WriteLine("请输入第一个数字：");
            while (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("输入的数字不合法，请重新输入第一个数字：");
            }

            string op;
            while (true)
            {
                Console.WriteLine("请输入运算符号（+、-、*、/）：");
                op = Console.ReadLine();
                if (op == "+" || op == "-" || op == "*" || op == "/")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("输入的运算符号不合法，请重新输入运算符号：");
                }
            }

            while (true)
            {
                Console.WriteLine("请输入第二个数字：");
                if (double.TryParse(Console.ReadLine(), out num2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("输入的数字不合法，请重新输入第二个数字：");
                }
            }

            string calculatorType = ConfigurationManager.AppSettings["CalculatorType"];
            Type type = Type.GetType(calculatorType);
            if (type == null || !typeof(ICalculator).IsAssignableFrom(type))
            {
                Console.WriteLine("不支持该运算符号！");
                return;
            }

            ICalculator calculator = Activator.CreateInstance(type) as ICalculator;
            double result = calculator.Calculate(num1, num2);

            Console.WriteLine("计算结果为：" + result);
        }
    }
}