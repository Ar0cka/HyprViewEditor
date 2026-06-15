using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HyprViewEditor.ConfigTemplates.Rofi;

namespace HyprViewEditor.Scripts.Parsers.RofiParser;

public class RofiParser
{
    private static RofiReadPipeline? _rofiReader;
    
    public static RofiConfig Parser(string input)
    {
        if (_rofiReader == null)
        {
            _rofiReader = new RofiReadPipeline();
            _rofiReader.Initialize();
        }
        
        var import = ParseImport(input);

        Dictionary<string, RofiBlock> blocks = new();
        var bodyRegex = new Regex(@"([a-zA-Z\*\-_]+)\s*\{(.*?)\}");

        foreach (Match item in bodyRegex.Matches(input))
        {
            var rofiBlock = ReadBody(item);
            
            blocks[item.Groups[1].Value] = rofiBlock;
        }

        return new RofiConfig(import, blocks);
    }

    private static RofiBlock ReadBody(Match item)
    {
        var outputData = _rofiReader?.Reading(item.Groups[2].Value);

        if (outputData == null)
        {
            Console.Error.WriteLine("Error reading body");
            return null!;
        }
        
        var rofiBlock = new RofiBlock(item.Groups[1].Value, outputData);

        return rofiBlock;
    }

    private static List<string> ParseImport(string input)
    {
        var data = new List<string>();
        var importRegex = new Regex(@"@import\s+""([^""]+)""");

        foreach (Match item in importRegex.Matches(input))
        {
            data.Add(item.Groups[1].Value);
        }

        return data;
    }
}