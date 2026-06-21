namespace HyprViewEditor.Scripts.Parsers.RofiParser;

public static class RofiValidation
{
    public static bool IsValidRofiTextLine(string text)
    {
        return !string.IsNullOrEmpty(text) && text.Length > 1 && IsNotEscapeSequence(text);
    }
    
    private static bool IsNotEscapeSequence(string text)
    {
        return text != "\n" && text != "\t" && text != "\n\t" && text != "\t\n";
    }
}