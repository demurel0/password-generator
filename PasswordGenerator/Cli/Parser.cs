namespace PasswordGenerator;

public static class Parser
{
    public static Options? Parse(string[] args)
    {
        if (args.Length == 0)
        {
            return InteractiveMode.Run();
        }

        var options = new Options();

        for (var i = 0; i < args.Length; i++)
        {
            var arg = args[i];

            switch (arg)
            {
                case "--length" or "-l":
                    if (i + 1 < args.Length && int.TryParse(args[++i], out var length))
                    {
                        options.Length = length;
                    }
                    else
                    {
                       throw new ArgumentException($"A number must be specified after the '{arg}' flag.");
                    }
                    break;

                case "--lower" or "-L":
                    options.UseLower = false;
                    break;

                case "--upper" or "-U":
                    options.UseUpper = false;
                    break;

                case "--digits" or "-D":
                    options.UseDigits = false;
                    break;

                case "--special" or "-S":
                    options.UseSpecial = false;
                    break;

                case "--help" or "-h":
                    return null;

                default:
                    if (int.TryParse(arg, out var quickLength))
                    {
                        options.Length = quickLength;
                    }
                    else
                    {
                        throw new ArgumentException($"Unknown argument: '{arg}'. Use '-h' or '--help' for help.");
                    }
                    break;
            }
        }
        return options;
    }
}
