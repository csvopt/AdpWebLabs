using AdpWebLabs.Domain.Domain.Entities.Base;

namespace AdpWebLabs.Domain.Infra.Data.Repository.Interfaces.Base
{
    public interface IBaseRepository<T> : IDisposable where T : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task SaveAsync(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}

