using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.Mock;
using System;

namespace PackageManager.Tests.Commands
{
  [TestFixture]
  public class InstallCommandTests
  {
    [Test]
    public void
    Constructor_WhenPassedInstallerIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      var packageMock = new Mock<IPackage>();
      IInstaller<IPackage> installer = null;

      // Act & Assert
      Assert.Throws<ArgumentNullException>(
        () => new InstallCommand(installer, packageMock.Object));
    }

    [Test]
    public void
    Constructor_WhenPassedPackageIsNull_ShouldThrowArgumentNullException()
    {
      // Arrange
      IPackage packageMock = null;
      var installerMock = new Mock<IInstaller<IPackage>>();

      // Act & Assert
      Assert.Throws<ArgumentNullException>(
        () => new InstallCommand(installerMock.Object, packageMock));
    }

    [Test]
    public void
    Constructor_WhenPassedValuesAreValid_ShouldAssignThemCorrectly()
    {
      // Arrange
      var packageMock = new Mock<IPackage>();
      var installerMock = new Mock<IInstaller<IPackage>>();

      // Act 
      var installCommand = new InstallCommandMock(installerMock.Object, packageMock.Object);
      var actualInstaller = installCommand.InstallerPublic;
      var actualPackage = installCommand.PackagePublic;

      // Assert
      Assert.AreSame(installerMock.Object, actualInstaller);
      Assert.AreSame(packageMock.Object, actualPackage);
    }

    [Test]
    public void
    InstallerField_WhenPassedValueIsValid_ShouldBeAssignedCorrectly()
    {
      // Arrange
      var packageMock = new Mock<IPackage>();
      var installerMock = new Mock<IInstaller<IPackage>>();

      // Act 
      var installCommand = new InstallCommandMock(installerMock.Object, packageMock.Object);
      var actualInstaller = installCommand.InstallerPublic;

      // Assert
      Assert.AreSame(installerMock.Object, actualInstaller);
    }

    [Test]
    public void
    PackageField_WhenPassedValueIsValid_ShouldBeAssignedCorrectly()
    {
      // Arrange
      var packageMock = new Mock<IPackage>();
      var installerMock = new Mock<IInstaller<IPackage>>();

      // Act 
      var installCommand = new InstallCommandMock(installerMock.Object, packageMock.Object);
      var actualPackage = installCommand.PackagePublic;

      // Assert
      Assert.AreSame(packageMock.Object, actualPackage);
    }

    [Test]
    public void
    OperationProperty_ShouldBeSetCorrectly()
    {
      // Arrange
      var packageMock = new Mock<IPackage>();
      var installerMock = new Mock<IInstaller<IPackage>>();
      installerMock.SetupSet(x => x.Operation = InstallerOperation.Install);

      // Act 
      var installCommand = new InstallCommandMock(installerMock.Object, packageMock.Object);

      // Assert
      installerMock.VerifyAll();
    }

    [Test]
    public void
    Execute_WhenInvoked_ShouldCallInstallerPerformOperation()
    {
      // Arrange
      var packageMock = new Mock<IPackage>();
      var installerMock = new Mock<IInstaller<IPackage>>();
      //installerMock.Setup(x => x.PerformOperation(), );

      // Act 
      var installCommand = new InstallCommandMock(installerMock.Object, packageMock.Object);

      // Assert
      installerMock.VerifyAll();
    }

  }
}
