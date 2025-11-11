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
     * Complete the 'isAlphabeticPalindrome' function below.
     *
     * The function is expected to return a BOOLEAN.
     * The function accepts STRING code as parameter.
     */

    public static bool isAlphabeticPalindrome(string code)
    {
        var s = new String(code.Where(c => Char.IsLetter(c)).ToArray()).ToLower();

        var len = s.Length;
        for (int i = 0; i < len; i++)
        {
            if (!s[i].Equals(s[len - i - 1]))
                return false;
        }

        return true;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string code = Console.ReadLine();

        bool result = Result.isAlphabeticPalindrome(code);

        Console.WriteLine((result ? 1 : 0));
    }
}
