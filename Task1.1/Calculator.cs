using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Task: 1.	Написать простейший калькулятор (реализовать как минимум 4 операции: сложение, вычитание, умножение, деление) с вводом\выводом из консоли;

namespace Calculator
{

    class Calculator
    {
        private double value;
        private double result;
        private string operand;
        

        public void EnterValue()
        {
            result = value;
            Console.WriteLine("Enter a number: ");
            value = TryParseDouble(Console.ReadLine());
        }

        public void EnterOperator()
        {
            Console.WriteLine("Enter an operand (+, -, :, *): ");
            operand = Console.ReadLine();
            
        }

        public  double Calculate()
        {
            switch (operand)
            {
                case "+":
                    result = result + value;
                    break;
                case "-":
                    result = result - value;
                    break;
                case ":":
                    if (value.Equals(0))
                    {
                        Console.Write("ERROR. Division by zero! ");
                    }
                    result = result/value;
                    break;
                case "*":
                    result = result*value;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
            return result;
        }
        private double TryParseDouble(String s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input format. ");
                return 1;
            }
        }

    }

    class Calculate
    {

        static void Main(string[] args)
        {
           Calculator calc = new Calculator();
           calc.EnterValue();
           calc.EnterOperator();
           calc.EnterValue();
           Console.WriteLine("Result is: " + calc.Calculate());
           Console.ReadLine();
        }
    }
}
