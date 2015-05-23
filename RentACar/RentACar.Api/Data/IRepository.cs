namespace RentACar.Api.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Get(int id);

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(int id);

        int SaveChanges();
    }
}
