using System.Text.Json;
using HyprViewEditor.Scripts.Options.Interfaces;
using HyprViewEditor.Scripts.Options.Serialization;

namespace HyprViewEditor.Abstractions;

public abstract class BaseOptionSystem<TOptionData> : IOptionSystem where TOptionData : BaseOptionData
{
    protected TOptionData OptionData;

    public abstract void Initialize(JsonElement jsonElement);
    public abstract void SetOption(object value);
    
    public virtual SerializeItem GetJsonElement()
    {
        return new SerializeItem($"{GetType()}", JsonSerializer.SerializeToElement(OptionData));
    }
    
    public virtual object GetData()
    {
        return OptionData;
    }
}