using PsicoOnline.Core.Entities;
using System.Linq.Expressions;

namespace PsicoOnline.Core.Interfaces;

public interface IRepository<T, K> where T : BaseEntity<K>
{
	Task<T> GetByIdAsync(K id);

	Task<IReadOnlyList<T>> GetAllAsync();

	Task<IReadOnlyList<T>> GetWhereAsync(Expression<Func<T, bool>> where);

	Task<T> AddAsync(T entity);

	Task UpdateAsync(T entity);

	Task DeleteAsync(T entity);
}