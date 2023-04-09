using System.Diagnostics;
using Newtonsoft.Json;

namespace ViewerBy2nd.Infrastructure
{
    public class ConfigurationReader
    {
        public static Settings? Default;
        
        static string fileName = "appsettings.json";
        public static void Initialize()
        {
            string jsonString= File.ReadAllText(fileName);
            try
            {
                
                    Default = JsonConvert.DeserializeObject<Settings>(jsonString);
                }
            catch (Exception )
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
