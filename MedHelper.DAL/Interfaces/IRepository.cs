using System.Linq;
using System.Threading.Tasks;
using MedHelper.DAL.Entities;

namespace MedHelper.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> FindAll();

        TEntity GetById(int id);
        
        Task AddAsync(TEntity entity);
        
        void Update(TEntity entity);
        
        void Delete(TEntity entity);

        Task DeleteByIdAsync(int id);
    }
}