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
     * Complete the 'sockMerchant' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY ar
     */

    public static int sockMerchant(int n, List<int> ar)
    {
        var pairs = 0;
        var socksFrequency = new Dictionary<int, int>();

        foreach (var sock in ar)
        {
            if (socksFrequency.ContainsKey(sock))
                socksFrequency[sock]++;
            else
                socksFrequency[sock] = 1;
        }

        foreach (var sockCountPair in socksFrequency)
        {
            var count = sockCountPair.Value;

            pairs += (count / 2);
        }

        return pairs;
    }

    public static int SockMerchant(int n, List<int> ar)
    {
        var frequency = ar.GroupBy<int, int>(sock => sock).ToList();
        var pairsCount = 0;

        frequency.ForEach(p => pairsCount += p.ToList().Count / 2);

        return pairsCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
