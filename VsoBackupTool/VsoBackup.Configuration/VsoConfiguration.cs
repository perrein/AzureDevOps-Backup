using System.Configuration;

namespace VsoBackup.Configuration
{
    internal class VsoConfiguration : ConfigurationSection, IVsoConfiguration
    {

        [ConfigurationProperty("ApiPat", IsRequired = true)]
        public string ApiPat
        {
            get
            {
                return this["ApiPat"].ToString();
            }
        }

        [ConfigurationProperty("AllRepositoriesUrl", IsRequired = true)]
        public string AllRepositoriesUrl
        {
            get
            {
                return this["AllRepositoriesUrl"].ToString();
            }
        }
    }
}
