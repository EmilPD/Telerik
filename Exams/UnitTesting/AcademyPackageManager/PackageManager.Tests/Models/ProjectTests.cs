using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;
using System;

namespace PackageManager.Tests.Models
{
  [TestFixture]
  public class ProjectTests
  {
    [Test]
    public void
    Constructor_ShouldSetsTheAppropriatePassedValues()
    {
      // Arrange
      string name = "name";
      string location = "location";
      var repositoryMock = new Mock<IRepository<IPackage>>();

      // Act
      var project = new Project(name, location, repositoryMock.Object);
      var actualName = project.Name;
      var actualLocation = project.Location;
      var actualRepository = project.PackageRepository;

      // Assert
      Assert.AreSame(name, actualName);
      Assert.AreSame(location, actualLocation);
      Assert.AreSame(repositoryMock.Object, actualRepository);

    }

    [Test]
    public void
    Constructor_WhenNameIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      string name = null;
      string location = "location";
      var repositoryMock = new Mock<IRepository<IPackage>>();

      // Act & Assert
      Assert.Throws<ArgumentNullException>(
        () => new Project(name, location, repositoryMock.Object));
    }

    [Test]
    public void
    Constructor_WhenLocationIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      string name = "name";
      string location = null;
      var repositoryMock = new Mock<IRepository<IPackage>>();

      // Act & Assert
      Assert.Throws<ArgumentNullException>(
        () => new Project(name, location, repositoryMock.Object));
    }

    [Test]
    public void
    Constructor_WhenPackageRepositoryIsNull_ShouldCreateNewPackageRepository()
    {
      // Arrange
      string name = "name";
      string location = "location";
      IRepository<IPackage> packages = null;

      // Act
      var project = new Project(name, location, packages);
      var actualPackageRepository = project.PackageRepository;

      // Assert
      Assert.IsInstanceOf<PackageRepository>(actualPackageRepository);

    }

    [Test]
    public void
    Constructor_WhenPackageRepositoryIsNotNull_ShouldAssignPassedValue()
    {
      // Arrange
      string name = "name";
      string location = "location";
      var packagesMock = new Mock<IRepository<IPackage>>();

      // Act
      var project = new Project(name, location, packagesMock.Object);
      var actualPackageRepository = project.PackageRepository;

      // Assert
      Assert.AreSame(packagesMock.Object, actualPackageRepository);
    }

    [Test]
    public void
    NameProperty_WhenIsValid_ShouldBeSetAppropriately()
    {
      // Arrange
      string name = "name";
      string location = "location";
      var repositoryMock = new Mock<IRepository<IPackage>>();

      // Act
      var project = new Project(name, location, repositoryMock.Object);
      var actualName = project.Name;

      // Assert
      Assert.AreEqual(name, actualName);
    }

    [Test]
    public void
    LocationProperty_WhenIsValid_ShouldBeSetAppropriately()
    {
      // Arrange
      string name = "name";
      string location = "location";
      var repositoryMock = new Mock<IRepository<IPackage>>();

      // Act
      var project = new Project(name, location, repositoryMock.Object);
      var actualLocation = project.Location;

      // Assert
      Assert.AreEqual(location, actualLocation);
    }

  }
}
