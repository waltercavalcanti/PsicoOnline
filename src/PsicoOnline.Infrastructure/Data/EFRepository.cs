using Microsoft.EntityFrameworkCore;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using System.Linq.Expressions;

namespace PsicoOnline.Infrastructure.Data;

public class EFRepository<T, K>(EFContext db) : IDisposable, IRepository<T, K> where T : BaseEntity<K>
{
	protected EFContext _db { get; private set; } = db;

	public async Task<T> GetByIdAsync(K id) => await _db.Set<T>().FindAsync(id);

	public async Task<IReadOnlyList<T>> GetAllAsync() => await _db.Set<T>().ToListAsync();

	public async Task<IReadOnlyList<T>> GetWhereAsync(Expression<Func<T, bool>> where) => await _db.Set<T>().Where(where).ToListAsync();

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

	#region IDisposable Support
	private bool _disposed = false;

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				((IDisposable)_db).Dispose();
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