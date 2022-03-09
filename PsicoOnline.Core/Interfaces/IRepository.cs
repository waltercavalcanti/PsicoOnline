using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IRepository<T, K> where T : BaseEntity<K>
    {
        T GetById(K id);

        IReadOnlyList<T> GetAll();

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteAll(List<T> entities);
    }
}