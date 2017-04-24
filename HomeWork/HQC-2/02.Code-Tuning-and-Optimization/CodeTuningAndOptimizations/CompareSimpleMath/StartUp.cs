namespace CompareMath
{
    using System;

    using Utils;

    public class StartUp
    {
        public static void Main()
        {
            int repetitions = 10000000;

            // Adding
            Console.WriteLine($"Time for adding {repetitions} Integers is: " + Measure.Start<int>(((x) => x + x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for adding {repetitions} Longs is: " + Measure.Start<long>(((x) => x + x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for adding {repetitions} Floats is: " + Measure.Start<float>(((x) => x + x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for adding {repetitions} Doubles is: " + Measure.Start<double>(((x) => x + x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for adding {repetitions} Decimals is: " + Measure.Start<decimal>(((x) => x + x), repetitions) + " miliseconds!");
            Console.WriteLine();

            // Subtracting
            Console.WriteLine($"Time for subtracting {repetitions} Integers is: " + Measure.Start<int>(((x) => x - x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for subtracting {repetitions} Longs is: " + Measure.Start<long>(((x) => x - x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for subtracting {repetitions} Floats is: " + Measure.Start<float>(((x) => x - x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for subtracting {repetitions} Doubles is: " + Measure.Start<double>(((x) => x - x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for subtracting {repetitions} Decimals is: " + Measure.Start<decimal>(((x) => x - x), repetitions) + " miliseconds!");
            Console.WriteLine();

            // Incrementing
            Console.WriteLine($"Time for incrementing {repetitions} Integers is: " + Measure.Start<int>(((x) => x++), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for incrementing {repetitions} Longs is: " + Measure.Start<long>(((x) => x++), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for incrementing {repetitions} Floats is: " + Measure.Start<float>(((x) => x++), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for incrementing {repetitions} Doubles is: " + Measure.Start<double>(((x) => x++), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for incrementing {repetitions} Decimals is: " + Measure.Start<decimal>(((x) => x++), repetitions) + " miliseconds!");
            Console.WriteLine();

            // Multiplying
            Console.WriteLine($"Time for multiplying {repetitions} Integers is: " + Measure.Start<int>(((x) => x * x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for multiplying {repetitions} Longs is: " + Measure.Start<long>(((x) => x * x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for multiplying {repetitions} Floats is: " + Measure.Start<float>(((x) => x * x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for multiplying {repetitions} Doubles is: " + Measure.Start<double>(((x) => x * x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for multiplying {repetitions} Decimals is: " + Measure.Start<decimal>(((x) => x * x), repetitions) + " miliseconds!");
            Console.WriteLine();

            // Dividing
            Console.WriteLine($"Time for dividing {repetitions} Integers is: " + Measure.Start<int>(((x) => x / ++x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for dividing {repetitions} Longs is: " + Measure.Start<long>(((x) => x / ++x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for dividing {repetitions} Floats is: " + Measure.Start<float>(((x) => x / ++x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for dividing {repetitions} Doubles is: " + Measure.Start<double>(((x) => x / ++x), repetitions) + " miliseconds!");
            Console.WriteLine($"Time for dividing {repetitions} Decimals is: " + Measure.Start<decimal>(((x) => x / ++x), repetitions) + " miliseconds!");
        }
    }
}
