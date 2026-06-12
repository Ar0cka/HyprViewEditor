namespace HyprViewEditor.Scripts.Options;

public interface IOptionsController
{
    public void SetOption(OptionType option, object value);
}