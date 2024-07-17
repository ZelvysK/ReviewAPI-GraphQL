namespace ReviewApp.API.Errors;

[GraphQLName("ErrorWithCode")]
public interface IErrorWithCode
{
    string Code { get; }
}

public class EntityByNameAlreadyExistsError : Exception, IErrorWithCode
{
    public string Code { get; } = "ENTITY_NAME_EXISTS";

    public EntityByNameAlreadyExistsError(string entityName)
        : base($"An entity with the name '{entityName}' already exists.") { }
}
