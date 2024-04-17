
namespace PhoneCompany.Data.Entities;

public record Street 

{

    public int Id { get; init; }

    public string Name { get; init; }
    
    public override string ToString() =>$"{Name}";
    
}