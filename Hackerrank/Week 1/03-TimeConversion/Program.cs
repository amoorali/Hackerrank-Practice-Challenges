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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        StringBuilder result = new StringBuilder();
        string time = s.Substring(0, s.Length - 2);
        string format = s.Substring(s.Length - 2);

        int hour = Int32.Parse(time.Substring(0, 2));
        string rest = time.Substring(2);

        if (format.ToLower().Equals("am"))
        {
            if (hour == 12) hour = 0;
        }
        else if (format.ToLower().Equals("pm"))
        {
            if (hour != 12)
                hour += 12;
        }
        return result.Append($"{hour:00}").Append(rest).ToString();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
