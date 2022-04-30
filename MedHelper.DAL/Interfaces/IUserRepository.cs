using MedHelper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.DAL.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> FindAll();

        Task<User> GetByIdAsync(int id);

        Task AddAsync(User entity);

        void Update(User entity);

        void Delete(User entity);

        Task DeleteByIdAsync(int id);
        Task<User> GetByIdWithDetailsAsync(int id);
    }
}
