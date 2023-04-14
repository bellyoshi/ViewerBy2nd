using System.Diagnostics;
using Newtonsoft.Json;

namespace ViewerBy2nd.Infrastructure
{
    public class ConfigurationReader
    {
        public static Settings Default;
        
        static string fileName = "appsettings.json";
        public static void Initialize()
        {

            try
            {
                string jsonString = File.ReadAllText(fileName);
                Default = JsonConvert.DeserializeObject<Settings>(jsonString)??new();
            } catch (Exception )
            {
                Default = new();
            }
       

        }
        
        public static void Save()
        {

            string jsonString = JsonConvert.SerializeObject(Default);
            File.WriteAllText(fileName, jsonString);

        }
    }
}
