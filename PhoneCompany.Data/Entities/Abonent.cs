using PhoneCompany.Common.Interfaces;
using System;
using System.Net;

namespace PhoneCompany.Data.Entities
{
    internal class Abonent : IEntity
    {
        public int Id { get; set; }

        public int AddressId { get; set; }



        public int PhoneNumberId { get; set; }



        public string Name { get; set; }



        public string LastName { get; set; }



        public string Patronymic { get; set; }



        public Address Address { get; set; }



        public PhoneNumber PhoneNumbers { get; set; }
    }
}
