using HyprViewEditor.Scripts.Options.Enums;

namespace HyprViewEditor.Scripts.Options.Interfaces;

public interface IOptionsController
{
    public void SetOption(OptionType option, object value);
    
    public void DeserializeOptions();
}