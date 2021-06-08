using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FLS.Installers
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}