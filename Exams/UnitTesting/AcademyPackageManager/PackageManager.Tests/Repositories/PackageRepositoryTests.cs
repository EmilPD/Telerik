using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;

namespace PackageManager.Tests.Repositories
{
  [TestFixture]
  public class PackageRepositoryTests
  {
    [Test]
    public void
    Add_WhenPassedPackageIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      var loggerMock = new Mock<ILogger>();
      var packageOneMock = new Mock<IPackage>();

      var packagesMock = new Mock<ICollection<IPackage>>();

      var packageRepository = new PackageRepository(loggerMock.Object, packagesMock.Object);


      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => packageRepository.Add(null));
    }

    [Test]
    public void
    Add_WhenPassedValidPackage_ShouldNotThrow()
    {
      // Arrange
      var loggerMock = new Mock<ILogger>();
      var packageOneMock = new Mock<IPackage>();
      packageOneMock.Setup(x => x.Name).Returns("name");

      var packagesMock = new Mock<ICollection<IPackage>>();
      packagesMock.Setup(x => x.Add(packageOneMock.Object));
      //packagesMock.Object.Add(packageOneMock.Object);

      var packageTwoMock = new Mock<IPackage>();
      packageTwoMock.Setup(x => x.Name).Returns("name");

      var packageRepository = new PackageRepository(loggerMock.Object, packagesMock.Object);

      // Act
      packageRepository.Add(packageTwoMock.Object);

      // Assert
      Assert.That(packagesMock.Object.Count, Is.EqualTo(2));
    }

    [Test]
    public void
    Add_WhenPassedPackageAlreadyExist_ShouldNotThrow()
    {
      // Arrange
      var loggerMock = new Mock<ILogger>();
      var packageOneMock = new Mock<IPackage>();
      packageOneMock.Setup(x => x.Name).Returns("name");
      packageOneMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 1, Enums.VersionType.alpha));

      var packagesMock = new Mock<ICollection<IPackage>>();
      packagesMock.Object.Add(packageOneMock.Object);

      var packageTwoMock = new Mock<IPackage>();
      packageTwoMock.Setup(x => x.Name).Returns("name1");
      packageOneMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 1, Enums.VersionType.alpha));

      var packageRepository = new PackageRepository(loggerMock.Object, packagesMock.Object);

      // Act
      packageRepository.Add(packageTwoMock.Object);

      // Assert
      packagesMock.Verify(x => x.Count == 2);
    }


    [Test]
    public void
    Delete_WhenPassedPackageIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      var loggerMock = new Mock<ILogger>();
      var packageOneMock = new Mock<IPackage>();

      var packagesMock = new Mock<ICollection<IPackage>>();

      var packageRepository = new PackageRepository(loggerMock.Object, packagesMock.Object);


      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => packageRepository.Delete(null));
    }

    [Test]
    public void
    Update_WhenPassedPackageIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      var loggerMock = new Mock<ILogger>();
      var packageOneMock = new Mock<IPackage>();

      var packagesMock = new Mock<ICollection<IPackage>>();

      var packageRepository = new PackageRepository(loggerMock.Object, packagesMock.Object);


      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => packageRepository.Update(null));
    }

    [Test]
    public void
    GetAll_WhenNoPassedCollection_ShouldReturnEmptyCollection()
    {
      // Arrange
      var loggerMock = new Mock<ILogger>();
      var packageOneMock = new Mock<IPackage>();

      var packagesMock = new Mock<ICollection<IPackage>>();

      var packageRepository = new PackageRepository(loggerMock.Object, null);

      // Act 
      var collection = packageRepository.GetAll();

      // Assert
      Assert.IsTrue(collection != null);
    }



  }
}
