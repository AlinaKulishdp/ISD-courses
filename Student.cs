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
    }
}
