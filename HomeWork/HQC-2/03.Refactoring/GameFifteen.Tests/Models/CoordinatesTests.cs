namespace GameFifteen.Tests.Models
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Contracts;
    using GameFifteen.Models;
    using GameFifteen.Tests.Common.Mock;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CoordinatesTests
    {
        [TestCase(-1, 1)]
        [TestCase(100, 1)]
        public void
        Constructor_WhenPassedPositionXIsOutOfRange_ShouldThrowArgumentOutOfRangeException(int posX, int posY)
        {
            // Arrange
            var expectedMessage = "PositionX";

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => new Coordinates(posX, posY));
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [TestCase(1, -1)]
        [TestCase(1, 100)]
        public void
        Constructor_WhenPassedPositionYIsOutOfRange_ShouldThrowArgumentOutOfRangeException(int posX, int posY)
        {
            // Arrange
            var expectedMessage = "PositionY";

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => new Coordinates(posX, posY));
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [TestCase(0, 1)]
        [TestCase(45, 1)]
        [TestCase(99, 1)]
        public void
        PositionXProperty_WhenIsValid_ShouldBeSetAppropriately(int posX, int posY)
        {
            // Arrange
            var expectedPositionXValue = posX;
            var coords = new Coordinates(5, 5);

            // Act
            coords.PositionX = posX;
            var actualPositionXValue = coords.PositionX;

            // Assert
            Assert.AreEqual(expectedPositionXValue, actualPositionXValue);
        }

        [TestCase(1, 0)]
        [TestCase(1, 45)]
        [TestCase(1, 99)]
        public void
        PositionYProperty_WhenIsValid_ShouldBeSetAppropriately(int posX, int posY)
        {
            // Arrange
            var expectedPositionYValue = posY;
            var coords = new Coordinates(5, 5);

            // Act
            coords.PositionY = posY;
            var actualPositionYValue = coords.PositionY;

            // Assert
            Assert.AreEqual(expectedPositionYValue, actualPositionYValue);
        }

        [TestCase(-1, 1)]
        [TestCase(100, 1)]
        public void
        PositionXProperty_WhenIsInvalid_ShouldThrowArgumentOutOfRangeException(int posX, int posY)
        {
            // Arrange
            var expectedMessage = "PositionX";
            var coords = new Coordinates(0, 0);

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => coords.PositionX = posX);
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [TestCase(1, -1)]
        [TestCase(1, 100)]
        public void
        PositionYProperty_WhenIsInvalid_ShouldThrowArgumentOutOfRangeException(int posX, int posY)
        {
            // Arrange
            var expectedMessage = "PositionY";
            var coords = new Coordinates(0, 0);

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => coords.PositionY = posY);
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }
    }
}
