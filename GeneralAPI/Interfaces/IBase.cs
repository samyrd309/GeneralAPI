
using GeneralAPI.Interfaces; // Add this import statement

public interface IBase : IStateful
{
    public int Id {get;}
    int EntityId  { get; set; }
}