namespace RefactoringLoop
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int size = 100;
            int expectedValue = 20;
            int[] numbers = new int[size];
            bool isFound = false;

            for (int i = 0; i < size; i++)
            {
                if (i % 10 == 0 && numbers[i] == expectedValue)
                {
                    isFound = true;
                }
            }

            if (isFound)
            {
                Console.WriteLine("Value found!");
            }
        }
    }
}
