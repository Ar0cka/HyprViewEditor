using System.Collections.Generic;
using HyprViewEditor.ConfigTemplates.Rofi;
using HyprViewEditor.Scripts.Parsers.Enums;
using HyprViewEditor.Scripts.Parsers.Interfeces;
using HyprViewEditor.Scripts.Parsers.States;

namespace HyprViewEditor.Scripts.Parsers.RofiParser;

public class RofiReadPipeline
{
    private readonly Dictionary<ParserState, IParserState?> _stateMap = new()
    {
        { ParserState.None, null },
        { ParserState.ReadingList, null },
        { ParserState.ReadingExpression, null },
        { ParserState.ReadingProperty, null}
    };

    private IParserState? _currentState = null;
    private ParserState? _currentStateType = ParserState.None;

    public void Initialize()
    {
        _currentState = _stateMap[ParserState.None];
    }
    
    public RofiBody Reading(string input)
    {
        if (_currentState != null && _currentState.State != ParserState.None)
            _currentState.Exit();

        var splitText = input.Split(';');

        foreach (var text in splitText)
        {
            //TODO: Pipeline: ReadKey -> ReadValue -> CheckFormat -> ChooseMethodForParsingValue -> (ReadExpression | ReadProperty | ReadList)
        }
    }
}