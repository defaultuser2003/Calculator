using IBinary;
using System;

namespace IBinaryClient
{
    class IBClient
    {
        static void Main(string[] args)
        {
            try
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
