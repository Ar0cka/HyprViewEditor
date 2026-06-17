using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
        
        var import = ParseImport(input);

        Dictionary<string, RofiBlock> blocks = new();
        var bodyRegex = new Regex(@"([a-zA-Z\*\-_]+)\s*\{");

        foreach (Match item in bodyRegex.Matches(input))
        {
            var rofiBlock = ReadBody(item, input);
            
            if (rofiBlock is null)
                continue;
            
            blocks[item.Groups[1].Value] = rofiBlock;
        }

        return new RofiConfig(import, blocks);
    }

    private static RofiBlock? ReadBody(Match item, string input)
    {
        if (string.IsNullOrEmpty(item.Groups[1].Value))
        {
            Console.Error.WriteLine("Error reading header");
            return null!;
        }

        var start = item.Index + item.Length; // start of the body
        int end = 0;
        int depth = 1;

        StringBuilder value = new();

        for (int i = start; i < input.Length; i++)
        {
            if (input[i] == '{') depth++;
            if (input[i] == '}') depth--;

            if (input[i] != '}' && input[i] != '{')
                value.Append(input[i]);

            if (depth == 0)
            {
                end = i;
                break;
            }
        }

        var rofiBlock = _rofiReader?.Reading(value.ToString(), item.Groups[1].Value);

        if (rofiBlock == null)
        {
            Console.Error.WriteLine("Error reading body");
            return null!;
        }

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