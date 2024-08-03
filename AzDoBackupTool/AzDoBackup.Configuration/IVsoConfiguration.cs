namespace AzDoBackup.Configuration
{
    public interface IVsoConfiguration
    {
        string ApiPat { get; }
        string AllRepositoriesUrl { get; }
    }
}