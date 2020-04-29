using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Schema;

// This program creates a grade book, takes grades and shows high, low and average grades.
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Grade Book One");
            book.GradeAdded += OnGradeAdded; // event

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"The category is {InMemoryBook.CATEGORY}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
            Console.WriteLine($"The name of the book is {book.Name}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter your grade score, between 0 and 100. Enter q to quit.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}