using RestSharp;
using ReviewApp.API.Errors;
using ReviewApp.API.Types.Auth;
using ReviewApp.API.Types.Base;
using ReviewApp.API.Types.Inputs;

namespace ReviewApp.API.Types.Mutations;

[ExtendObjectType(Name = Constants.Mutation)]
public class AuthMutations
{
    [UseMutationConvention(PayloadFieldName = "auth")]
    public async Task<FirebaseRegisterResponse?> SignUp(
        [Service] SecretManager secretManager,
        ReviewContext context,
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

        if (response is null)
        {
            throw new FailedToSignUpError();
        }

        context.Users.Add(
            new User
            {
                Name = input.DisplayName,
                Email = input.Email,
                RemoteId = response.LocalId,
                Role = UserRole.User
            }
        );

        if (await context.SaveChangesAsync() > 0 is false)
        {
            throw new FailedToSaveChangesError();
        }

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
