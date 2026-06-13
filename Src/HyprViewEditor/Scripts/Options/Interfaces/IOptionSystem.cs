using System.Text.Json;
using HyprViewEditor.Scripts.Options.Serialization;

namespace HyprViewEditor.Scripts.Options.Interfaces;

public interface IOptionSystem
{
    public void Initialize(JsonElement jsonElement);
    public void SetOption(object value);
    public SerializeItem GetJsonElement();
    public object GetData();
}