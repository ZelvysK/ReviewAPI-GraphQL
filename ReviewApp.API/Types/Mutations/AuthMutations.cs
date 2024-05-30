using RestSharp;
using ReviewApp.API.Types.Auth;
using ReviewApp.API.Types.Inputs;

namespace ReviewApp.API.Types.Mutations;

[ExtendObjectType(Name = Constants.Mutation)]
public class AuthMutations
{
    [UseMutationConvention(PayloadFieldName = "auth")]
    public async Task<FirebaseRegisterResponse?> SignUp(
        [Service] SecretManager secretManager,
        SignUpInput input
    )
    {
        var client = new RestClient("https://identitytoolkit.googleapis.com/v1/accounts:signUp");

        var req = new RestRequest()
            .AddQueryParameter("key", secretManager.GetFirebaseApiKey())
            .AddJsonBody(
                new
                {
                    email = input.Email,
                    password = input.Password,
                    returnSecureToken = true
                }
            );

        var response = await client.PostAsync<FirebaseRegisterResponse>(req);

        return response;
    }

    [UseMutationConvention(PayloadFieldName = "auth")]
    public async Task<FirebaseLoginResponse?> SignIn(
        [Service] SecretManager secretManager,
        SignInInput input
    )
    {
        var client = new RestClient(
            "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword"
        );

        var req = new RestRequest()
            .AddQueryParameter("key", secretManager.GetFirebaseApiKey())
            .AddJsonBody(
                new
                {
                    email = input.Email,
                    password = input.Password,
                    returnSecureToken = true
                }
            );

        var response = await client.PostAsync<FirebaseLoginResponse>(req);

        return response;
    }
}
