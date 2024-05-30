namespace ReviewApp.API;

public class SecretManager(IConfiguration configuration)
{
    public string GetFirebaseApiKey()
    {
        var key = configuration["Firebase:ApiKey"];

        if (string.IsNullOrEmpty(key))
        {
            throw new InvalidOperationException("Firebase ApiKey is not set");
        }

        return key;
    }
}
