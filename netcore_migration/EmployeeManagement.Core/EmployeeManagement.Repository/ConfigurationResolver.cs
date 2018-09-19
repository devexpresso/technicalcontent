using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Repository
{
    public static class ConfigurationResolver
    {

        public static IConfiguration Configuration()
        {
            string basePath = AppContext.BaseDirectory;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("AppSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();
            return configuration;
        }
    }
}
