using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Text;
using FLS.AppSettings;
using Microsoft.IdentityModel.Tokens;

namespace FLS.Installers
{
    public class JwtBearerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection appSettingsSection = configuration.GetSection("Jwt");
            services.Configure<AppSetting>(appSettingsSection);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var appSettings = appSettingsSection.Get<AppSetting>();
                var key = Encoding.ASCII.GetBytes(appSettings.Jwt.SecretKey);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }
    }
}
