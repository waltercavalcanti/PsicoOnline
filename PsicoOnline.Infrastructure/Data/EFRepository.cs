using Microsoft.EntityFrameworkCore;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.Infrastructure.Data
{
    public class EFRepository<T, K> : IDisposable, IRepository<T, K> where T : BaseEntity<K>
    {
        protected EFContext db { get; private set; }

        public EFRepository(EFContext db)
        {
            this.db = db;
        }

        public T GetById(K id)
        {
            return db.Set<T>().Find(id);
        }

        public IReadOnlyList<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();

            return entity;
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public void DeleteAll(List<T> entities)
        {
            if (entities != null)
            {
                entities.ForEach(entity => this.Delete(entity));
            }
        }

        #region IDisposable Support
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ((IDisposable)this.db).Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}