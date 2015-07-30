using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        { 
            // спросить количество студентов
            Console.WriteLine ("Введите колличество студентов!");
            int groupSize = 0;
            while (!int.TryParse(Console.ReadLine(), out groupSize))
            {
                Console.WriteLine("Введите правильное колличество студентов!");
            }
            Student[] group = new Student[groupSize];
            // спросить имя каждого студента
            for (int i = 0; i < groupSize; i++)
            {
                Console.WriteLine("Введите имя студента!");
                group[i] = new Student(Console.ReadLine());
            }
            
            // вывести общий список студентов
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, group[i].GetName());
            }
            Console.ReadLine();
          }
    }
}
