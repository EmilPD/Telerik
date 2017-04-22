namespace ExceptionsHomework.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Utils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array is not initialized!");
            }

            if (startIndex < 0 || startIndex >= arr.Length)
            {
                throw new ArgumentOutOfRangeException($"startIndex should be number between 0 and {arr.Length}!");
            }

            if (count + startIndex > arr.Length)
            {
                throw new ArgumentOutOfRangeException($"Count should be number between 0 and {arr.Length - startIndex}!");
            }

            List<T> result = new List<T>();

            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (str == null)
            {
                throw new ArgumentNullException("String is not initialized!");
            }

            if (str == string.Empty)
            {
                throw new ArgumentException("String should not be empty!");
            }

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException($"Count should be equal or smaller than {str.Length}!");
            }

            StringBuilder result = new StringBuilder();

            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
