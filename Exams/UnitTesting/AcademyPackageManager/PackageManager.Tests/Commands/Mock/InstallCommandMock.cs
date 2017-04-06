using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.Mock
{
  internal class InstallCommandMock : InstallCommand
  {
    public InstallCommandMock(IInstaller<IPackage> installer, IPackage package)
      : base(installer, package)
    {
    }

    public IInstaller<IPackage> InstallerPublic
    {
      get
      {
        return this.Installer;
      }
    }

    public IPackage PackagePublic
    {
      get
      {
        return this.Package;
      }
    }
  }
}
