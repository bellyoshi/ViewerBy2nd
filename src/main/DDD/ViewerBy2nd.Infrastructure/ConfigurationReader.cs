using Newtonsoft.Json;
using System.Diagnostics;

namespace ViewerBy2nd.Infrastructure
{
    public class ConfigurationReader
    {
        const string fileName = "appsettings.json";
        public static Settings Default { get; } = GetDefault();


        private static Settings GetDefault()
        {
            Settings settings;
            try
            {
                Debug.Assert(fileName != null);
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
