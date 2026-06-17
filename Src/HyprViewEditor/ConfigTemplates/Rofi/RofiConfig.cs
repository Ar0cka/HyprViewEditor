using System.Collections.Generic;

namespace HyprViewEditor.ConfigTemplates.Rofi;

public record RofiConfig(List<string> imports, Dictionary<string, RofiBlock> blocks);

public class RofiBlock(string blockName)
{
    public string BlockName { get; private set; } = blockName;
    public List<RofiProperty> Properties { get; private set; } = new();
    public List<RofiExpression> Expressions { get; private set; } = new();
}

public class RofiProperty(string propertyName, RofiPropertyTypes type)
{
    public string PropertyName { get; set; } = propertyName;
    public RofiPropertyTypes PropertyType { get; set; } = type;
    public List<string> PropertyValues { get; set; } = new List<string>(); 
}

public class RofiExpression(string name)
{
    public string Name { get; private set; } = name;
    public List<string> Properties { get; private set; } = new();
}