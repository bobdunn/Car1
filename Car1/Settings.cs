using Car1.Domain;
using Microsoft.Extensions.Configuration;
using System;

namespace Car1
{
    public class Settings : ISettings
    {
        public string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString("Car1Db");
        }
    }

}
