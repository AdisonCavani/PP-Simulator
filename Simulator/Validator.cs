namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max) => Math.Clamp(value, min, max);

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();

        if (string.IsNullOrEmpty(value))
            return "Unknown";

        if (value.Length > 25)
            value = value.Substring(25).TrimEnd();

        if (value.Length < 3)
            value = value.PadRight(3, '#');

        if (char.IsLower(value[0]))
            value = char.ToUpper(value[0]) + value.Substring(1);

        return value;
    }
}
