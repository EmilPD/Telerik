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
    public class DirectionTests
    {
        [TestCase(-2, 1)]
        [TestCase(2, 1)]
        [TestCase(20, 1)]
        public void
        Constructor_WhenPassedDirectionXIsOutOfRange_ShouldThrowArgumentOutOfRangeException(int dirX, int dirY)
        {
            // Arrange
            var expectedMessage = "DirectionX";

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => new Direction(dirX, dirY));
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [TestCase(1, -2)]
        [TestCase(1, 2)]
        [TestCase(1, 20)]
        public void
        Constructor_WhenPassedDirectionYIsOutOfRange_ShouldThrowArgumentOutOfRangeException(int dirX, int dirY)
        {
            // Arrange
            var expectedMessage = "DirectionY";

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => new Direction(dirX, dirY));
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [TestCase(1, 1)]
        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        public void
        Constructor_WhenPassedDirectionXIsInRange_ShouldAssignTheAppropriateValues(int dirX, int dirY)
        {
            // Arrange
            var expectedDirectionXValue = dirX;

            // Act
            var direction = new Direction(dirX, dirY);
            var actualDirectionXValue = direction.DirectionX;

            // Assert
            Assert.AreEqual(expectedDirectionXValue, actualDirectionXValue);
        }

        [TestCase(1, 1)]
        [TestCase(1, 0)]
        [TestCase(1, -1)]
        public void
        Constructor_WhenPassedDirectionYIsInRange_ShouldAssignTheAppropriateValues(int dirX, int dirY)
        {
            // Arrange
            var expectedDirectionYValue = dirY;

            // Act
            var direction = new Direction(dirX, dirY);
            var actualDirectionYValue = direction.DirectionY;

            // Assert
            Assert.AreEqual(expectedDirectionYValue, actualDirectionYValue);
        }

        [TestCase(1, 1)]
        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        public void
        DirectionXProperty_WhenIsValid_ShouldBeSetAppropriately(int dirX, int dirY)
        {
            // Arrange
            var expectedDirectionXValue = dirX;
            var direction = new Direction(0, 0);

            // Act
            direction.DirectionX = dirX;
            var actualDirectionXValue = direction.DirectionX;

            // Assert
            Assert.AreEqual(expectedDirectionXValue, actualDirectionXValue);
        }

        [TestCase(1, 1)]
        [TestCase(1, 0)]
        [TestCase(1, -1)]
        public void
        DirectionYProperty_WhenIsValid_ShouldBeSetAppropriately(int dirX, int dirY)
        {
            // Arrange
            var expectedDirectionYValue = dirY;
            var direction = new Direction(0, 0);

            // Act
            direction.DirectionY = dirY;
            var actualDirectionYValue = direction.DirectionY;

            // Assert
            Assert.AreEqual(expectedDirectionYValue, actualDirectionYValue);
        }

        [TestCase(-2, 1)]
        [TestCase(2, 1)]
        [TestCase(20, 1)]
        public void
        DirectionXProperty_WhenIsInvalid_ShouldThrowArgumentOutOfRangeException(int dirX, int dirY)
        {
            // Arrange
            var expectedMessage = "DirectionX";
            var direction = new Direction(0, 0);

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => direction.DirectionX = dirX);
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [TestCase(1, -2)]
        [TestCase(1, 2)]
        [TestCase(1, 20)]
        public void
        DirectionYProperty_WhenIsInvalid_ShouldThrowArgumentOutOfRangeException(int dirX, int dirY)
        {
            // Arrange
            var expectedMessage = "DirectionY";
            var direction = new Direction(0, 0);

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => direction.DirectionY = dirY);
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }
    }
}
