namespace PasswordGenerator;

internal static class Program
{
    private static int Main(string[] args)
    {
        try
        {
            var options = Parser.Parse(args);

            if (options is null)
            {
                Help.Print();
                return 0;
            }

            var password = Service.Generate(options);

            ColorConsole.Write("Generated password: ", ConsoleColor.DarkBlue);
            ColorConsole.WriteLine(password,  ConsoleColor.DarkGreen);
            return 0;
        }
        catch (Exception exception)
        {
            ColorConsole.WriteLine(exception.Message, ConsoleColor.DarkRed);
            return 1;
        }
    }
}
