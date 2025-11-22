using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solution
{
    class Solution
    {
        static void Main(string[] args)
        {
            var strings = new string[2];

            for (int i = 0; i < 2; i++)
                strings[i] = Console.ReadLine();

            var result = StringsXOR(strings);
            Console.WriteLine(result);
        }

        static string StringsXOR(string[] strings)
        {
            var s1 = strings[0];
            var s2 = strings[1];
            var result = new StringBuilder();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                    result.Append(0);
                else
                    result.Append(1);
            }

            return result.ToString();
        }

        static string StringsXOR2(string[] strings)
        {
            var s1 = strings[0];
            var s2 = strings[1];

            return new string(s1.Zip(s2, (num1, num2) => num1 == num2 ? '0' : '1').ToArray());
        }
    }
}