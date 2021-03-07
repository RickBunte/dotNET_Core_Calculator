using System;
using System.Collections.Generic;
using System.Text;

namespace dotNET_Core_Calculator
{
    class Calculator
    {
        public float answer = 0f;
        DateTime date = DateTime.Now;

        public Calculator() { }

        public void ShowCommands()
        {
            Console.WriteLine($".NET Core Calculator activated on {date:d} at {date:t}");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("\nThis calculator works with the following operators:");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\n+ -> Adds the second number to the first number".PadLeft(20, ' '));
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\n- -> Deducts the second number off the first number".PadLeft(20, ' '));
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\n/ -> Divides the first number by the second number".PadLeft(20, ' '));
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\n* -> Multiplies the second number with the second number".PadLeft(20, ' '));
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\n^ -> Takes the first number and makes it to the power of the second number".PadLeft(20, ' '));
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nans -> Gives the previous answer".PadLeft(20, ' '));
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\ncommands -> Returns this list".PadLeft(20, ' '));
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nexit -> Exits the program".PadLeft(20, ' '));
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nEnter the calculation like \"number operator number\"");
            Console.WriteLine("This calculator currently only takes no more than 2 numbers and 1 operator!");
        }

        public void Calculate(string calculation)
        {
            bool validCalculation = true;
            float[] numbers = new float[2];
            string usedOperator = "";
            foreach (string output in calculation.Split(" "))
            {
                if (float.TryParse(output, out float fNum))
                {
                    int index = numbers[0] == 0 ? 0 : 1;
                    numbers[index] = fNum;
                }
                else if (output == "ans")
                {
                    int index = numbers[0] == 0 ? 0 : 1;
                    numbers[index] = answer;
                }
                else if (output.IndexOfAny("+-/*^".ToCharArray()) != -1)
                {
                    usedOperator = output;
                }
                else
                {
                    validCalculation = false;
                }
            }
            if (validCalculation)
            {
                switch (usedOperator)
                {
                    case "+":
                        answer = numbers[0] + numbers[1];
                        Console.WriteLine($"\nResults in: {answer}");
                        break;
                    case "-":
                        answer = numbers[0] - numbers[1];
                        Console.WriteLine($"\nResults in: {answer}");
                        break;
                    case "*":
                        answer = numbers[0] * numbers[1];
                        Console.WriteLine($"\nResults in: {answer}");
                        break;
                    case "/":
                        if (numbers[0] == 0 || numbers[1] == 0)
                        {
                            Console.WriteLine($"\nCan't divide by 0!");
                        }
                        else
                        {
                            answer = numbers[0] / numbers[1];
                            Console.WriteLine($"\nResults in: {answer}");
                        }
                        break;
                    case "^":
                        answer = MathF.Pow(numbers[0], numbers[1]);
                        Console.WriteLine($"\nResults in: {answer}");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"\nInvalid input!");
            }
        }
    }
}
