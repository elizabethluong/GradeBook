﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("liz's Grade Book");
            
            while(true)
            {
                Console.WriteLine("Enter a grade of 'q' to quit");
                var input = Console.ReadLine();
                
                if(input == "q")
                {
                    break;
                }

                var grade = double.Parse(input);
                book.AddGrade(grade);
            }
            
            var stats = book.GetStatistics();
            Console.WriteLine($"The average grade is {stats.Average}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}