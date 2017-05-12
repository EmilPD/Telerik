using System;
using NUnit.Framework;
using Moq;
using ProjectManager.Common.Contracts;
using ProjectManager.Common;
using ProjectManager.Common.Commands;
using ProjectManager.Data.Contracts;
using System.Collections.Generic;

namespace ProjectManagerTests
{
    [TestFixture]
    public class Execute
    {
        [Test]
        public void ShouldThrohw_WhenInvalidParametersCount()
        {
            // Arrange
            var database = new Mock<IDatabase>();
            var modelsFactory = new Mock<IModelsFactory>();
            var list = new List<string>();

            var createTaskCommand = new CreateTaskCommand(database.Object, modelsFactory.Object);
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => createTaskCommand.Execute(list));
        }

        [Test]
        public void ShouldThrohw_WhenEmptyParametersArePassed()
        {
            // Arrange
            var database = new Mock<IDatabase>();
            var modelsFactory = new Mock<IModelsFactory>();
            var list = new List<string>();
            list.Add("edno");
            list.Add("dwe");
            list.Add("");

            var createTaskCommand = new CreateTaskCommand(database.Object, modelsFactory.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => createTaskCommand.Execute(list));
        }

    }
}
