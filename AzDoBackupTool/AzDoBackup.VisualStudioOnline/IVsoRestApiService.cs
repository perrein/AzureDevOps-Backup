using System.Threading.Tasks;

namespace AzDoBackup.VisualStudioOnline
{
    public interface IVsoRestApiService
    {
        Task<T> ExecuteRequest<T>(string url);
    }
}
