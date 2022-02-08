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
     * Complete the 'twoArrays' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY A
     *  3. INTEGER_ARRAY B
     */

    public static string twoArrays(int k, List<int> A, List<int> B)
    {
        int sumA = 0;
        int sumB = 0;
        int n = A.Count();  // number of elements

        foreach (var item in A)
        {
            sumA += item;
        }

        foreach (var item in B)
        {
            sumB += item;
        }

        if ((sumA + sumB) < (n*k) )
        {
            return "NO";
        }
        else if (sumA + sumB == (n * k))
        {
            if (A.Max() > 2 * k || B.Max() > 2 * k)
            {
                return "NO";
            }
            
        }
        else if ((A.Max() + B.Min() < k) || (A.Min() +  B.Max() < k))
        {
            return "NO";
        }

        return "YES";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

            List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

            string result = Result.twoArrays(k, A, B);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
