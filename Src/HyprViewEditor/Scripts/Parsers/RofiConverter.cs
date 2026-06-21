using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using HyprViewEditor.ConfigTemplates.Rofi;

namespace HyprViewEditor.Scripts.Parsers;

public static class RofiConverter
{
    public static bool RofiConfigToJson(RofiConfig rofiConfig)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(rofiConfig, jsonOptions);

        var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Jsons/Rofi");
        
        File.WriteAllText($"{folderPath}/rofi_config.json", json);
        
        // Implement the conversion logic here
        return true;
    }
}