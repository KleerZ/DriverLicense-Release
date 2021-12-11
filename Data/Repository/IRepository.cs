using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> All { get; }
        public Task Add(TEntity entity);
        public Task Delete(TEntity entity);
        public Task Clear();
        public Task Update(int id, TEntity targetEntity);
        public Task Update(TEntity targetEntity);
        public Task<TEntity> FindById(int id);
    }
}