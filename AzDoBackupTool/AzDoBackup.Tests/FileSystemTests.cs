using AzDoBackup.DependencyInjection;
using AzDoBackup.Models;
using AzDoBackup.Services;
using Castle.Windsor;
using NUnit.Framework;

namespace AzDoBackup.Tests
{
    [TestFixture]
    public class FileSystemTests
    {
        private const string FolderTestName = "test";

        private IWindsorContainer container;

        [SetUp]
        public void Setup()
        {
            container = new Bootstrapper().BootstrapContainer();
        }

        [Test]
        public void CreateDirectoryTest()
        {
            var fileSystemService = container.Resolve<IFileSystemService>();
            fileSystemService.CreateDirectory(Constants.Today);

           // Assert.IsTrue(_fileSystemService.FolderExists(FolderTestName));
        }
    }
}
