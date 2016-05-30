using System;
using System.Collections.Generic;

// Task1.2 Решить алгоритмическую задачу : 	Sort list or array by string length 

namespace Task1._2
{
    
    class SortList
    {
        private static List<string> MonthsOftheYear = new List<string> { "January", "Februry", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public static void ShowMonth(List<string> list)
        {
            foreach (string aMonth in list)
            {
                Console.WriteLine(aMonth);
            }

        }
         // Bubble sorting
        public static void SortMonths(List<string> monthsOftheYear)
        {
            for (int i = 0; i < (monthsOftheYear.Count); i++)
            {
                for (int j = 0; j < (monthsOftheYear.Count - 1); j++)
                {
                    if (monthsOftheYear[j].Length < monthsOftheYear[j + 1].Length)
                    {
                        string temp = monthsOftheYear[j];
                        monthsOftheYear[j] = monthsOftheYear[j + 1];
                        monthsOftheYear[j + 1] = temp;
                    }
                }

            }
        }

        static void Main(string[] args)
        {
           Console.WriteLine("List of months before sorting:");
           ShowMonth(MonthsOftheYear);

           // Sort
           SortMonths(MonthsOftheYear);

           Console.WriteLine("List of months after sorting:");
           ShowMonth(MonthsOftheYear);
           Console.ReadLine();
        }
    }
}
