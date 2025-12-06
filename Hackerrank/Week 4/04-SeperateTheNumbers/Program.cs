using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'separateNumbers' function below.
     *
     * The function accepts STRING s as parameter.
     */

    public static void separateNumbers(string s)
    {
        for (var index = 1; index <= s.Length / 2; index++)
        {
            if (s.Length == 1 || s[0] == '0')
                break;

            var subset = s.Substring(0, index);
            var beautifulString = new StringBuilder();

            if (subset == "0")
                continue;

            if (!long.TryParse(subset, out long startingNumber))
                break;

            for (var i = 0; beautifulString.Length < s.Length; i++)
            {
                beautifulString.Append(startingNumber++);
            }

            if (beautifulString.ToString() == s)
            {
                Console.WriteLine($"YES {subset}");
                return;
            }
        }

        Console.WriteLine("NO");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            Result.separateNumbers(s);
        }
    }
}
