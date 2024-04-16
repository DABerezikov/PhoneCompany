namespace PhoneCompany.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(int id);
        T Get(int id);
        List<T> GetList();
        void Update(T entity);
    }
}
