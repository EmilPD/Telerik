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
    public class WalkInMatrixTests
    {
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(101)]
        public void
        Constructor_WhenPassedSizeIsOutOfRange_ShouldThrowArgumentOutOfRangeException(int size)
        {
            // Arrange 
            var expectedMessage = "Size";

            // Act & Assert
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => new WalkInMatrix(size));
            var actualMessage = result.Message;

            // Assert
            StringAssert.Contains(expectedMessage, actualMessage);
        }

        [TestCase(1)]
        [TestCase(45)]
        [TestCase(100)]
        public void
        Constructor_WhenPassedSizeIsValid_ShouldAssignTheAppropriateValues(int size)
        {
            // Arrange 
            var expectedSizeValue = size;

            // Act
            var matrix = new WalkInMatrix(size);
            var actualSizeValue = matrix.Size;

            // Assert
            Assert.AreEqual(expectedSizeValue, actualSizeValue);
        }

        [TestCase(1)]
        [TestCase(45)]
        [TestCase(100)]
        public void
        Constructor_WhenPassedSizeIsValid_ShouldCreateSquareMatrixWithSameSize(int size)
        {
            // Arrange 
            var expectedMatrixLength0 = size;
            var expectedMatrixLength1 = size;
            var matrix = new WalkInMatrix(size);

            // Act
            var actualMatrixLength0 = matrix.Matrix.GetLength(0);
            var actualMatrixLength1 = matrix.Matrix.GetLength(1);

            // Assert
            Assert.AreEqual(expectedMatrixLength0, actualMatrixLength0);
            Assert.AreEqual(expectedMatrixLength1, actualMatrixLength1);
        }
    }
}
