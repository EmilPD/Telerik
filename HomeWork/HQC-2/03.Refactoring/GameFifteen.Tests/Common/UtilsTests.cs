namespace GameFifteen.Tests.Common
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Contracts;
    using GameFifteen.Models;
    using GameFifteen.Tests.Common.Mock;
    using Moq;
    using NUnit.Framework;
    
    [TestFixture]
    public class UtilsTests
    {
        [Test]
        public void
        Constructor_WhenPassedMatrixIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var expectedMessage = "Matrix";
            var startPositionMock = new Mock<ICoordinates>();
            var startDirectionMock = new Mock<IDirection>();
            WalkInMatrix matrix = null;

            // Act & Assert
            var result = Assert.Throws<ArgumentNullException>(
              () => new Utils(matrix, startPositionMock.Object, startDirectionMock.Object));
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [Test]
        public void
        Constructor_WhenPassedStartPositionIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var expectedMessage = "Start position";
            ICoordinates startPosition = null;
            var startDirectionMock = new Mock<IDirection>();
            var matrixMock = new Mock<IMatrix>();

            // Act & Assert
            var result = Assert.Throws<ArgumentNullException>(
              () => new Utils(matrixMock.Object, startPosition, startDirectionMock.Object));
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [Test]
        public void
        Constructor_WhenPassedStartDirectionIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var expectedMessage = "Start direction";
            var startPositionMock = new Mock<ICoordinates>();
            Direction startDirection = null;
            var matrixMock = new Mock<IMatrix>();

            // Act & Assert
            var result = Assert.Throws<ArgumentNullException>(
              () => new Utils(matrixMock.Object, startPositionMock.Object, startDirection));
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [Test]
        public void
        Constructor_WhenMatrixIsNotNull_ShouldAssignPassedValue()
        {
            // Arrange
            var expectedMatrixSize = 6;
            var matrixMock = new Mock<IMatrix>();
            matrixMock.Setup(x => x.Size).Returns(expectedMatrixSize);

            var startPositionMock = new Mock<ICoordinates>();
            startPositionMock.SetupSet(x => x.PositionX = 1);
            startPositionMock.SetupSet(y => y.PositionY = 1);

            var startDirectionMock = new Mock<IDirection>();
            startDirectionMock.Setup(x => x.DirectionX).Returns(1);
            startDirectionMock.Setup(y => y.DirectionY).Returns(1);

            // Act
            var utils = new MockUtils(matrixMock.Object, startPositionMock.Object, startDirectionMock.Object);
            var actualMatrix = utils.MatrixPublic;
            var actualMatrixSize = utils.MatrixPublic.Size;

            // Assert
            Assert.AreSame(matrixMock.Object, actualMatrix);
            Assert.AreEqual(expectedMatrixSize, actualMatrixSize);
        }

        [Test]
        public void
        Constructor_WhenStartPositionIsNotNull_ShouldAssignPassedValue()
        {
            // Arrange
            var matrixMock = new Mock<IMatrix>();
            matrixMock.Setup(x => x.Size).Returns(6);

            var startPositionMock = new Mock<ICoordinates>();
            startPositionMock.SetupSet(x => x.PositionX = 1);
            startPositionMock.SetupSet(y => y.PositionY = 1);

            var startDirectionMock = new Mock<IDirection>();
            startDirectionMock.Setup(x => x.DirectionX).Returns(1);
            startDirectionMock.Setup(y => y.DirectionY).Returns(1);

            // Act
            var utils = new MockUtils(matrixMock.Object, startPositionMock.Object, startDirectionMock.Object);
            var actualStartPosition = utils.StartPositionPublic;

            // Assert
            Assert.AreSame(startPositionMock.Object, actualStartPosition);
        }

        [Test]
        public void
        Constructor_WhenStartDirectionIsNotNull_ShouldAssignPassedValue()
        {
            // Arrange
            var matrixMock = new Mock<IMatrix>();
            matrixMock.Setup(x => x.Size).Returns(6);

            var startPositionMock = new Mock<ICoordinates>();
            startPositionMock.SetupSet(x => x.PositionX = 1);
            startPositionMock.SetupSet(y => y.PositionY = 1);

            var startDirectionMock = new Mock<IDirection>();
            startDirectionMock.Setup(x => x.DirectionX).Returns(1);
            startDirectionMock.Setup(y => y.DirectionY).Returns(1);

            // Act
            var utils = new MockUtils(matrixMock.Object, startPositionMock.Object, startDirectionMock.Object);
            var actualStartDirection = utils.StartDirectionPublic;

            // Assert
            Assert.AreSame(startDirectionMock.Object, actualStartDirection);
        }

        [TestCase(6, 5, 5, 6)]
        [TestCase(6, 0, 5, 20)]
        [TestCase(6, 5, 0, 11)]
        [TestCase(5, 4, 4, 5)]
        [TestCase(5, 0, 4, 16)]
        [TestCase(5, 4, 0, 9)]
        public void
        Fill_ShouldFillMatrixAsExpected(int size, int posX, int posY, int expectedResult)
        {
            // Arrange
            var matrixSize = size;
            var matrix = new WalkInMatrix(matrixSize);

            var startPosition = new Coordinates(0, 0);
            var startDirection = new Direction(1, 1);

            // Act
            var utils = new Utils(matrix, startPosition, startDirection);
            utils.Fill();
            int actualValue = matrix.Matrix[posX, posY];

            // Assert
            Assert.AreEqual(expectedResult, actualValue);
        }
    }
}
