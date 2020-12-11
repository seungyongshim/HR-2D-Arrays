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
using FluentAssertions;

class Solution
{

    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr)
    {
        var height = arr.Length;
        var width = arr[0].Length;

        return SumX(width, height, arr).OrderByDescending(x => x).First();


    }

    static IEnumerable<int> SumX(int width, int height, int[][] arr)
    {
        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {

                yield return arr[y][x]
                    + arr[y-1][x-1]
                    + arr[y - 1][x]
                    + arr[y - 1][x+1]
                    + arr[y + 1][x - 1]
                    + arr[y + 1][x ]
                    + arr[y + 1][x +1];
            }
        }
    }

    static void Main(string[] args)
    {
        int[][] arr = new int[6][];

            arr[0] = new int[] { 1, 1, 1, 0, 0, 0 };
            arr[1] = new int[] { 0, 1, 0, 0, 0, 0 };
            arr[2] = new int[] { 1, 1, 1, 0, 0, 0 };
            arr[3] = new int[] { 0, 0, 2, 4, 4, 0 };
            arr[4] = new int[] { 0, 0, 0, 2, 0, 0 };
            arr[5] = new int[] { 0, 0, 1, 2, 4, 0 };

        hourglassSum(arr).Should().Be(19);
    }
}
