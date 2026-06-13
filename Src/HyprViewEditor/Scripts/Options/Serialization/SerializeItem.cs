using System;
using System.Text.Json;

namespace HyprViewEditor.Scripts.Options.Serialization;

public record SerializeItem(string Type, JsonElement value);