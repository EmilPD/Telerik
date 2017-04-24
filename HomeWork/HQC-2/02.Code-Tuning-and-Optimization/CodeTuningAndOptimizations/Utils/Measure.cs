namespace Utils
{
    using System;
    using System.Diagnostics;

    public static class Measure
    {
        public static double Start<T>(Func<T, T> func, int repetition)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < repetition; i++)
            {
                func(default(T));
            }

            stopwatch.Stop();
            return stopwatch.Elapsed.Milliseconds;
        }
    }
}
