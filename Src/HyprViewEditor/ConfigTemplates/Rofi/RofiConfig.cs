using System.Collections.Generic;

namespace HyprViewEditor.ConfigTemplates.Rofi;

public record RofiValue(string value);
public record RofiList(List<string> values);
public record RofiExpression(string name, List<string> values);
public record RofiReference(string reference);

public record RofiConfig(List<string> imports, Dictionary<string, RofiBlock> Blocks);

public record RofiBlock(string Name, RofiBody RofiBody);

public class RofiBody
{
    public Dictionary<string, RofiValue> Values { get; set; } = new();
    public Dictionary<string, RofiExpression> Expressions { get; set; } = new();
    public Dictionary<string, List<RofiList>> ListsProperties { get; set; } = new();
    public Dictionary<string, RofiReference> ReferencesProperties { get; set; } = new();
}