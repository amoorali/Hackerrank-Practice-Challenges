using System;
using System.Collections.Generic;
using System.IO;

class Result
{
    static int[] monthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }

    static bool isLuckyDate(int day, int month, int year)
    {
        long dateValue = day;
        dateValue = dateValue * 100 + month;
        dateValue = dateValue * 10000 + year;

        return dateValue % 7 == 0 || dateValue % 4 == 0;
    }

    public static int findPrimeDates(string date1, string date2)
    {
        int day1 = int.Parse(date1.Substring(0, 2));
        int month1 = int.Parse(date1.Substring(3, 2));
        int year1 = int.Parse(date1.Substring(6, 4));

        int day2 = int.Parse(date2.Substring(0, 2));
        int month2 = int.Parse(date2.Substring(3, 2));
        int year2 = int.Parse(date2.Substring(6, 4));

        int count = 0;

        while (true)
        {
            if (isLuckyDate(day1, month1, year1))
                count++;

            if ((day1 == day2) &&
                (month1 == month2) &&
                (year1 == year2))
            {
                break;
            }

            int daysInMonth = monthDays[month1 - 1];

            if (month1 == 2 && IsLeapYear(year1))
                daysInMonth = 29;

            day1++;

            if (day1 > daysInMonth)
            {
                day1 = 1;
                month1++;

                if (month1 > 12)
                {
                    month1 = 1;
                    year1++;
                }
            }
        }

        return count;
    }
}

class Solution
{
    static void Main(String[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        Console.WriteLine(Result.findPrimeDates(input[0], input[1]));
    }
}