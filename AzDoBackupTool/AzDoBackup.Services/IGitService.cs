using AzDoBackup.Models;

namespace AzDoBackup.Services
{
    public interface IGitService
    {
        void Clone(Value value, string path);
    }
}
