namespace VsoBackup.Configuration
{
    public interface IVsoConfiguration
    {
        string ApiPat { get; }
        string AllRepositoriesUrl { get; }
    }
}