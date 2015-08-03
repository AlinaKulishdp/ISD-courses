using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstProgram
{
    public static class Helpers
    {
        public static int GetNumber(string message)
        {
            Console.WriteLine(message);
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Введите правильное число!");
            }
            return number;
        }
        public static bool IsPrime(int number)
        {
            bool isPrime = true;
            if (number < 2)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                    }
                }
            }
            return isPrime;
        }
    }
}
