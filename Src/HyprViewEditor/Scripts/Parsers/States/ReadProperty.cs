using HyprViewEditor.Scripts.Parsers.Enums;
using HyprViewEditor.Scripts.Parsers.Interfeces;
using HyprViewEditor.Scripts.Parsers.RofiParser;

namespace HyprViewEditor.Scripts.Parsers.States;

public class ReadProperty(RofiReadPipeline rofiReadPipeline) : IParserState
{
    public ParserState State { get; }

    private RofiReadPipeline _rofiReadPipeline = rofiReadPipeline;

    public void Enter(string input)
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}