namespace PhoneCompany.Data.Entities;

public record Address

{
    public int Id { get; init; }
    
    public int StreetId { get; init; }
    
    public Street Street { get; set; }

    public string NumberHouse { get; init; }
    
    public override string ToString() => $"ул. {Street.Name} дом. {NumberHouse}";
}