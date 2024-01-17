using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {

    
    
        private readonly FluentValidationDbcontext _dbcontext;

        public GenericRepository(FluentValidationDbcontext dbcontext)
        {
            _dbcontext=dbcontext;
        }
        public async Task Add(T T)
        {
            await _dbcontext.Set<T>().AddAsync(T);
        }

        public void Delete(T T)
        {
           _dbcontext.Set<T>().Remove(T);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public void Update(T T)
        {
            _dbcontext.Set<T>().Update(T);
        }
    }
}
