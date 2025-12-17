using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int tests = int.Parse(Console.ReadLine());

        for (int i = 0; i < tests; i++)
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(IsSmartNumber(number));
        }
    }

    static string IsSmartNumber(int number)
    {
        return Math.Sqrt(number) * Math.Sqrt(number) == number ? "YES" : "NO";
    }
}
