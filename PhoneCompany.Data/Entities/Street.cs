using PhoneCompany.Common.Interfaces;

namespace PhoneCompany.Data.Entities;

public class Street : IEntity

{

    public int Id { get; set; }



    public string Name { get; set; }


    public override string ToString() =>$"{Name}";



}