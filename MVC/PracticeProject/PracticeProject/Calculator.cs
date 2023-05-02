using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProject
{
    class Calculator
    {
        public void Clac()
        {
            do
            {
                double num1 = 0;
                double num2 = 0;
                double result = 0;

                Console.Write("Enter First Number : ");
                num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Second Number : ");
                num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Choose an Operator : ");
                Console.WriteLine("+ : Add");
                Console.WriteLine("- : Subtract");
                Console.WriteLine("* : Multiply");
                Console.WriteLine("/ : Divide");
                Console.Write("Enter an Operator : ");

                switch (Console.ReadLine())
                {
                    case "+":
                        result = num1 + num2;
                        Console.WriteLine($"Your result is {num1} + {num2} = " + result);
                        break;
                    case "-":
                        result = num1 + num2;
                        Console.WriteLine($"Your result is {num1} - {num2} = " + result);
                        break;
                    case "*":
                        result = num1 + num2;
                        Console.WriteLine($"Your result is {num1} * {num2} = " + result);
                        break;
                    case "/":
                        result = num1 + num2;
                        Console.WriteLine($"Your result is {num1} / {num2} = " + result);
                        break;
                    default:
                        Console.WriteLine("Not Enter Correct Operator");
                        break;
                }
                Console.WriteLine("Would you like to continu? (Y = Yes, N = No)");
            } while (Console.ReadLine().ToUpper() == "Y");
            Console.WriteLine("Thank You");
        }
    }
}
