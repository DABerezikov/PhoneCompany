namespace PhoneCompany.Data.Entities;

public record PhoneNumbers

{

    public int Id { get; init; }

    public string HomePhone { get; init; }

    public string WorkPhone { get; init; }

    public string MobilPhone { get; init; }

}