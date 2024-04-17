namespace PhoneCompany.Data.Entities
{
    public class Abonent 
    {
        public int Id { get; set; }

        public int AddressId { get; set; }
        
        public int PhoneNumberId { get; set; }
        
        public string Name { get; set; }
        
        public string LastName { get; set; }
        
        public string Patronymic { get; set; }
        
        public Address Address { get; set; }
        
        public PhoneNumbers PhoneNumbers { get; set; }
    }
}
