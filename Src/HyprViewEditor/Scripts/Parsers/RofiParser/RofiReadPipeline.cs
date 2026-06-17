using System;
using System.Collections.Generic;
using HyprViewEditor.ConfigTemplates.Rofi;

namespace HyprViewEditor.Scripts.Parsers.RofiParser;

public class RofiReadPipeline
{
    private BuildPropertyService _buildPropertyService = new();
    
    public RofiBlock Reading(string input, string blockName)
    {
        var splitText = input.Split(';');
        
        var rofiBlock = new RofiBlock(blockName);
        
        foreach (var text in splitText)
        {
            var key = ReadKey(text);
            var value = ReadValue(text);
            
            var type = CheckFormat(value);

            if (type == RofiPropertyTypes.Expression)
            {
                var expression = _buildPropertyService.BuildExpression(value, key);
                rofiBlock.Expressions.Add(expression);
                continue;
            }

            var property = _buildPropertyService.Build(key, value, type);

            if (property == null)
            {
                Console.Error.WriteLine($"Failed to build property: {key}");
                continue;
            }
            
            rofiBlock.Properties.Add(property);
        }

        return rofiBlock;
    }

    private string ReadKey(string text)
    {
        var data = text.Split(':');
        return data[0];
    }
    private string ReadValue(string text)
    {
        var data = text.Split(':');
        var value = data[1].Trim();
        return value;
    }
    private RofiPropertyTypes CheckFormat(string value)
    {
        var trimValue = value.Trim();
        var startChar = trimValue[0];

        if (startChar == '[')
            return RofiPropertyTypes.ListValue;
        if (startChar == '@')
            return RofiPropertyTypes.Reference;

        if (trimValue.Contains('(') && trimValue.Contains(')'))
            return RofiPropertyTypes.Expression;
        
        return RofiPropertyTypes.Value;
    }
}