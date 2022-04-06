using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        public static void Input()
        {
            Console.Clear();
            bool succes = false;

            Console.Write("Enter the first number: ");
            string first = Console.ReadLine();
            succes = double.TryParse(first, out double firstNumber);
            if (succes) { }
            else
            {
                Console.WriteLine("Wrong Enter!");
                Thread.Sleep(1111);
                Input();
            }

            error: 
            Console.Write("Entere the operation: ");
            char operation = Console.ReadLine()[0];
            if (operation == '+' || operation == '-' || operation == '*' || operation == '/') { }
            else
            {
                Console.WriteLine("Wrong Enter!");
                Thread.Sleep(666);
                goto error;
            }

            error2:
            Console.WriteLine("Enter the second number: ");
            string second = Console.ReadLine();
            succes = double.TryParse(second, out double secondNumber);
            if (succes) { }
            else
            {
                Console.WriteLine("Wrong Enter!");
                Thread.Sleep(1111);
                goto error2;
            }

            Calculating(firstNumber, secondNumber, operation);
        }

        public static void Calculating(double firstNumber, double secondNumber, char operation)
        {
            double result = 0;
            switch (operation)
            {
                case '+': result = firstNumber + secondNumber; break;
                case '-': result = firstNumber - secondNumber; break;
                case '*': result = firstNumber * secondNumber; break;
                case '/': result = firstNumber / secondNumber; break;
                default:
                    Console.WriteLine("Error Occrued in Switch Case!");
                    break;
            }

            Result(firstNumber, operation, secondNumber, result);
        }

        public static void Result(double firstNumber, char operation, double secondNumber, double result)
        {
            Console.Clear();
            Console.WriteLine(firstNumber.ToString() + " " + operation.ToString() + " " + secondNumber.ToString() + " = " + result.ToString());
            Thread.Sleep(1111);

            Console.WriteLine("Recalculate or Exit (R/E): ");
            string response = Console.ReadLine();
            if (response.ToUpper() == "R") Input();
            else if(response.ToUpper() == "E") Exit();
            else
            {
                Console.WriteLine("Wrong Enter!");
                Thread.Sleep(1111);
                Result(firstNumber, operation, secondNumber, result);
            }
        }

        public static void Exit()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        public static void intro()
        {
            Console.WindowHeight = 22;
            Console.WindowWidth = 44;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            String welcome = "\t\tWelcome to Calc\t\t\t";
            for (int i = 0; i < 22; i++)
            {
                Console.Clear();
                welcome = welcome.Insert(0, "\n");
                Console.WriteLine(welcome);
                Thread.Sleep(11);
            }
            Console.Clear();
        }

        static void Main(string[] args)
        {
            intro();
            while (true)
            {
                Input();
            }

            Console.ReadKey();
        }
    }
}
