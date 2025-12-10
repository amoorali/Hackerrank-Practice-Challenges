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
     * Complete the 'lonelyinteger' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int lonelyinteger(List<int> a)
    {
        var frequency = new Dictionary<int, int>();
        for (int i = 0; i < a.Count; i++)
        {
            if (frequency.ContainsKey(a[i]))
                frequency[a[i]]++;
            else
                frequency[a[i]] = 1;
        }

        for (int i = 0; i < frequency.Count; i++)
        {
            var temp = frequency.ElementAt(i);
            if (temp.Value == 1)
                return temp.Key;
        }

        return 0;
    }

    public static int Lonelyinteger(List<int> a)
    {
        var frequency = new HashSet<int>();

        foreach (var number in a)
        {
            if (frequency.Contains(number))
                frequency.Remove(number);
            else
                frequency.Add(number);
        }

        return frequency.First();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.lonelyinteger(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
