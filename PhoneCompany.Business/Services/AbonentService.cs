using PhoneCompany.Common.Interfaces;
using PhoneCompany.Data.Entities;
using PhoneCompany.Data.Repositories;

namespace PhoneCompany.Business.Services
{
    public class AbonentService(
        IRepository<Abonent> abonents,
        IUserDialog dialog
        ) : IAbonentService
    {
        private IRepository<Abonent> AbonentRepository = abonents;
        private IUserDialog Dialog = dialog;

        public ICollection<Abonent> Abonents => AbonentRepository.GetList();

       
    }
}
