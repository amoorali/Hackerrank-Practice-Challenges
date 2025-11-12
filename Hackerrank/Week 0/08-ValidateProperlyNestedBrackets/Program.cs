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
     * Complete the 'areBracketsProperlyMatched' function below.
     *
     * The function is expected to return a BOOLEAN.
     * The function accepts STRING code_snippet as parameter.
     */

    public static bool areBracketsProperlyMatched(string code_snippet)
    {
        var stack = new Stack<char>();

        var open_brackets = new HashSet<char>(new[] { '(', '{', '[' });
        var match = new Dictionary<char, char>
        {
            [')'] = '(',
            ['}'] = '{',
            [']'] = '['
        };

        foreach (var c in code_snippet)
        {
            if (open_brackets.Contains(c))
                stack.Push(c);

            else if (match.TryGetValue(c, out char expectedBracket))
            {
                if (stack.Count == 0 || stack.Pop() != expectedBracket)
                    return false;
            }
        }

        return stack.Count == 0;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string code_snippet = Console.ReadLine();

        bool result = Result.areBracketsProperlyMatched(code_snippet);

        Console.WriteLine((result ? 1 : 0));
    }
}
