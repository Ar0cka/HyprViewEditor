using HyprViewEditor.Scripts.Parsers.Enums;

namespace HyprViewEditor.Scripts.Parsers.Interfeces;

public interface IParserState
{
    ParserState State { get; }
    
    public void Enter(string input);
    public void Exit();
}