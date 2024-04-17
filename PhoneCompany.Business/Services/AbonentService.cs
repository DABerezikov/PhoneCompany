using PhoneCompany.Common.Interfaces;
using PhoneCompany.Data.Entities;
using PhoneCompany.Data.Repositories.Interfaces;

namespace PhoneCompany.Business.Services
{
    public class AbonentService(
        IRepository<Abonent> abonents
        ) : IAbonentService
    {
        public ICollection<Abonent> Abonents => abonents.GetList();
       
    }
}
