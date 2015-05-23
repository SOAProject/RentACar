using RentACar.Api.Models;
using System.Data.Entity;
using System.Linq;

namespace RentACar.Api.Data
{
    public class EFRepository<T> : IRepository<T>
        where T : class
    {
        private RentACarDbContext context;
        private IDbSet<T> set;

        public EFRepository(RentACarDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Get(int id)
        {
            return this.set.Find(id);
        }


        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(int id)
        {
            var entity = this.Get(id);
            this.Delete(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}