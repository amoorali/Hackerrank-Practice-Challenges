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
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        int pos = 0; int neg = 0; int zero = 0;

        foreach (var i in arr)
        {
            if (i > 0) pos++;
            else if (i < 0) neg++;
            else zero++;
        }

        Console.WriteLine(String.Format("{0:N6}\n{1:N6}\n{2:N6}", (decimal)pos / arr.Count,
                                                                  (decimal)neg / arr.Count,
                                                                  (decimal)zero / arr.Count));

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
