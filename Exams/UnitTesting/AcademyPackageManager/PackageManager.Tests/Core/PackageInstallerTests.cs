using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System.Collections.Generic;

namespace PackageManager.Tests.Core
{
  [TestFixture]
  public class PackageInstallerTests
  {
    [Test]
    public void
    Constructor_()
    {
      // Arrange
      string name = "name";
      string location = "location";

      var packageThree = new Mock<IPackage>();

      var dependencyMock = new Mock<ICollection<IPackage>>();
      dependencyMock.Object.Add(packageThree.Object);

      var packageToBeAdded = new Mock<IPackage>();
      packageToBeAdded.Setup(x => x.Name).Returns("package01");
      packageToBeAdded.Setup(x => x.Dependencies).Returns(dependencyMock.Object);

      var repositoryMock = new Mock<IRepository<IPackage>>();
      repositoryMock.Object.Add(packageToBeAdded.Object);

      var downloaderMock = new Mock<IDownloader>();

      var projectMock = new Mock<IProject>();
      projectMock.Setup(x => x.Location).Returns(location);
      projectMock.Setup(x => x.Name).Returns(name);
      projectMock.Setup(x => x.PackageRepository).Returns(repositoryMock.Object);

      // Act
      var packageInstaller = new PackageInstaller(downloaderMock.Object, projectMock.Object);

      // Assert

    }


  }
}
