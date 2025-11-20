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
     * Complete the 'pangrams' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string pangrams(string s)
    {
        var countUniqueLetters = s.ToLower()
                                  .Replace(" ", "")
                                  .Distinct()
                                  .Count();

        if (countUniqueLetters == 26)
            return "pangram";

        return "not pangram";
    }

    public static string pangrams2(string s)
    {
        var uniqueChars = new HashSet<char>();
        var characters = s.ToLower().ToCharArray().Where(Char.IsLetter);

        foreach (var character in characters)
            uniqueChars.Add(character);

        if (uniqueChars.Count == 26)
            return "pangram";

        return "not pangram";
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.pangrams(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
