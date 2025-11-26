using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace LaunchMateTray
{
    public class JsonAppItem
    {
        public String? Type { get; set; }
        public String? Name { get; set; }
        public String? Path { get; set; }
        public List<JsonAppItem>? Children { get; set; }
    }

    public class JsonSettings
    {
        public List<JsonAppItem>? Apps { get; set; }
    }


    public class LaunchMateTraySettings
    {
        const String COMPANY_PATH = "\\.evolke";
        const String APP_PATH = "\\launchmate_tray";
        const String SETTINGS_FILE = "\\settings.json";
        private String path = "";
        private String jsonSettings = "";
        public JsonSettings Settings = new JsonSettings();

        public LaunchMateTraySettings()
        {
            this.initSettings();
        }

        public void initSettings()
        {
            this.path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            this.path += COMPANY_PATH;
            DirectoryInfo di = new DirectoryInfo(this.path);
            if (!di.Exists)
            {
                di.Create();
            }

            this.path += APP_PATH;
            di = new DirectoryInfo(this.path);
            if (!di.Exists)
            {
                di.Create();
            }

            this.path += SETTINGS_FILE;

            if (!File.Exists(this.path))
            {
                File.Create(this.path);
            }
        }

        public void ReadSettings()
        {
            String jsonString = File.ReadAllText(this.path);
            Debug.WriteLine(jsonString);
            if (jsonString != null)
            {
                var data = JsonSerializer.Deserialize<JsonSettings>(jsonString);
                if (data != null) { this.Settings = data; }
            }
        }

        public void WriteSettings()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            this.jsonSettings = JsonSerializer.Serialize<JsonSettings>(this.Settings, options);
            Debug.WriteLine(this.jsonSettings);
            File.WriteAllText(this.path, this.jsonSettings);
        }
    }
}
