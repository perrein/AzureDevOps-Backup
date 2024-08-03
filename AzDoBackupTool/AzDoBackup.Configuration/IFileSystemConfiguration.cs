namespace AzDoBackup.Configuration
{
    public interface IFileSystemConfiguration
    {
        string BasePath { get; }
        int RemoveBackupAfterHowManyDays { get;  }
    }
}