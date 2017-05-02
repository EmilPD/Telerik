namespace GameFifteen
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number between 1 and 100");
            int size = int.Parse(Console.ReadLine());

            var startPosition = new Coordinates(0, 0);
            var startDirection = new Direction(1, 1);
            var matrix = new WalkInMatrix(size);

            var utils = new Utils(matrix, startPosition, startDirection);
            utils.Fill();
            utils.Print();
        }
    }
}
