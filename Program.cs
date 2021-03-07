using System;

namespace dotNET_Core_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            bool isRunning = true;
            calculator.ShowCommands();
            
            while (isRunning)
            {
                string calculation = Console.ReadLine();
                if(calculation.Contains("exit"))
                {
                    isRunning = false;
                }
                else if (calculation == "ans")
                {
                    Console.WriteLine($"\nYour answer was: {calculator.answer}");
                }
                else if(calculation == "commands")
                {
                    calculator.ShowCommands();
                }
                else
                {
                    calculator.Calculate(calculation);
                }
            }
        }
    }
}
