using System.Web;
using AzDoBackup.Configuration;
using AzDoBackup.Logging;
using AzDoBackup.Models;
using LibGit2Sharp;

namespace AzDoBackup.Services
{
    public class GitService : IGitService
    {
        private readonly IAllConfiguration _allConfiguration;
        private readonly ILogger _logger;
        private Credentials _credentials;

        public GitService(IAllConfiguration allConfiguration, ILogger logger)
        {
            _allConfiguration = allConfiguration;
            _logger = logger;
        }

        private Credentials CredentialsProvider(string url, string usernameFromUrl, SupportedCredentialTypes types)
        {
            _credentials = new UsernamePasswordCredentials
            {
                Username = _allConfiguration.VsoConfiguration.ApiPat, // YOUR TOKEN HERE
                Password = string.Empty
            };
            return _credentials;
        }

        public void Clone(Value value, string path)
        {
            _logger.WriteLog("Cloning repository '{0}'", value.name);
            Repository.Clone(HttpUtility.UrlPathEncode(value.remoteUrl), path, new CloneOptions
            {
                FetchOptions = {
                    CredentialsProvider =CredentialsProvider
                }
            });
        }
    }
}
