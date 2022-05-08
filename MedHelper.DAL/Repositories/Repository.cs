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
            _context.SaveChanges();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _enteties.SingleOrDefaultAsync(s => s.Id == id);
            Delete(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return _enteties;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _enteties.SingleOrDefaultAsync(x=>x.Id==id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
