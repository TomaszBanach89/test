using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace UBS.Commons
{
    public class JsonConfigLoader
    {
        public void Load(string configFilePath = "appsettings.json")
        {
            ConfigMasterObject cmo = JsonConvert.DeserializeObject<ConfigMasterObject>(File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\appsettings.json"));
            GlobalValues.SetConfigMasterObject(cmo);
        }
    }
}
