using System;
using System.Collections.Generic;
using System.Linq;
using HyprViewEditor.ConfigTemplates.Rofi;

namespace HyprViewEditor.Scripts.Parsers.RofiParser;

public class BuildPropertyService
{
    public RofiProperty? Build(string key, string value, RofiPropertyTypes type)
    {
        switch (type)
        {
            case RofiPropertyTypes.Value:
                return BuildValue(value, key);
            case RofiPropertyTypes.ListValue:
                return BuildListValue(value, key);
            case RofiPropertyTypes.Reference:
                return BuildReference(value, key);
            default:
                Console.WriteLine($"Unknown type {type} for key {key}");
                return null;
        }
    }
    
    private RofiProperty BuildValue(string value, string key)
    {
        var property = new RofiProperty(key, RofiPropertyTypes.Value);
        
        property.PropertyValues.Add(value);

        return property;
    }

    private RofiProperty BuildListValue(string value, string key)
    {
        var items = value
            .Trim('[', ']')
            .Split(',')
            .Select(x => x.Trim().Trim('"'))
            .ToList();

        var property = new RofiProperty(key, RofiPropertyTypes.ListValue);
        property.PropertyValues.AddRange(items);
        return property;
    }

    private RofiProperty BuildReference(string value, string key)
    {
        var property = new RofiProperty(key, RofiPropertyTypes.Reference);
        property.PropertyValues.Add(value.TrimStart('@'));
        return property;
    }

    public RofiExpression BuildExpression(string value, string key)
    {
        var openIndex = value.IndexOf('(');

        var name = value[..openIndex];

        var arguments = value[(openIndex + 1)..value.LastIndexOf(')')]
            .Split(',')
            .Select(x => x.Trim())
            .ToList();

        var property = new RofiExpression(name);
        property.Properties.AddRange(arguments);

        return property;
    }
}