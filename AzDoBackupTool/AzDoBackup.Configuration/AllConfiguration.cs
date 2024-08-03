using System.Configuration;

namespace AzDoBackup.Configuration
{
    public class AllConfiguration : IAllConfiguration
    {
        public IFileSystemConfiguration FileSystemConfiguration
        {
            get
            {
                return (FileSystemConfiguration)ConfigurationManager.GetSection("FileSystemConfiguration");
            }
        }

        public IVsoConfiguration VsoConfiguration
        {
            get
            {
                return (VsoConfiguration)ConfigurationManager.GetSection("VsoConfiguration");
            }
        }
    }
}
