namespace PasswordGenerator;

public static class InteractiveMode
{
    public static Options Run()
    {
        var length = ReadLength();

        while (true)
        {
            var useLower = ReadYesNo("Include lowercase letters?", defaultValue: true);
            var useUpper = ReadYesNo("Include uppercase letters?", defaultValue: true);
            var useDigits = ReadYesNo("Include digits?", defaultValue: true);
            var useSpecial = ReadYesNo("Include special characters?", defaultValue: true);

            if (useLower || useUpper || useDigits || useSpecial)
            {
                Console.WriteLine();

                return new Options
                {
                    Length = length,
                    UseLower = useLower,
                    UseUpper = useUpper,
                    UseDigits = useDigits,
                    UseSpecial = useSpecial
                };
            }

            ColorConsole.WriteLine("\nSelect at least one character set.", ConsoleColor.DarkRed);
        }
    }

    private static int ReadLength()
    {
        Console.Write($"Enter password length ({Options.MinLength}-{Options.MaxLength}): ");

        while (true)
        {
            var input = Console.ReadLine()?.Trim();

            if (input is null)
            {
                throw new ArgumentException("Input has ended.");
            }
            if (int.TryParse(input, out var length) && Options.IsValidLength(length))
            {
                return length;
            }

            ColorConsole.WriteLine($"Invalid length. Enter a number from {Options.MinLength} to {Options.MaxLength}.",  ConsoleColor.DarkRed);
            Console.Write("Try again: ");
        }
    }

    private static bool ReadYesNo(string question, bool defaultValue)
    {
        var hint = defaultValue ? "[Y/n]" : "[y/N]";
        Console.Write($"{question} {hint}: ");

        while (true)
        {
            var input = Console.ReadLine()?.Trim().ToLowerInvariant();

            switch (input)
            {
                case null or "":
                    return defaultValue;

                case "y" or "yes":
                    return true;

                case "n" or "no":
                    return false;
            }

            ColorConsole.Write($"Try again. {hint}: ", ConsoleColor.DarkRed);
        }
    }
}
