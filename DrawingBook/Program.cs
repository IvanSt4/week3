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
     * Complete the 'pageCount' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER p
     */

    public static int pageCount(int n, int p)
    {       
        int pageCountFront = p / 2;
        int pageCountEnd;      

        if ((n%2 == 0 && p%2 == 0) || (n%2 != 0 && p%2 != 0) || (n%2 !=0 && p%2 == 0))
        {
            pageCountEnd = (n - p) / 2;
        }
        else
        {
            pageCountEnd = (n - p) / 2 + 1;
        }
        if (pageCountFront <= pageCountEnd)
        {
            
            return pageCountFront;
        }       
        return pageCountEnd;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.pageCount(n, p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
