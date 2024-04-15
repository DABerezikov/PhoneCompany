namespace PhoneCompany.Data.Entities;

public class Address

{
    public int Id { get; set; }
    
    public int StreetId { get; set; }
    
    public Street Street { get; set; }

    public string NumberHouse { get; set; }
    
    public override string ToString() => $"ул. {Street.Name} дом. {NumberHouse}";
}