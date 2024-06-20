namespace ReviewApp.API.Interfaces;

public interface ICreatable
{
    DateTime CreatedAt { get; set; }
    string CreatedBy { get; set; }
}
