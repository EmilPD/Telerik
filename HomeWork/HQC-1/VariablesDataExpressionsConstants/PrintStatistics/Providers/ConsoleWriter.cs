﻿namespace StatisticalAnalysis.Providers
{
    using System;

    using StatisticalAnalysis.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(string line)
        {
            Console.Write(line);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}