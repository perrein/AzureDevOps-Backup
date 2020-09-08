using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using VsoBackup.Configuration;

namespace VsoBackup.VisualStudioOnline
{
    public class VsoRestApiService : IVsoRestApiService
    {
        private readonly IAllConfiguration _configuration;

        public VsoRestApiService(IAllConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<T> ExecuteRequest<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", _configuration.VsoConfiguration.ApiPat))));

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var retVal = JsonConvert.DeserializeObject<T>(responseBody);
                    return retVal;
                }
            }
        }

        private static async Task<String> GetAsync(HttpClient client, String apiUrl)
        {
            string responseBody;

            using (var response = await client.GetAsync(apiUrl))
            {
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }

            return responseBody;
        }
    }
}
