using AdpWebLabs.Domain.Domain.Entities.Base;
using AdpWebLabs.Domain.Infra.Data.Repository.Interfaces.Base;

namespace AdpWebLabs.Domain.Infra.Data.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {

        protected readonly AdpWebLabsContext _context;

        public BaseRepository(AdpWebLabsContext context)
        {
            _context = context;
        }

        public T GetById(Guid id) => _context.Set<T>().Where(x => x.Id == id).FirstOrDefault() ?? new T();

        public async Task SaveAsync(T entity) => await Task.CompletedTask; //await _context.Set<T>().AddAsync(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
