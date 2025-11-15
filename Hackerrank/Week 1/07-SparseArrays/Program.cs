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
     * Complete the 'matchingStrings' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY strings
     *  2. STRING_ARRAY queries
     */

     public static List<int> matchingStrings1(List<string> strings, List<string> queries)
    {
        var freq = new int[queries.Count];
        foreach (string s in strings)
        {
            for (int i = 0; i < queries.Count; i++)
            {
                if (s.Equals(queries[i]))
                    freq[i]++;
            }
        }

        return freq.ToList();
    }

    public static List<int> matchingStrings2(List<string> strings, List<string> queries)
    {
        var strings_dict = new Dictionary<string, int>();
        var freq = new int[queries.Count];

        foreach (string s in strings)
        {
            if (strings_dict.ContainsKey(s))
                strings_dict[s]++;
            else
                strings_dict[s] = 1;
        }

        for (int i = 0; i < queries.Count; i++)
        {
            if (strings_dict.ContainsKey(queries[i]))
                freq[i] = strings_dict[queries[i]];
        }

        return freq.ToList();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int stringsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> strings = new List<string>();

        for (int i = 0; i < stringsCount; i++)
        {
            string stringsItem = Console.ReadLine();
            strings.Add(stringsItem);
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> queries = new List<string>();

        for (int i = 0; i < queriesCount; i++)
        {
            string queriesItem = Console.ReadLine();
            queries.Add(queriesItem);
        }

        List<int> res = Result.matchingStrings1(strings, queries);

        textWriter.WriteLine(String.Join("\n", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
