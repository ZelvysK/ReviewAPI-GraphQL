namespace ReviewApp.API.Extensions;

public static class StringExtensions
{
    public static string ToFirstUpper(this string text)
    {
        return string.IsNullOrEmpty(text) ? text : char.ToUpper(text[0]) + text[1..];
    }
}