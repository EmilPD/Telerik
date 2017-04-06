using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;

namespace PackageManager.Tests.Models
{
  [TestFixture]
  public class PackageTests
  {
    [Test]
    public void
    Constructor_ShouldSetsTheAppropriatePassedValues()
    {
      // Arrange
      string name = "name";
      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      // Act
      var package = new Package(name, version.Object, dependencies.Object);
      var actualName = package.Name;
      var actualVersion = package.Version;
      var actualDependencies = package.Dependencies;

      // Assert
      Assert.AreSame(name, actualName);
      Assert.AreSame(version.Object, actualVersion);
      Assert.AreSame(dependencies.Object, actualDependencies);
    }

    [Test]
    public void
    Constructor_WhenNameIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      string name = null;
      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      // Act & Assert
      Assert.Throws<ArgumentNullException>(
        () => new Package(name, version.Object, dependencies.Object));
    }

    [Test]
    public void
    Constructor_WhenVersionIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      string name = "name";
      IVersion version = null;
      var dependencies = new Mock<ICollection<IPackage>>();

      // Act & Assert
      Assert.Throws<ArgumentNullException>(
        () => new Package(name, version, dependencies.Object));
    }

    [Test]
    public void
    Constructor_WhenDependenciesIsNull_ShouldCreateNewPackageRepository()
    {
      // Arrange
      string name = "name";
      var version = new Mock<IVersion>();
      ICollection<IPackage> dependencies = null;

      // Act
      var package = new Package(name, version.Object, dependencies);
      var actualDependencies = package.Dependencies;

      // Assert
      Assert.IsInstanceOf<HashSet<IPackage>>(actualDependencies);

    }

    [Test]
    public void
    Constructor_WhenDependenciesIsNotNull_ShouldAssignPassedValue()
    {
      // Arrange
      string name = "name";
      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      // Act
      var package = new Package(name, version.Object, dependencies.Object);
      var actualDependencies = package.Dependencies;

      // Assert
      Assert.AreSame(dependencies.Object, actualDependencies);
    }

    [Test]
    public void
    NameProperty_WhenIsValid_ShouldBeSetAppropriately()
    {
      // Arrange
      string name = "name";
      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      // Act
      var package = new Package(name, version.Object, dependencies.Object);
      var actualName = package.Name;

      // Assert
      Assert.AreEqual(name, actualName);
    }

    [Test]
    public void
    VersionProperty_WhenIsValid_ShouldBeSetAppropriately()
    {
      // Arrange
      string name = "name";
      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      // Act
      var package = new Package(name, version.Object, dependencies.Object);
      var actualVersion = package.Version;

      // Assert
      Assert.AreEqual(version.Object, actualVersion);
    }

    [Test]
    public void
    UrlProperty_WhenIsValid_ShouldBeSetAppropriately()
    {
      // Arrange
      string name = "name";
      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();
      var expectedUrl = "0.0.0-alpha";

      // Act
      var package = new Package(name, version.Object, dependencies.Object);
      var actualUrl = package.Url;

      // Assert
      Assert.AreEqual(expectedUrl, actualUrl);
    }

    [Test]
    public void
    CompareTo_WhenOtherIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      string name = "name";
      var packageMock = new Mock<IPackage>();

      IPackage otherPackage = null;

      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      var package = new Package(name, version.Object, dependencies.Object);

      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => package.CompareTo(otherPackage));
    }

    [Test]
    public void
    CompareTo_WhenOtherIsNotNull_ShouldNotThrow()
    {
      // Arrange
      string name = "name";

      var packageMock = new Mock<IPackage>();

      var otherPackageMock = new Mock<IPackage>();
      otherPackageMock.Setup(x => x.Name).Returns("name");
      otherPackageMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 2, Enums.VersionType.alpha));

      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      var package = new Package(name, version.Object, dependencies.Object);

      // Act & Assert
      Assert.DoesNotThrow(() => package.CompareTo(otherPackageMock.Object));
    }

    [Test]
    public void
    CompareTo_WhenOtherHasDifferentName_ShouldThrowArgumentException()
    {
      // Arrange
      string name = "name";
      var packageMock = new Mock<IPackage>();

      var otherPackageMock = new Mock<IPackage>();
      otherPackageMock.Setup(x => x.Name).Returns("name1");
      otherPackageMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 2, Enums.VersionType.alpha));

      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      var package = new Package(name, version.Object, dependencies.Object);

      // Act & Assert
      Assert.Throws<ArgumentException>(() => package.CompareTo(otherPackageMock.Object));
    }

    [Test]
    public void
    CompareTo_WhenOtherHasHigherVersion_ShouldReturnMinus1()
    {
      // Arrange
      string name = "name";

      var dependencies = new Mock<ICollection<IPackage>>();

      var versionMock = new Mock<IVersion>();
      versionMock.Setup(x => x.Major).Returns(1);
      versionMock.Setup(x => x.Minor).Returns(1);
      versionMock.Setup(x => x.Patch).Returns(1);
      versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

      var otherPackageMock = new Mock<IPackage>();
      otherPackageMock.Setup(x => x.Name).Returns("name");
      otherPackageMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 2, Enums.VersionType.alpha));

      var package = new Package(name, versionMock.Object, dependencies.Object);

      // Act
      var comparisson = package.CompareTo(otherPackageMock.Object);

      // Assert
      Assert.AreEqual(-1, comparisson);
    }

    [Test]
    public void
    CompareTo_WhenOtherHasLowerVersion_ShouldReturn1()
    {
      // Arrange
      string name = "name";

      var dependencies = new Mock<ICollection<IPackage>>();

      var versionMock = new Mock<IVersion>();
      versionMock.Setup(x => x.Major).Returns(1);
      versionMock.Setup(x => x.Minor).Returns(1);
      versionMock.Setup(x => x.Patch).Returns(1);
      versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

      var otherPackageMock = new Mock<IPackage>();
      otherPackageMock.Setup(x => x.Name).Returns("name");
      otherPackageMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 0, Enums.VersionType.alpha));

      var package = new Package(name, versionMock.Object, dependencies.Object);

      // Act
      var comparisson = package.CompareTo(otherPackageMock.Object);

      // Assert
      Assert.AreEqual(1, comparisson);
    }

    [Test]
    public void
    CompareTo_WhenOtherHasTheSameVersion_ShouldReturn0()
    {
      // Arrange
      string name = "name";

      var dependencies = new Mock<ICollection<IPackage>>();

      var versionMock = new Mock<IVersion>();
      versionMock.Setup(x => x.Major).Returns(1);
      versionMock.Setup(x => x.Minor).Returns(1);
      versionMock.Setup(x => x.Patch).Returns(1);
      versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

      var otherPackageMock = new Mock<IPackage>();
      otherPackageMock.Setup(x => x.Name).Returns("name");
      otherPackageMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 1, Enums.VersionType.alpha));

      var package = new Package(name, versionMock.Object, dependencies.Object);

      // Act
      var comparisson = package.CompareTo(otherPackageMock.Object);

      // Assert
      Assert.AreEqual(0, comparisson);
    }

    [Test]
    public void
    Equals_WhenPassedObjectIsNull_ShouldThrowArgumentNullEcxeption()
    {
      // Arrange
      string name = "name";
      var packageMock = new Mock<IPackage>();

      Object otherPackage = null;

      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      var package = new Package(name, version.Object, dependencies.Object);

      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => package.Equals(otherPackage));
    }

    [Test]
    public void
    Equals_WhenPassedObjectIsNotIPackage_ShouldThrowArgumentEcxeptionWithMessageContaining_MustBeIPackage()
    {
      // Arrange
      string name = "name";
      var expectedMessage = "must be IPackage";
      var packageMock = new Mock<IPackage>();

      IVersion invalidObject = new PackageVersion(1, 1, 1, Enums.VersionType.alpha);

      var version = new Mock<IVersion>();
      var dependencies = new Mock<ICollection<IPackage>>();

      var package = new Package(name, version.Object, dependencies.Object);

      // Act & Assert
      var result = Assert.Throws<ArgumentException>(() => package.Equals(invalidObject));
      var actualExceptionMessage = result.Message;

      // Assert
      StringAssert.Contains(expectedMessage, actualExceptionMessage);
    }

    [Test]
    public void
    Equals_WhenPackagePassedIsEqualToThePackage_ShouldReturnTrue()
    {
      // Arrange
      string name = "name";

      var dependencies = new Mock<ICollection<IPackage>>();

      var versionMock = new Mock<IVersion>();
      versionMock.Setup(x => x.Major).Returns(1);
      versionMock.Setup(x => x.Minor).Returns(1);
      versionMock.Setup(x => x.Patch).Returns(1);
      versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

      var otherPackageMock = new Mock<IPackage>();
      otherPackageMock.Setup(x => x.Name).Returns("name");
      otherPackageMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 1, Enums.VersionType.alpha));

      var package = new Package(name, versionMock.Object, dependencies.Object);

      // Act & Assert
      Assert.IsTrue(package.Equals(otherPackageMock.Object));
    }

    [Test]
    public void
    Equals_WhenPackagePassedIsNotEqualToThePackage_ShouldReturnFalse()
    {
      // Arrange
      string name = "name";

      var dependencies = new Mock<ICollection<IPackage>>();

      var versionMock = new Mock<IVersion>();
      versionMock.Setup(x => x.Major).Returns(1);
      versionMock.Setup(x => x.Minor).Returns(1);
      versionMock.Setup(x => x.Patch).Returns(1);
      versionMock.Setup(x => x.VersionType).Returns(Enums.VersionType.alpha);

      var otherPackageMock = new Mock<IPackage>();
      otherPackageMock.Setup(x => x.Name).Returns("name1");
      otherPackageMock.Setup(x => x.Version).Returns(new PackageVersion(1, 1, 0, Enums.VersionType.alpha));

      var package = new Package(name, versionMock.Object, dependencies.Object);

      // Act & Assert
      Assert.IsFalse(package.Equals(otherPackageMock.Object));
    }

  }
}
