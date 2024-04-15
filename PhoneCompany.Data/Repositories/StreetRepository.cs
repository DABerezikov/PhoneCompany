using Dapper;
using PhoneCompany.Common.Interfaces;
using PhoneCompany.Data.Context;
using PhoneCompany.Data.Entities;

namespace PhoneCompany.Data.Repositories
{
    public class StreetRepository(DbInitializer dbInitializer) : IRepository<Street>
    {
        public DbInitializer DbInitializer { get; } = dbInitializer;


        public void Create(Street street)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Street Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Street> GetList()
        {
            var query = "SELECT * FROM Streets";

           return DbInitializer.Connection.Query<Street>(query).ToList();

           
        }

        public void Update(Street street)
        {
            throw new NotImplementedException();
        }
    }
}
