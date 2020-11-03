using Car1.Domain;
using System.Configuration;

namespace Car1
{
    public class Settings : ISettings
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["Car1Db"].ConnectionString;

    }

}
