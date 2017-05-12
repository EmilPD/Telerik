using System;
using NUnit.Framework;
using Moq;
using ProjectManager.Common.Contracts;
using ProjectManager.Common;

namespace ProjectManagerTests
{
    [TestFixture]
    public class Start
    {
        [Test]
        public void ShouldWritesAStringContainingSomethingHappened_WhenGenericExceptionOccurs()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var processor = new Mock<ICommandProcessor>();
            var reader = new Mock<IReader>();

            reader.Setup((x) => x.ReadLine()).Returns("CreateTa 0 0 BuildTheStar Pending");
            var writer = new Mock<IWriter>();

            var engine = new Engine(logger.Object, processor.Object, reader.Object, writer.Object);

            // Act
            engine.Start();

            var result = Assert.Throws<Exception>(() => engine.Start());
            var expectedMessage = result.Message;

            Assert.That(expectedMessage.Contains("something happened"));
        }

        [Test]
        public void ShouldWritesTheCommandExecutionResult_WhenValidCommandPassed()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var processor = new Mock<ICommandProcessor>();
            var reader = new Mock<IReader>();

            reader.Setup((x) => x.ReadLine()).Returns("CreateProject DeathStar 2016-1-1 2018-05-04 Active");
            var writer = new Mock<IWriter>();
            
            var engine = new Engine(logger.Object, processor.Object, reader.Object, writer.Object);

            // Act
            engine.Start();

            // Assert
            writer.Verify(x => x.WriteLine(It.IsAny<String>()), Times.Exactly(1));
        }

    }
}
