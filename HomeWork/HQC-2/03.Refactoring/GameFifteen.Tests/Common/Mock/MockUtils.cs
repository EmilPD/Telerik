namespace GameFifteen.Tests.Common.Mock
{
    using GameFifteen.Common;
    using GameFifteen.Contracts;

    public class MockUtils : Utils
    {
        public MockUtils(IMatrix matrix, ICoordinates startPosition, IDirection startDirection) 
            : base(matrix, startPosition, startDirection)
        {
        }

        public IMatrix MatrixPublic
        {
            get
            {
                return this.Matrix;
            }
        }

        public ICoordinates StartPositionPublic
        {
            get
            {
                return this.StartPosition;
            }
        }

        public IDirection StartDirectionPublic
        {
            get
            {
                return this.StartDirection;
            }
        }
    }
}
