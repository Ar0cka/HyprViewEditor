using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HyprViewEditor.DISystem;
using HyprViewEditor.DISystem.DiSystem;
using HyprViewEditor.Scripts.Enums;
using HyprViewEditor.Scripts.Options;
using HyprViewEditor.Scripts.Options.Enums;
using HyprViewEditor.Scripts.Options.Interfaces;

namespace HyprViewEditor.Scripts;

public class PathManager
{
    [Inject] private IOptionsController _optionsController = null!;
    
    private readonly Dictionary<ComponentsType, string> _pathMap = new();

    public IReadOnlyDictionary<ComponentsType, string> Paths => _pathMap.AsReadOnly();

    private string _baseJsonPathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Jsons/paths.json");

    public PathManager()
    {
        Di.ResolveInstance.ResolveInstanceFromClass(this);
        
        if (_optionsController == null)
            throw new ArgumentNullException(nameof(_optionsController));
    }
    
    public virtual void ChangePath(ComponentsType component, string newPath)
    {
        _pathMap[component] = newPath;
    }

    public virtual void SaveSettings()
    {
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(_pathMap, jsonOptions);
        
        File.WriteAllText(_baseJsonPathFile, jsonString);
    }

    public void ChangeBaseJsonPath(string newPath)
    {
        _baseJsonPathFile = newPath;
        
        _optionsController.SetOption(OptionType.Path, _baseJsonPathFile);
    }
}