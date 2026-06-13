using System.Collections.Generic;
using System.Runtime.InteropServices;
using HyprViewEditor.Scripts.Options.Enums;
using Microsoft.VisualBasic.CompilerServices;

namespace HyprViewEditor.Abstractions;

public class BaseOptionData(List<string> paths)
{
    public List<string> ConfigsPaths { get; private set; } = paths;
}