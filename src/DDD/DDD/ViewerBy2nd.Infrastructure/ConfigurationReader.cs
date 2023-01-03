using System.Diagnostics;
using System.Text.Json;

namespace ViewerBy2nd.Infrastructure
{
    public class ConfigurationReader
    {
        public static Settings? Default;
        
        static string fileName = "appsettings.json";
        public static void Initialize()
        {
            string jsonString = String.Empty;
            try
            {
                jsonString = File.ReadAllText(fileName);
            }
            catch(System.IO.FileNotFoundException  ex)
            {
                //初回起動時は、appsettings.jsonが存在しないので、例外が発生する。
            }

            var x = JsonSerializer.Deserialize<Settings>(jsonString);
            Default = x;
        }
        
        public static void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(Default, options);
            File.WriteAllText(fileName, jsonString);

        }
    }
}
