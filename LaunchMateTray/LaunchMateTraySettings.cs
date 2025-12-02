using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace LaunchMateTray
{
    public class ColorSettings: SortedList<String,String>
    {

    }

    public class KeySettings: SortedList<String,int>
    {

    }

    public class JsonAppItem
    {
        public String? Type { get; set; }
        public String? Name { get; set; }
        public String? Path { get; set; }
        public String? Arguments {  get; set; }
        public List<JsonAppItem>? Children { get; set; }
    }

    public class JsonSettings
    {
        public ColorSettings Appearance { get; set; } = new ColorSettings();
        public KeySettings Keys { get; set; } = new KeySettings();
        public List<JsonAppItem>? Apps { get; set; } = new List<JsonAppItem>();

    }


    public class LaunchMateTraySettings
    {
        const String COMPANY_PATH = "\\.evolke";
        const String APP_PATH = "\\launchmate_tray";
        const String SETTINGS_FILE = "\\settings.json";
        private String path = "";
        private String jsonSettings = "";
        public JsonSettings Settings = new JsonSettings();
        public static ColorSettings defaultColors = new ColorSettings
        {
            { "backclr", "FF000000" },
            { "selectclr", "FF2F4F4F" },
            { "textclr", "FFFFFFFF" },
            { "seltextclr", "FFFFFFFF" }
        };
        public static KeySettings defaultKeys = new KeySettings
        {
            { "ctrl", 0 }, { "shift", 1 }
        };

        public LaunchMateTraySettings()
        {
            InitSettings();
        }

        public void InitSettings()
        {
            Settings.Appearance = defaultColors;
            Settings.Keys = defaultKeys;

            path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            path += COMPANY_PATH;
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
            }

            path += APP_PATH;
            di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
            }

            path += SETTINGS_FILE;

            if (!File.Exists(path))
            {
                WriteSettings();
            }

        }

        public void ReadSettings()
        {
            String jsonString = File.ReadAllText(path);
            //Debug.WriteLine(jsonString);
            if (jsonString != null)
            {
                var data = JsonSerializer.Deserialize<JsonSettings>(jsonString);
                if (data != null) { Settings = data; }
            }
        }

        public void WriteSettings()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonSettings = JsonSerializer.Serialize<JsonSettings>(Settings, options);
            //Debug.WriteLine(jsonSettings);
            File.WriteAllText(path, jsonSettings);
        }
    }
}
