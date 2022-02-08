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
     * Complete the 'birthday' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY s
     *  2. INTEGER d
     *  3. INTEGER m
     */

    public static int birthday(List<int> s, int d, int m)
    {
        int n = s.Count;
        int ttlSum = s.Sum();

        if (n < m)
        {
            return 0;
        }
        if (ttlSum < d)
        {
            return 0;
        }
        if (s.Min() > d)
        {
            return 0;
        }
        if (m > d)
        {
            return 0;
        }


            var result = 0;
            var windowSum = 0;
            for (var i = 0; i < m; ++i) // Establish first window
            {
                windowSum += s[i];
            }
            if (windowSum == d) // Edge case: check for first window
            {
                ++result;
            }
            for (var i = m; i < s.Count; ++i) // Traverse window to end
            {
                windowSum -= s[i - m];
                windowSum += s[i];
                if (windowSum == d)
                {
                    ++result;
                }
            }
            return result;
        

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int d = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.birthday(s, d, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

