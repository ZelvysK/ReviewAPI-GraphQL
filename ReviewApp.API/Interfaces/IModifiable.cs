namespace ReviewApp.API.Interfaces;

public interface IModifiable
{
    DateTime? ModifiedAt { get; set; }
    string? ModifiedBy { get; set; }
}
