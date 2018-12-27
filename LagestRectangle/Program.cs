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

class Solution
{

    // Complete the largestRectangle function below.

    // logic 1: (does not work)
    // if 1st element in array is the height, then width will be array.Length
    // if 2nd element in array is the height, then width will be array.Length - 1
    // so on and so forth, calcuate each h and w combination and then find the max

    //     static long largestRectangle(int[] h) {
    //         var allPossibleArea = new List<long>();

    //         // sort array from smallet to largest
    //         // it prevents using wrong height when input is not sorted
    //         // example: 11 11 10 10 10
    //         // if not sorted, it will use 11 as height
    //         // but 3rd, 4th, 5th building only has max 10

    //         Array.Sort(h, (x, y) => x.CompareTo(y));

    //         for (var i = 0; i < h.Length; i++)
    //         {
    //             var area = h[i] * (h.Length - i);
    //             allPossibleArea.Add(area);
    //         }

    //         return allPossibleArea.Max(a => a);
    //     }        

    // logic 2: (does not work)
    // start with 1st element, the width will be array.Length - 1
    // the height will be smallest value within the rest of elements
    // for array [6 2 5 4 5 1 6] 4(5) + 4 + 4(5) = 12. It does not take all the rest of elements.
    // need to find a stopping point.

    // logic 3: 
    // use each element in array as base
    // spread to the left side of base
    // spread to the right side of base
    // height is going to one of the element in the array
    static long largestRectangle(int[] h) {
        var n = h.Length;
        var LargestArea = 0L;
        for (var i = 0; i < n; i++)
        {
            var width = 1;
            for (var front = i - 1; front >= 0; front--) //向前扩增
            {
                if (h[front] >= h[i])
                    width++;
                else
                    break;
            }
            for (var back = i + 1; back < n; back++) //向后扩增
            {
                if (h[back] >= h[i])
                    width++;
                else
                    break;
            }

            var currentArea = width * h[i];
            if (LargestArea < currentArea)
                LargestArea = currentArea;
        }
        return LargestArea;
    }


    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = 7;

        //int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
        //;
        int[] h = new int[7] { 6,2,5,4,5,1,6 };

        long result = largestRectangle(h);

        Console.WriteLine(result);
    }
}
