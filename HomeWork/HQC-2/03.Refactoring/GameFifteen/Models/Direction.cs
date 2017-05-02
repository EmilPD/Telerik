namespace GameFifteen.Models
{
    using System;
    using GameFifteen.Contracts;

    public class Direction : IDirection
    {
        private int directionX;
        private int directionY;

        public Direction(int directionX, int directionY)
        {
            this.DirectionX = directionX;
            this.DirectionY = directionY;
        }

        public int DirectionX
        {
            get
            {
                return this.directionX;
            }

            set
            {
                if (value < -1 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("DirectionX must be between -1 and 1!");
                }

                this.directionX = value;
            }
        }

        public int DirectionY
        {
            get
            {
                return this.directionY;
            }

            set
            {
                if (value < -1 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("DirectionY must be between -1 and 1!");
                }

                this.directionY = value;
            }
        }
    }
}
