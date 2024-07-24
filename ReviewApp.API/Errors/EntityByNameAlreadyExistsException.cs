namespace ReviewApp.API.Errors;

public class GqException(string code, string? message = null) : Exception(message)
{
    public string Code { get; } = code;
}
