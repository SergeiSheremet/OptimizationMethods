﻿using System;
using System.Linq;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] A = 
            {
                { 1, 2, -1, 2, 4 },
                { 0, -1, 2, 1, 3 },
                { 1, -3, 2, 2, 0 }
            };

            double[] b = { 1, 3, 4 };
            double[] c = { 1, -3, 2, 1, 4 };

            double[,] simplexTable = new double[A.GetLength(0) + 1, A.GetLength(1) - A.GetLength(0) + 1];
        }
    }
}