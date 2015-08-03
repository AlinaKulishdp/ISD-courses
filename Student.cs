using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstProgram
{
    class Student
    {
        string name;
        string firstName;
        string lastName;
        string middleName;
        int birthYear;
        int birthMonth = 1;
        int birthDay = 1;
        static int count;
        public static int GetCount()
        {
            return count;
        }
        public string GetName()
        {
            return name;
        }
        public Student(string n)
        {
            name = n;
            Student.count++;
        }
        public Student(string lastName, string firstName, string middleName, int birthYear, int birthMonth, int birthDay)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.birthYear = birthYear;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
        }
        string GetFullName()
        {
            return lastName + " " + firstName + " " + middleName;
        }
        int GetAgeYears()
        {
            DateTime now = DateTime.Now;
            int yearsPassed = now.Year - birthYear;
            if (now.Month < birthMonth || (now.Month == birthMonth && now.Day < birthDay))
            {

                yearsPassed--;

            }
            return yearsPassed;
        }

        public static void GetGroup()
        {
            // спросить количество студентов
            Console.WriteLine("Введите колличество студентов!");
            int groupSize = 0;
            while (!int.TryParse(Console.ReadLine(), out groupSize))
            {
                Console.WriteLine("Введите правильное колличество студентов!");
            }
            Student[] group = new Student[groupSize];
            // спросить имя каждого студента
            for (int i = 0; i < groupSize; i++)
            {
                Console.WriteLine("Введите фамилию, имя и отчество студента!");
                group[i] = new Student(Console.ReadLine());
            }

            // вывести общий список студентов
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, group[i].GetName());
            }
        }
    }
}
