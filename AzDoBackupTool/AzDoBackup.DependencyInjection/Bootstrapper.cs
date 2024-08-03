using Castle.Windsor;

namespace AzDoBackup.DependencyInjection
{
    public class Bootstrapper
    {
        public IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer().Install(new VsoBackupInstaller());
        }
    }
}
