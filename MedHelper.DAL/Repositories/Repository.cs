using MedHelper.DAL.Entities;
using MedHelper.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MedHelper.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MedHelperDBContext _context;
        private DbSet<T> _enteties;
        public Repository(MedHelperDBContext context)

        {
            _context = context;
            _enteties = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {

           await _enteties.AddAsync(entity);

        }

        public void Delete(T entity)
        {

            _enteties.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _enteties.SingleOrDefaultAsync(s => s.Id == id);
            Delete(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _enteties;
        }

        public T GetById(int id)
        {
            foreach (var item in _enteties)
            {
                if(item.Id==id)
                {
                    return item;
                }
            }
            return null;
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
