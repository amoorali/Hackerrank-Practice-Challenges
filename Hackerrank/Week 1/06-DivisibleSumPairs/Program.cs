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
     * Complete the 'divisibleSumPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER_ARRAY ar
     */

    public static int divisibleSumPairs1(int n, int k, List<int> ar)
    {
        var count = 0;
        for (int i = 0; i < ar.Count - 1; i++)
        {
            for (int j = i + 1; j < ar.Count; j++)
            {
                if ((ar[i] + ar[j]) % k == 0)
                    count++;
            }
        }
        return count;
    }

    public static int divisibleSumPairs2(int n, int k, List<int> ar)
    {
        var freq = new Dictionary<int, int>();
        var count = 0;
        foreach (int num in ar)
        {
            var remainder = num % k;
            var complement = (k - remainder) % k;

            if (freq.ContainsKey(complement))
                count += freq[complement];

            if (freq.ContainsKey(remainder))
                freq[remainder]++;
            else
                freq[remainder] = 1;
        }

        return count;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.divisibleSumPairs1(n, k, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
