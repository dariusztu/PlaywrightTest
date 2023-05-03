using System.IO;
using Newtonsoft.Json.Linq;

public class GlobalTestConfiguration
{
    private readonly JObject _config;

    public GlobalTestConfiguration(string configFilePath)
    {
        var configJson = File.ReadAllText(configFilePath);
        _config = JObject.Parse(configJson);
    }

    public bool Headless => _config["BrowserSettings"]["Headless"].Value<bool>();

    // Add other configuration properties as needed
}


