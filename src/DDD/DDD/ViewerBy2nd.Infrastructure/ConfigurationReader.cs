using System.Diagnostics;
using Newtonsoft.Json;

namespace ViewerBy2nd.Infrastructure
{
    public class ConfigurationReader
    {
        public static Settings Default { get; } = GetDefault();
        
        static string fileName = "appsettings.json";
        private static Settings GetDefault()
        {
            Settings settings;
            try
            {
                string jsonString = File.ReadAllText(fileName);
                settings = JsonConvert.DeserializeObject<Settings>(jsonString)??new();
            } catch (Exception )
            {
                settings = new();
            }
            return settings;

        }
        
        public static void Save()
        {

            string jsonString = JsonConvert.SerializeObject(Default);
            File.WriteAllText(fileName, jsonString);

        }
    }
}
