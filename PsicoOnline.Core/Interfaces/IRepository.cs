using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces;

public interface IRepository<T, K> where T : BaseEntity<K>
{
    Task<T> GetByIdAsync(K id);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task DeleteAllAsync(List<T> entities);
}