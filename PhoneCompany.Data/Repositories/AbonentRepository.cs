using System.Data.SQLite;
using Dapper;
using PhoneCompany.Data.Context;
using PhoneCompany.Data.Entities;
using PhoneCompany.Data.Repositories.Interfaces;

namespace PhoneCompany.Data.Repositories;

public class AbonentRepository(DbInitializer dbInitializer) : IRepository<Abonent>
{
    public SQLiteConnection? Connection { get; } = dbInitializer.Connection;


    public void Create(Abonent abonent)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Abonent Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Abonent> GetList()
    {
        string sqlquery = @"SELECT  Abonents.Id,  Abonents.Name, LastName, Patronymic, 
                                    AddressId, Addresses.Id,  NumberHouse,
                                    PhoneNumberId, PhoneNumbers.Id, HomePhone, WorkPhone, MobilPhone, 
                                    StreetId, Streets.Id, Streets.Name 
                                   
                            FROM Abonents

                            INNER JOIN PhoneNumbers ON Abonents.PhoneNumberId = PhoneNumbers.Id

                            INNER JOIN Addresses ON Abonents.AddressId = Addresses.Id

                            INNER JOIN Streets ON Addresses.StreetId = Streets.Id";



        

            return Connection.Query<Abonent, Address, PhoneNumbers, Street, Abonent>(sqlquery,

                (abonent, address, phoneNumber, street) =>

                {

                    address.Street = street;

                    abonent.Address = address;

                    abonent.PhoneNumbers = phoneNumber;

                    return abonent;



                }, splitOn: "AddressId, PhoneNumberId, StreetId"

            ).ToList();

        

    }

    public void Update(Abonent abonent)
    {
        throw new NotImplementedException();
    }
}