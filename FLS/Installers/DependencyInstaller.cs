using BLL.BusinessLogics;
using BLL.Interfaces;
using FLS.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FLS.Installers
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IGuestBL, GuessBL>();
            services.AddScoped<IUserBL, UserBL>();
        }
    }
}