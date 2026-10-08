namespace PasswordGenerator;

internal static class Help
{
    private const string Logo =
        """
        ┌──────────────────────┐
        │  ••••••••••          │
        └──────────────────────┘
        """;

    private static readonly (string Flags, string Description)[] Options =
    [
        ("-l, --length <length>", $"Password length ({PasswordGenerator.Options.MinLength}-{PasswordGenerator.Options.MaxLength})"),
        ("-L, --lower", "Exclude lowercase letters"),
        ("-U, --upper", "Exclude uppercase letters"),
        ("-D, --digits", "Exclude digits"),
        ("-S, --special", "Exclude special characters"),
        ("-h, --help", "Show help")
    ];

    public static void Print()
    {
        ColorConsole.WriteLine($"{Logo}\n", ConsoleColor.DarkBlue);

        ColorConsole.WriteLine("USAGE", ConsoleColor.DarkBlue);
        ColorConsole.Write("PasswordGenerator", ConsoleColor.DarkGreen);
        Console.WriteLine(" [options]\n");

        ColorConsole.WriteLine("OPTIONS", ConsoleColor.DarkBlue);
        foreach (var (flags, description) in Options)
        {
            ColorConsole.Write($"  {flags,-22}", ConsoleColor.DarkGreen);
            Console.WriteLine(description);
        }
    }
}
