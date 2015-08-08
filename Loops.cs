using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstProgram
{
    public static class Loops
    {
        public static void CelsiusToFahrenheit()
        {
            int degree = 0;
            while (degree < 100)
            {
                degree = degree + 5;
                double degreeFarenheit = 1.8 * degree + 32;
                Console.WriteLine("C:{0} - F:{1}", degree, degreeFarenheit);
            }
        }

        public static void SwimDistance()
        {
            double distance = 3;
            int day = 1;
            double distanceSum = 0;
            while (distance <= 5)
            {
                day++;
                distance = distance * 1.1;
                if (distance > 5)
                {
                    Console.WriteLine("На {0} день пловец начнет проплывать более 5 км", day);
                }
            }
            distance = 3;
            day = 1;
            while (distanceSum <= 30)
            {
                distance = distance * 1.1;
                distanceSum += distance;
                day++;
                if (distanceSum > 30)
                {
                    Console.WriteLine("К {0} дню он суммарно проплывет более 30 км", day);
                }
            }
        }

        public static void AmoebaDivision()
        {
            int amoebaCounter = 1;
            int time = 0;
            for (int dividing = 0; dividing < 8; dividing++)
            {
                amoebaCounter = amoebaCounter * 2;
                time += 3;
                Console.WriteLine("Через {0} часов у нас будет {1} амёб", time, amoebaCounter);
            }
        }

        public static void PrimeNumber()
        {
            Console.WriteLine("Введите натуральное число!");
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Введите правильное число!");
            }
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
            Console.WriteLine(isPrime ? "Число является простым" : "Число не является простым");
        }

        public static void RabbitsAndGeese()
        {
            const int allLegs = 64;
            int counter = 0;
            for (int rabbit = 0; rabbit * 4 <= allLegs; rabbit++)
            {
                int goose = (allLegs - rabbit * 4) / 2;
                counter++;
                Console.WriteLine("Количество кроликов:{0}, а количество гусей:{1}", rabbit, goose);
            }
            Console.WriteLine("Общее количество сочетаний: {0}", counter);
        }

        public static void MinNumber()
        {
            int minNumber = int.MaxValue;
            int imputNumber = 0;
            do
            {
                imputNumber = Helpers.GetNumber("Введите число. 0 - выход");
                if (imputNumber != 0 && imputNumber < minNumber)
                {
                    minNumber = imputNumber;
                }
            } while (imputNumber != 0);
            Console.WriteLine(minNumber);
        }

        public static void AllPrime()
        {
            int userInput = Helpers.GetNumber("Введите число");
            for (int i = 0; i <= userInput; i++)
            {
                if (Helpers.IsPrime(i))
                {
                    Console.WriteLine(i);
                }

            }
        }

        public static void TwoEven()
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Helpers.GetNumber("Введите число") % 2 == 0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter >= 2 ? "Два или более из введенных чисел являются четными" : "В введенных числах нет двух четных");
        }

        public static void LeapYear()
        {
            int userYear = Helpers.GetNumber("Введите год");
            if ((userYear % 4 == 0 && userYear % 100 != 0) || userYear % 400 == 0)
            {
                Console.WriteLine("Введенный год является високосным");
            }
            else { Console.WriteLine("Введенный год не является високосным"); }
        }

        public static void Week()
        {
            int dayOfWeek = Helpers.GetNumber("Введите номер дня недели");
            switch (dayOfWeek)
            {
                case 1:
                    Console.WriteLine("Понедельник");
                    break;
                case 2:
                    Console.WriteLine("Вторник");
                    break;
                case 3:
                    Console.WriteLine("Среда");
                    break;
                case 4:
                    Console.WriteLine("Четверг");
                    break;
                case 5:
                    Console.WriteLine("Пятница");
                    break;
                case 6:
                    Console.WriteLine("Суббота");
                    break;
                case 7:
                    Console.WriteLine("Воскресенье");
                    break;
                default:
                    Console.WriteLine("Такого дня недели не существует");
                    break;
            }
        }

        public static void PriceByTaxi()
        {
            int distance = Helpers.GetNumber("Введите расстояние поездки");
            int time = Helpers.GetNumber("Введите время простоя такси");
            const int basePrise = 20;
            const int baseTimePrise = 1;
            const int baseKmPrise = 3;
            int totalSum = 0;
            if (distance <= 5)
            {
                totalSum = basePrise;
            }
            else
            {
                totalSum = basePrise + ((distance - 5) * baseKmPrise);
            }
            if (time != 0)
            {
                totalSum += time * baseTimePrise;
            }
            Console.WriteLine(totalSum);
        }

        public static void GameOfDice()
        {
            int rate = Helpers.GetNumber("Введите ставку. Ставка должна быть целым числом");
            int prize = 0;
            Random rand = new Random();
            int firstNumber = rand.Next(1, 13);
            int secondNumber = rand.Next(1, 13);
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);
            if (firstNumber % 3 == 0 && secondNumber % 5 == 0)
            {
                prize = 5 * rate;
            }
            else if (firstNumber % 2 == 0 && secondNumber % 2 == 0)
            {
                prize = 2 * rate;
            }
            else if ((firstNumber % 2 == 0 && secondNumber % 2 == 0) && ((firstNumber == 12 || secondNumber != 12) || (firstNumber != 12 || secondNumber == 12)))
            {
                prize = 10 * rate;
            }
            else if (((firstNumber == 12 || secondNumber == 12) && (firstNumber == 1 || secondNumber == 1)) || (firstNumber == 6 && secondNumber == 6))
            {
                prize = 50 * rate;
            }
            else
            {
                Console.WriteLine("Вы проиграли. Попробуйте еще раз!");
            }
            Console.WriteLine("Ваш выиграш составил {0}", prize);
        }

        public static void Triangle()
        {
            int side1 = Helpers.GetNumber("Введите длину пеpвой стороны треугольника");
            int side2 = Helpers.GetNumber("Введите длину второй стороны треугольника");
            int side3 = Helpers.GetNumber("Введите длину третьей стороны треугольника");
            if ((side1 == Math.Sqrt(Math.Pow(side2, 2) + Math.Pow(side3, 2))) || (side2 == Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side3, 2))) || (side3 == Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2))))
            {
                Console.WriteLine("Данный треугольник является прямоугольным");
            }
            else
            {
                Console.WriteLine("Данный треугольник не является прямогугольным");
            }
        }

        public static void SquaredNumber()
        {
            double number = 0;
            int userNumber = Helpers.GetNumber("Введите натуральное число");
            for (double counter = 0; counter < userNumber; counter++)
            {
                number = Math.Pow(counter, 2);
                if (number < userNumber)
                {
                    Console.WriteLine(number);
                }
            }
        }

        public static void ParseNumber()
        {
            int number = Helpers.GetNumber("Введите четырехзначное число");
            int a, b, c, d;
            a = number / 1000;
            b = number % 1000 / 100;
            c = number % 100 / 10;
            d = number % 10;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            int sum = a + b + c + d;
            Console.WriteLine(sum);
        }
    }
}
