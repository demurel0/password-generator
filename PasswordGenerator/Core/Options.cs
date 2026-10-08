namespace PasswordGenerator;

public sealed class Options
{
    public const int MinLength = 8;
    public const int MaxLength = 64;
    private const int DefaultLength = 16;

    public int Length { get; set; } = DefaultLength;
    public bool UseLower { get; set; } = true;
    public bool UseUpper { get; set; } = true;
    public bool UseDigits { get; set; } = true;
    public bool UseSpecial { get; set; } = true;
    
    public static bool IsValidLength(int length) => length is >= MinLength and <= MaxLength;
}
