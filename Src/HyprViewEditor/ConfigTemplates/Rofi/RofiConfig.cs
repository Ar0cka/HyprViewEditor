using System.Collections.Generic;

namespace HyprViewEditor.ConfigTemplates.Rofi;

public record RofiConfig(List<string> imports, Dictionary<string, string> properties);

public record RofiBlock(string Name, Dictionary<string, string> properties);