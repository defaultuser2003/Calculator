using System;
using IUnary;
using System.Configuration;

namespace IUnaryClient
{
    class IUClient
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the number: ");
                double num = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter the operation (abs, neg, rec, sqrt, square): ");
                string operationName = Console.ReadLine();
                string operationTypeName = ConfigurationManager.AppSettings[operationName];

                IUnaryOperation operation = (IUnaryOperation)Activator.CreateInstance(Type.GetType(operationTypeName));

                double result = operation.Calculate(num);

                Console.WriteLine($"The result is: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
