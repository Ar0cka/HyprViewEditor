using System.Collections.Generic;
using System.Text.Json;
using HyprViewEditor.Abstractions;

namespace HyprViewEditor.Scripts.Options.ConfigOptions;

public class HyprOption : BaseOptionSystem<HyprOptionData>
{
    public override void Initialize(JsonElement jsonElement)
    { 
        
    }

    public override void SetOption(object value)
    {
        throw new System.NotImplementedException();
    }
}

public class HyprOptionData(List<string> paths) : BaseOptionData(paths)
{
    
}