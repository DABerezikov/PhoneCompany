namespace PhoneCompany.Data.Entities;

public record Abonent 
{
    public int Id { get; init; }

    public int AddressId { get; init; }
        
    public int PhoneNumberId { get; init; }
        
    public string Name { get; init; }
        
    public string LastName { get; init; }
        
    public string Patronymic { get; init; }
        
    public Address Address { get; set; }
        
    public PhoneNumbers PhoneNumbers { get; set; }
}