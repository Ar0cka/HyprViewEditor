using Avalonia;
using System;
using System.IO;
using HyprViewEditor.Scripts.Parsers;
using HyprViewEditor.Scripts.Parsers.RofiParser;

namespace HyprViewEditor;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var file = File.ReadAllText("/home/arocka/.config/rofi/launchers/type-1/style-1.rasi");
        
        if (file.Length == 0)
            throw new Exception("Rofi file is empty");

        var config = RofiParser.Parser(file);
        
        if (config == null)
            throw new Exception("Rofi file is invalid");

        RofiConverter.RofiConfigToJson(config);

        // BuildAvaloniaApp()
        //     .StartWithClassicDesktopLifetime(args);
    } 

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
#if DEBUG
            .WithDeveloperTools()
#endif
            .WithInterFont()
            .LogToTrace();
}