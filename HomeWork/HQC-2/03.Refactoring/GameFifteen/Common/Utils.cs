namespace GameFifteen.Common
{
    using System;
    using GameFifteen.Contracts;
    using GameFifteen.Models;

    public class Utils
    {
        private readonly ICoordinates startPosition;
        private readonly IDirection startDirection;
        private ICoordinates currentPosition;
        private IDirection currentDirection;
        private int counter = 1;
        private IMatrix matrix;
        private int size;

        public Utils(IMatrix matrix, ICoordinates startPosition, IDirection startDirection)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix cannot be null!");
            }

            if (startPosition == null)
            {
                throw new ArgumentNullException("Start position cannot be null!");
            }

            if (startDirection == null)
            {
                throw new ArgumentNullException("Start direction cannot be null!");
            }

            this.size = matrix.Size;

            if (startPosition.PositionX >= this.size || startPosition.PositionY >= this.size)
            {
                throw new ArgumentOutOfRangeException("StartPosition must be in range 0 and 99");
            }

            this.startPosition = startPosition;
            this.startDirection = startDirection;
            this.matrix = matrix;
            this.currentPosition = startPosition;
            this.currentDirection = startDirection;
        }

        protected IMatrix Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        protected ICoordinates StartPosition
        {
            get
            {
                return this.startPosition;
            }
        }

        protected IDirection StartDirection
        {
            get
            {
                return this.startDirection;
            }
        }

        public void Fill()
        {
            this.currentPosition.PositionX = this.startPosition.PositionX;
            this.currentPosition.PositionY = this.startPosition.PositionY;
            this.matrix.Matrix[this.currentPosition.PositionX, this.currentPosition.PositionY] = this.counter;

            while (this.counter <= this.size * this.size)
            {
                this.matrix.Matrix[this.currentPosition.PositionX, this.currentPosition.PositionY] = this.counter;

                if (!this.HasAvailableMove())
                {
                    this.currentPosition = this.FindNextFreeCell();
                    if (this.currentPosition == null)
                    {
                        break;
                    }
                }

                if (this.HasToChangeDirection(this.currentPosition, this.currentDirection))
                {
                    while (this.HasToChangeDirection(this.currentPosition, this.currentDirection))
                    {
                        var newDirection = this.ChangeDirection(this.currentDirection);
                        this.currentDirection.DirectionX = newDirection.DirectionX;
                        this.currentDirection.DirectionY = newDirection.DirectionY;
                    }
                }

                this.currentPosition.PositionX += this.currentDirection.DirectionX;
                this.currentPosition.PositionY += this.currentDirection.DirectionY;
                this.counter++;
            }
        }

        public void Print()
        {
            for (int row = 0; row < this.size; row++)
            {
                for (int column = 0; column < this.size; column++)
                {
                    Console.Write("{0,4}", this.matrix.Matrix[row, column]);
                }

                Console.WriteLine();
            }
        }

        private bool HasAvailableMove()
        {
            var direction = this.currentDirection;

            for (int i = 0; i < 8; i++)
            {
                if (this.currentPosition.PositionX + direction.DirectionX < this.matrix.Matrix.GetLength(0) &&
                    this.currentPosition.PositionX + direction.DirectionX >= 0 &&
                    this.currentPosition.PositionY + direction.DirectionY < this.matrix.Matrix.GetLength(1) &&
                    this.currentPosition.PositionY + direction.DirectionY >= 0 &&
                    this.matrix.Matrix[this.currentPosition.PositionX + direction.DirectionX, this.currentPosition.PositionY + direction.DirectionY] == 0)
                {
                    return true;
                }
                else
                {
                    direction = this.ChangeDirection(direction);
                }
            }

            return false;
        }

        private ICoordinates FindNextFreeCell()
        {
            var nextFreeCellPosition = new Coordinates(0, 0);

            for (int foundPosX = 0; foundPosX < this.matrix.Matrix.GetLength(0); foundPosX++)
            {
                for (int foundPosY = 0; foundPosY < this.matrix.Matrix.GetLength(1); foundPosY++)
                {
                    if (this.matrix.Matrix[foundPosY, foundPosX] == 0)
                    {
                        nextFreeCellPosition.PositionX = foundPosX;
                        nextFreeCellPosition.PositionY = foundPosY;
                        return nextFreeCellPosition;
                    }
                }
            }

            return null;
        }

        private IDirection ChangeDirection(IDirection currentDirection)
        {
            var newDireciton = new Direction(currentDirection.DirectionX, currentDirection.DirectionY);

            if (currentDirection.DirectionX == 0 && currentDirection.DirectionY == 1)
            {
                newDireciton.DirectionX = 1;
                newDireciton.DirectionY = 1;

                return newDireciton;
            }

            if (currentDirection.DirectionX == 1 && currentDirection.DirectionY == 1)
            {
                newDireciton.DirectionX = 1;
                newDireciton.DirectionY = 0;

                return newDireciton;
            }

            if (currentDirection.DirectionX == 1 && currentDirection.DirectionY == 0)
            {
                newDireciton.DirectionX = 1;
                newDireciton.DirectionY = -1;

                return newDireciton;
            }

            if (currentDirection.DirectionX == 1 && currentDirection.DirectionY == -1)
            {
                newDireciton.DirectionX = 0;
                newDireciton.DirectionY = -1;

                return newDireciton;
            }

            if (currentDirection.DirectionX == 0 && currentDirection.DirectionY == -1)
            {
                newDireciton.DirectionX = -1;
                newDireciton.DirectionY = -1;

                return newDireciton;
            }

            if (currentDirection.DirectionX == -1 && currentDirection.DirectionY == -1)
            {
                newDireciton.DirectionX = -1;
                newDireciton.DirectionY = 0;

                return newDireciton;
            }

            if (currentDirection.DirectionX == -1 && currentDirection.DirectionY == 0)
            {
                newDireciton.DirectionX = -1;
                newDireciton.DirectionY = 1;

                return newDireciton;
            }

            if (currentDirection.DirectionX == -1 && currentDirection.DirectionY == 1)
            {
                newDireciton.DirectionX = 0;
                newDireciton.DirectionY = 1;

                return newDireciton;
            }

            return null;
        }

        private bool HasToChangeDirection(ICoordinates currentPosition, IDirection currentDirection)
        {
            return currentPosition.PositionX + currentDirection.DirectionX >= this.size ||
                currentPosition.PositionX + currentDirection.DirectionX < 0 ||
                currentPosition.PositionY + currentDirection.DirectionY >= this.size ||
                currentPosition.PositionY + currentDirection.DirectionY < 0 ||
                this.matrix.Matrix[currentPosition.PositionX + currentDirection.DirectionX, currentPosition.PositionY + currentDirection.DirectionY] != 0;
        }
    }
}
