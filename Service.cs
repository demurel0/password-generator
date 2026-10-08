using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator;

public static class Service
{
    private const string Lower = "abcdefghijklmnopqrstuvwxyz";
    private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Digits = "0123456789";
    private const string Special = "!@#$%^&*()_+-=";

    public static string Generate(Options options)
    {
        if (!Options.IsValidLength(options.Length))
        {
            throw new ArgumentException($"Length must be between {Options.MinLength} and {Options.MaxLength}.");
        }

        var poolBuilder = new StringBuilder();

        if (options.UseLower)
            poolBuilder.Append(Lower);
        if (options.UseUpper)
            poolBuilder.Append(Upper);
        if (options.UseDigits)
            poolBuilder.Append(Digits);
        if (options.UseSpecial)
            poolBuilder.Append(Special);

        var pool = poolBuilder.ToString();

        if (pool.Length == 0)
        {
            throw new ArgumentException("You cannot exclude all character sets at the same time.");
        }

        return RandomNumberGenerator.GetString(pool, options.Length);
    }
}
