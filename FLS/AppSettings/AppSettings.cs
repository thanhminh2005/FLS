using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.AppSettings
{
    public class AppSetting
    {
        public Jwt Jwt { get; set; }
        public SwaggerOptions SwaggerOptions { get; set; }
    }
}
