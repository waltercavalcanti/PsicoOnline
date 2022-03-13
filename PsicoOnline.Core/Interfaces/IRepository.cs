using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IRepository<T, K> where T : BaseEntity<K>
    {
        Task<T> GetById(K id);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task DeleteAll(List<T> entities);
    }
}