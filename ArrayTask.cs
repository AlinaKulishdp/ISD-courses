using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstProgram
{
    class ArrayTask
    {
        public static Student[][] AllGroups()
        {
            string[] names = { "Alina", "Denis", "Oleg", "Victor", "Elena", "Tamara" };
            Random randomGenerator = new Random();

            Student[][] year = new Student[3][];
            year[0] = new Student[20];
            year[1] = new Student[15];
            year[2] = new Student[10];

            for (int i = 0; i < year.Length; i++)
            {
                for (int j = 0; j < year[i].Length; j++)
                {
                    int firstRating = randomGenerator.Next(5);
                    int secondRating = randomGenerator.Next(5);
                    year[i][j] = new Student(
                        names[randomGenerator.Next(names.Length - 1)],
                        new DateTime(randomGenerator.Next(1988, 2000), randomGenerator.Next(1, 12), randomGenerator.Next(1, 28)),
                        firstRating == 0 ? null : (int?)firstRating,
                        secondRating == 0 ? null : (int?)secondRating
                        );
                    Console.WriteLine(year[i][j]);
                }
            }

            for (int i = 0; i < year.Length; i++)
            {
                //http://stackoverflow.com/questions/12026344/how-to-use-array-sort-to-sort-an-array-of-structs-by-a-specific-element
                Array.Sort<Student>(year[i], (x, y) => x.birthDate.CompareTo(y.birthDate));
            }
            return year;
        }
        public static void GetStudents(Student[][] year)
        {
            int count = 0;
            for (int i = 0; i < year.Length; i++)
            {
                for (int j = 0; j < year[i].Length; j++)
                {
                    if (year[i][j].ratingNativeLanguage.HasValue && year[i][j].ratingForeignLanguage.HasValue)
                    {
                        count++;
                    }
                }
            }
            Tuple<string, int, int>[] attestedStudents = new Tuple<string, int, int>[count];
            count = 0;
            for (int i = 0; i < year.Length; i++)
            {
                for (int j = 0; j < year[i].Length; j++)
                {
                    if (year[i][j].ratingNativeLanguage.HasValue && year[i][j].ratingForeignLanguage.HasValue)
                    {
                        attestedStudents[count] = Tuple.Create(year[i][j].name, (int)year[i][j].ratingNativeLanguage, (int)year[i][j].ratingForeignLanguage);
                        count++;
                    }
                }
            }
            Array.ForEach(attestedStudents, element => Console.WriteLine("Данный студент сдал экзамены {0}", element));
            ListStudents(year);
        }

        public static void ListStudents(Student[][] year)
        {
            bool group1 = Array.TrueForAll(year[0], x => x.ratingNativeLanguage.HasValue && x.ratingForeignLanguage.HasValue);
            bool group2 = Array.TrueForAll(year[1], x => x.ratingNativeLanguage.HasValue && x.ratingForeignLanguage.HasValue);
            bool group3 = Array.TrueForAll(year[2], x => x.ratingNativeLanguage.HasValue && x.ratingForeignLanguage.HasValue);
            Console.WriteLine(group1 ? "Все студенты в группе 1 сдали экзамены" : "Не все студенты в группе 1 сдали экзамены");
            Console.WriteLine(group2 ? "Все студенты в группе 2 сдали экзамены" : "Не все студенты в группе 2 сдали экзамены");
            Console.WriteLine(group3 ? "Все студенты в группе 3 сдали экзамены" : "Не все студенты в группе 3 сдали экзамены");

        }
        public struct Student
        {
            public string name;
            public DateTime birthDate;
            public int? ratingNativeLanguage;
            public int? ratingForeignLanguage;
            public Student(string studentName, DateTime studentBirth, int? firstRating = null, int? secondRating = null)
            {
                name = studentName;
                birthDate = studentBirth;
                ratingNativeLanguage = firstRating;
                ratingForeignLanguage = secondRating;
            }
            public override string ToString()
            {
                return string.Format("{0} ({1}), {2}/{3}", name, birthDate.ToShortDateString(),
                    ratingNativeLanguage.HasValue ? ratingNativeLanguage.ToString() : "Не сдал",
                    ratingForeignLanguage.HasValue ? ratingForeignLanguage.ToString() : "Не сдал"
                    );
            }
        }

    }
}
