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
            LoggerProvider.Logger.Value = new FileLogger("temp.txt", LogLevel.All);
            
            Fraction[][] A = 
            {
                new Fraction[] { 1, 2, -1, 2, 4 },
                new Fraction[] { 0, -1, 2, 1, 3 },
                new Fraction[] { 1, -3, 2, 2, 0 }
            };

            double[] ToDouble(Fraction[] fr) => fr.Select(e => (double) e).ToArray();

            LoggerProvider.Logger.Value.Log(nameof(A), A.Select(ToDouble).ToArray(), LogLevel.All);


            Fraction[] b = { 1, 3, 4 };
            Fraction[] c = { 1, -3, 2, 1, 4 };
            LoggerProvider.Logger.Value.Log(nameof(b), ToDouble(b), LogLevel.All);
            LoggerProvider.Logger.Value.Log(nameof(c), ToDouble(c), LogLevel.All);

            //Simplex simplexMatrix = new Simplex(A, b, c);
            //Console.WriteLine(string.Join(" ",  simplexMatrix.Plan));

            double[] producers = { 120, 280, 160 };
            double[] consumers = { 130, 220, 60, 70 };
            double[][] tariffs =
            {
                new double[] { 1, 7, 9, 5 },
                new double[] { 4, 2, 6, 8 },
                new double[] { 3, 8, 1, 2 }
            };
            LoggerProvider.Logger.Value.Log(nameof(tariffs), tariffs, LogLevel.All);

            TransportationMatrix transportation = new TransportationMatrix(producers, consumers, tariffs);
            transportation.Plan.Dump<double>();

            LoggerProvider.Logger.Value.Save();
        }
    }
}
