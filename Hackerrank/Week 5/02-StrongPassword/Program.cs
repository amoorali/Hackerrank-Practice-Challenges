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
     * Complete the 'minimumNumber' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING password
     */

    public static int minimumNumber(int n, string password)
    {
        var passwordLength = n;
        var missingCharacters = 0;

        var criteriaMethods =
            typeof(PassowrdExtension)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m =>
                    m.ReturnType == typeof(bool) &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters()[0].ParameterType == typeof(string));


        foreach (var method in criteriaMethods)
        {
            bool status = (bool)method.Invoke(null, new object[] { password });

            if (!status)
            {
                passwordLength++;
                missingCharacters++;
            }
        }

        missingCharacters += password.LengthCriteria(passwordLength);

        return missingCharacters;
    }

}

static class PassowrdExtension
{
    public static int LengthCriteria(this string password, int passwordLength)
    {
        const int minLength = 6;

        return Math.Max(0, minLength - passwordLength);
    }

    public static bool DigitCriteria(this string password)
    {
        var regex = new Regex(@"([0-9])+");
        return regex.IsMatch(password);
    }

    public static bool LowerCaseCriteria(this string password)
    {
        var regex = new Regex(@"([a-z])+");
        return regex.IsMatch(password);
    }

    public static bool UpperCaseCriteria(this string password)
    {
        var regex = new Regex(@"([A-Z])+");
        return regex.IsMatch(password);
    }

    public static bool SpecialCharacter(this string password)
    {
        var regex = new Regex(@"[!@#$%^&*()\-+]");
        return regex.IsMatch(password);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string password = Console.ReadLine();

        int answer = Result.minimumNumber(n, password);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
