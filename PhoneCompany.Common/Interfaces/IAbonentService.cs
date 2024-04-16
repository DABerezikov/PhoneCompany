using PhoneCompany.Data.Entities;

namespace PhoneCompany.Common.Interfaces
{
    public interface IAbonentService
    {
        ICollection<Abonent> Abonents { get; }
    }
}
