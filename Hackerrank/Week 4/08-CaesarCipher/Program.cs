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
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
    {
        const string lowerCaseAlphabets = "abcdefghijklmnopqrstuvwxyz";
        const string upperCaseAlphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var lowerCaseCipher = lowerCaseAlphabets.Rotate(k);
        var upperCaseCipher = upperCaseAlphabets.Rotate(k);

        var map = new Dictionary<char, char>(s.Length);

        AddMap(map, lowerCaseAlphabets, lowerCaseCipher);
        AddMap(map, upperCaseAlphabets, upperCaseCipher);


        return s.Encrypt(map);
    }

    public static void AddMap(Dictionary<char, char> map, string alphabets, string cipher)
    {
        for (int i = 0; i < alphabets.Length; i++)
            map[alphabets[i]] = cipher[i];
    }

}

public static class StringExtensions
{
    public static string Rotate(this string s, int rotations)
    {
        rotations %= s.Length;

        if (string.IsNullOrEmpty(s) || rotations == 0)
            return s;

        return s.Substring(rotations) + s.Substring(0, rotations);
    }

    public static string Encrypt(this string s, Dictionary<char, char> map)
    {
        var chars = s.ToCharArray();

        for (var i = 0; i < s.Length; i++)
        {
            if (map.TryGetValue(chars[i], out var encryptedChar))
                chars[i] = encryptedChar;
        }

        return new string(chars);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
