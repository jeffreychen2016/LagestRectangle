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

    // logic 1: (wrong)
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

    // logic 2: (wrong)
    // start with 1st element, the width will be array.Length - 1
    // the height will be smallest value within the rest of elements
    // for array [6 2 5 4 5 1 6] 4(5) + 4 + 4(5) = 12. It does not take all the rest of elements.
    // need to find a stopping point.

    // logic 3: 
    // based on the logic of 1 & 2, 
    // start with 1st element, the width will be array.Length 
    // the width will be array.Length - number of elements from stopping point to the end - position of the starting point
    // the stopping point will be lowest value in the array
    // also need to find the starting point. The lowest value after taking off stopping point.
    // [6 2 5 4 5 1 6]

    static long largestRectangle(int[] h)
    {
        var n = 7;
        // Create an empty stack. The stack  
        // holds indexes of hist[] array  
        // The bars stored in stack are always  
        // in increasing order of their heights.  
        Stack<int> s = new Stack<int>();

        int max_area = 0; // Initialize max area 
        int tp; // To store top of stack 
        int area_with_top; // To store area with top  
                           // bar as the smallest bar 

        // Run through all bars of 
        // given histogram  
        int i = 0;
        while (i < n)
        {
            // If this bar is higher than the  
            // bar on top stack, push it to stack  
            if (s.Count == 0 || h[s.Peek()] <= h[i])
            {
                s.Push(i++);
            }

            // If this bar is lower than top of stack, 
            // then calculate area of rectangle with  
            // stack top as the smallest (or minimum   
            // height) bar. 'i' is 'right index' for  
            // the top and element before top in stack 
            // is 'left index'  
            else
            {
                tp = s.Peek(); // store the top index 
                s.Pop(); // pop the top 

                // Calculate the area with hist[tp] 
                // stack as smallest bar  
                area_with_top = h[tp] *
                               (s.Count == 0 ? i : i - s.Peek() - 1);

                // update max area, if needed  
                if (max_area < area_with_top)
                {
                    max_area = area_with_top;
                }
            }
        }
        return max_area;
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
