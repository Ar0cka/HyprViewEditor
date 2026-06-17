using Avalonia;
using System;
using System.IO;
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

        foreach (var import in config.imports)
        {
            Console.WriteLine("import: " + import);
        }
        
        foreach (var block in config.blocks)
        {
            Console.WriteLine(block.Key);
            foreach (var expression in block.Value.Expressions)
            {
                Console.WriteLine(expression.Name, expression.Properties);
            }

            foreach (var property in block.Value.Properties)
            {
                foreach (var value in property.PropertyValues)
                {
                    Console.WriteLine(property.PropertyName + " : " + value);
                }
            }
        }
        
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