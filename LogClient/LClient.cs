using System;
using IUnary;
using IBinary;
using Logging;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogClient
{
    /**
    * Author arborshield
    * Created by on 2023/4/2.
    * ClientTest
    */
    class LClient
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Unary or Binary?");
                string op = Convert.ToString(Console.ReadLine());

                if (op == "Unary")
                {

                    Console.Write("Enter the number: ");
                    double num = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the operation (abs, neg, rec, sqrt, square): ");
                    string operationName = Console.ReadLine();
                    string operationTypeName = ConfigurationManager.AppSettings[operationName];

                    IUnaryOperation operation = (IUnaryOperation)Activator.CreateInstance(Type.GetType(operationTypeName));

                    double result = operation.Calculate(num);

                    Console.WriteLine($"The result is: {result}");
                    ILogger logger = LoggerFactory.CreateLogger();
                    logger.Log($"Operation {num} {operationTypeName} = {result}");
                }

                if (op == "Binary")
                {
                    Console.Write("Enter the first number: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the second number: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the operation (+, -, *, /, Log): ");
                    string operationName = Console.ReadLine();

                    IBinaryOperation operation = BinaryOperationFactory.CreateOperation(operationName);

                    double result = operation.Calculate(num1, num2);

                    Console.WriteLine($"The result is: {result}");
                    ILogger logger = LoggerFactory.CreateLogger();
                    logger.Log($"Operation {num1} {operationName} {num2} = {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
