namespace GameFifteen.Models
{
    using System;
    using GameFifteen.Contracts;

    public class WalkInMatrix : IMatrix
    {
        private const int MIN_SIZE = 1;
        private const int MAX_SIZE = 100;
        private int size;
        private int[,] matrix;

        public WalkInMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < MIN_SIZE || value > MAX_SIZE)
                {
                    throw new ArgumentOutOfRangeException($"Size must be in range {MIN_SIZE} and {MAX_SIZE}");
                }

                this.size = value;
            }
        }

        public int[,] Matrix
        {
            get
            {
                return this.matrix;
            }
        }
    }
}
