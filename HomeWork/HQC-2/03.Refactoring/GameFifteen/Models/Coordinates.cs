namespace GameFifteen.Models
{
    using System;
    using GameFifteen.Contracts;

    public class Coordinates : ICoordinates
    {
        private const int MIN_POSITION_VALUE = 0;
        private const int MAX_POSITION_VALUE = 99;
        private int positionX;
        private int positionY;

        public Coordinates(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }

        public int PositionX
        {
            get
            {
                return this.positionX;
            }

            set
            {
                if (value < MIN_POSITION_VALUE || value > MAX_POSITION_VALUE)
                {
                    throw new ArgumentOutOfRangeException($"PositionX must be in range {MIN_POSITION_VALUE} and {MAX_POSITION_VALUE}");
                }

                this.positionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return this.positionY;
            }

            set
            {
                if (value < MIN_POSITION_VALUE || value > MAX_POSITION_VALUE)
                {
                    throw new ArgumentOutOfRangeException($"PositionY must be in range {MIN_POSITION_VALUE} and {MAX_POSITION_VALUE}");
                }

                this.positionY = value;
            }
        }
    }
}
