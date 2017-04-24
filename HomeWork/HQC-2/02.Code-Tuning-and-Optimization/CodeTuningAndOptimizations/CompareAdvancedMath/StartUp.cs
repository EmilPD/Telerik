namespace CompareAdvancedMath
{
    using System;

    using Utils;

    public class StartUp
    {
        public static void Main()
        {
            int repetitions = 10000000;

            // Square root
            Console.WriteLine($"Time for calculating Sqrt of {repetitions} Floats is: " + Measure.Start<float>(((x) => (float)Math.Sqrt(x)), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for calculating Sqrt of {repetitions} Doubles is: " + Measure.Start<double>(((x) => Math.Sqrt(x)), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for calculating Sqrt of {repetitions} Decimals is: " + Measure.Start<decimal>(((x) => (decimal)Math.Sqrt((double)x)), repetitions) + " miliseconds!");
            Console.WriteLine();

            // Natural logarithm
            Console.WriteLine($"Time for calculating Log of {repetitions} Floats is: " + Measure.Start<float>(((x) => (float)Math.Log(++x)), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for calculating Log of {repetitions} Doubles is: " + Measure.Start<double>(((x) => Math.Log(++x)), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for calculating Log of {repetitions} Decimals is: " + Measure.Start<decimal>(((x) => (decimal)Math.Log((double)(++x))), repetitions) + " miliseconds!");
            Console.WriteLine();

            // Sinus
            Console.WriteLine($"Time for calculating Sin of {repetitions} Floats is: " + Measure.Start<float>(((x) => (float)Math.Sin(x)), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for calculating Sin of {repetitions} Doubles is: " + Measure.Start<double>(((x) => Math.Sin(x)), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for calculating Sin of {repetitions} Decimals is: " + Measure.Start<decimal>(((x) => (decimal)Math.Sin((double)x)), repetitions) + " miliseconds!");
        }
    }
}
