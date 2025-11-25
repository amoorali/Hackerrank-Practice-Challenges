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
     * Complete the 'maximumPerimeterTriangle' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY sticks as parameter.
     */

    public static List<int> maximumPerimeterTriangle(List<int> sticks)
    {
        var result = new List<int> { -1 };
        var nonDegenerates = new List<List<int>>();

        for (int i = 0; i < sticks.Count; i++)
        {
            for (int j = i + 1; j < sticks.Count; j++)
            {
                for (int k = j + 1; k < sticks.Count; k++)
                {
                    var a = sticks[i];
                    var b = sticks[j];
                    var c = sticks[k];

                    if (a + b > c && a + c > b && b + c > a)
                        nonDegenerates.Add(new List<int> { a, b, c });
                }
            }
        }

        if (nonDegenerates.Count != 0)
            result = nonDegenerates.MaxBy(l => l.Sum(x => (long)x));

        result.Sort();

        return result;
    }

    public static List<int> MaximumPerimeterTriangle(List<int> sticks)
    {
        sticks.Sort();

        for (int i = sticks.Count - 1; i >= 2; i--)
        {
            long a = sticks[i - 2];
            long b = sticks[i - 1];
            long c = sticks[i];

            if (a + b > c)
                return new List<int> { (int)a, (int)b, (int)c };
        }

        return new List<int> { -1 };
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> sticks = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sticksTemp => Convert.ToInt32(sticksTemp)).ToList();

        List<int> result = Result.maximumPerimeterTriangle(sticks);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
