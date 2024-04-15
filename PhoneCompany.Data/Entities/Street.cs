
namespace PhoneCompany.Data.Entities;

public class Street 

{

    public int Id { get; set; }

    public string Name { get; set; }
    
    public override string ToString() =>$"{Name}";
    
}