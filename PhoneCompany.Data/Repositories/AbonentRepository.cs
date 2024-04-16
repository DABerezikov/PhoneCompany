using System.Data.SQLite;
using Dapper;
using PhoneCompany.Common.Interfaces;
using PhoneCompany.Data.Context;
using PhoneCompany.Data.Entities;

namespace PhoneCompany.Data.Repositories;

public class AbonentRepository(DbInitializer dbInitializer) : IRepository<Abonent>
{
    public SQLiteConnection Connection { get; } = dbInitializer.Connection;


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
        string sqlquery = @"SELECT  Abonent.Id, AddressId, PhoneNumberId, Abonent.Name, LastName, Patronymic,
                                    Address.Id, StreetId,
                                    Street.Id, Street.Name,
                                    PhoneNumber.Id, HomePhone, WorkPhone, MobilPhone
                            FROM Abonents

                            INNER JOIN PhoneNumbers ON Abonent.PhoneNumberId = PhoneNumber.Id

                            INNER JOIN ( SELECT Address.Id, StreetId,
                                                Street.Id, Street.Name
                                         FROM Streets
                                         INNER JOIN Addresses ON Address.StreetId = Street.Id 

                        ) AS Address ON Abonent.AddressId = Address.Id";



        

            return Connection.Query<Abonent, Address, PhoneNumber, Street, Abonent>(sqlquery,

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