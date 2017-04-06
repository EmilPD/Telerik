using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Core.Mock
{
  internal class PackageInstallerMock : PackageInstaller
  {
    public PackageInstallerMock(IDownloader downloader, IProject project)
      : base(downloader, project)
    {
    }

    public IDownloader IDownloaderPublic
    {
      get
      {
        return this.Downloader;
      }
    }

    public IProject ProjectPublic
    {
      get
      {
        return this.Project;
      }
    }
  }
}
