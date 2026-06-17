using System;
using System.Collections.Generic;
using System.IO;
using HyprViewEditor.Scripts.Options.ConfigOptions;
using HyprViewEditor.Scripts.Options.Enums;
using HyprViewEditor.Scripts.Options.Interfaces;
using HyprViewEditor.Scripts.Options.Serialization;

namespace HyprViewEditor.Scripts.Options;

public class OptionsController : IOptionsController
{
    private readonly Dictionary<OptionSystemType, IOptionSystem> _configOptions = new() //TODO: Change to config option systems
    {
        { OptionSystemType.Hypr, new HyprOption()},
        { OptionSystemType.Rofi, null},
        { OptionSystemType.Waybar, null }
    };
    private readonly Dictionary<OptionType, IOptionSystem> _systemOptions = new() //TODO: Change to system option systems
    {
        { OptionType.Path, null }
    };
    
    private readonly string _options = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Jsons/options.json");
    
    public void SetOption(OptionType option, object value)
    {
        // if (!_configOptions.TryGetValue(option, out var system))
        // {
        //     Console.Error.WriteLine($"Failed to find option system for {option}");
        //     return;
        // }
        //
        // system.SetOption(value);
    }

    public void DeserializeOptions()
    {
        
    }

    private void SerializeOptions()
    {
        // List<SerializeItem> items = new();
        //
        // foreach (var item in _configOptions)
        // {
        //     items.Add(new SerializeItem()
        // }
    }
}