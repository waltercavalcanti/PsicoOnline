using Microsoft.EntityFrameworkCore;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.Infrastructure.Data
{
    public class EFRepository<T, K> : IDisposable, IRepository<T, K> where T : BaseEntity<K>
    {
        protected EFContext _db { get; private set; }

        public EFRepository(EFContext db)
        {
            _db = db;
        }

        public async Task<T> GetByIdAsync(K id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(List<T> entities)
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    await DeleteAsync(entity);
                }
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
                    ((IDisposable)this._db).Dispose();
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