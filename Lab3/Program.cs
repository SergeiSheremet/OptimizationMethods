using System;
using System.Linq;
using System.Threading;
using Lab3.Logger;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerProvider.SetLogger(new FileLogger("temp.txt", LogLevel.Data));

            Fraction[][] A =
            {
                new Fraction[] { 1, 2, -1, 2, 4 },
                new Fraction[] { 0, -1, 2, 1, 3 },
                new Fraction[] { 1, -3, 2, 2, 0 },
            };
            Fraction[] b = { 1, 3, 4 };
            Fraction[] c = { 1, 3, 2, 1, 4 };

            Simplex simplexMatrix = new Simplex(A, b, c);
            LoggerProvider.Logger.Log(nameof(simplexMatrix), simplexMatrix.Plan, LogLevel.Data);

            double[] producers = { 50, 30, 10 };
            double[] consumers = { 30, 30, 10, 20 };
            double[][] tariffs =
            {
                new double[] { 1, 2, 4, 1 },
                new double[] { 2, 3, 1, 5 },
                new double[] { 3, 2, 4, 4 }
            };

            var transportation = new TransportationMatrix(producers, consumers, tariffs);
            LoggerProvider.Logger.Log(nameof(transportation), transportation.Plan, LogLevel.Data);
        }
    }
}
