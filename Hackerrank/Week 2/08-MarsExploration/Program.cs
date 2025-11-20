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
     * Complete the 'marsExploration' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int marsExploration(string s)
    {
        var realMessageLetters = "SOS".ToCharArray();
        var changedLettersCount = 0;
        var wordsCount = s.Count() / 3;

        for (int i = 0; i < wordsCount; i++)
        {
            var word = s.Skip(i * 3).Take(3).ToArray();

            for (int index = 0; index < 3; index++)
            {
                if (word[index] != realMessageLetters[index])
                    changedLettersCount++;
            }
        }

        return changedLettersCount;
    }

    public static int marsExploration2(string s)
    {
        var changedLettersCount = 0;

        for (int i = 0; i < s.Count(); i++)
        {
            var letter = s[i];

            if ((i % 3) == 1 && letter == 'O')
                continue;
            if (((i % 3) == 0 || (i % 3) == 2) && letter == 'S')
                continue;

            changedLettersCount++;
        }

        return changedLettersCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.marsExploration(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
