using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;

namespace PackageManager.Tests.Models
{
  [TestFixture]
  public class PackageVersionTests
  {
    [Test]
    public void
    Constructor_ShouldSetsTheAppropriatePassedValues()
    {
      // Arrange
      var major = 1;
      var minor = 2;
      var patch = 3;
      var versionType = VersionType.alpha;

      // Act
      var packageVersion = new PackageVersion(major, minor, patch, versionType);
      var actualMajor = packageVersion.Major;
      var actualMinor = packageVersion.Minor;
      var actualPatch = packageVersion.Patch;
      var actualVersionType = packageVersion.VersionType;

      // Assert
      Assert.IsNotNull(actualMajor);
      Assert.IsNotNull(actualMinor);
      Assert.IsNotNull(actualPatch);
      Assert.IsNotNull(actualVersionType);
    }

    [Test]
    public void
    MajorProperty_WhenIsValid_ShouldBeSetAppropriately()
    {
      // Arrange
      var major = 1;

      // Act
      var packageVersion = new PackageVersion(major, 1, 1, VersionType.alpha);
      var actualMajor = packageVersion.Major;

      // Assert
      Assert.AreEqual(major, actualMajor);
    }

    [Test]
    public void
    MajorProperty_WhenIsInvalid_ShouldThrowArgumentException()
    {
      // Arrange
      var major = -1;

      // Act & Assert
      Assert.Throws<ArgumentException>(() => new PackageVersion(major, 1, 1, VersionType.alpha));
    }

    [Test]
    public void
    MinorProperty_WhenIsValid_ShouldBeSetAppropriately()
    {
      // Arrange
      var minor = 1;

      // Act
      var packageVersion = new PackageVersion(1, minor, 1, VersionType.alpha);
      var actualMinor = packageVersion.Minor;

      // Assert
      Assert.AreEqual(minor, actualMinor);
    }

    [Test]
    public void
    MinorProperty_WhenIsInvalid_ShouldThrowArgumentException()
    {
      // Arrange
      var minor = -1;

      // Act & Assert
      Assert.Throws<ArgumentException>(() => new PackageVersion(1, minor, 1, VersionType.alpha));
    }

    [Test]
    public void
    VersionTypeProperty_WhenIsValid_ShouldBeSetAppropriately()
    {
      // Arrange
      var versionType = VersionType.beta;

      // Act
      var packageVersion = new PackageVersion(1, 1, 1, versionType);
      var actualVersionType = packageVersion.VersionType;

      // Assert
      Assert.AreEqual(versionType, actualVersionType);
    }

    [Test]
    public void
    VersionTypeProperty_WhenIsInvalid_ShouldThrowArgumentException()
    {

      // Arrange & Act & Assert
      Assert.Throws<ArgumentException>(() => new PackageVersion(1, 1, 1, (VersionType)(-1)));
    }

  }
}
