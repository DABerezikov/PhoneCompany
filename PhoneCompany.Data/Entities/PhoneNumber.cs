using PhoneCompany.Common.Interfaces;

namespace PhoneCompany.Data.Entities;

public class PhoneNumber : IEntity

{

    public int Id { get; set; }



    public string HomePhone { get; set; }



    public string WorkPhone { get; set; }



    public string MobilPhone { get; set; }



}