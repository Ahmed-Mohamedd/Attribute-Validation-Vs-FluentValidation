using Core.Repositories;
using Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FluentValidationDbcontext _dbcontext;
        private Hashtable _repositories;
        public UnitOfWork(FluentValidationDbcontext dbcontext)
        {
            _dbcontext=dbcontext;
        }
        public Task<int> Complete()
        => _dbcontext.SaveChangesAsync();

        public ValueTask DisposeAsync()
        => _dbcontext.DisposeAsync();

        public IGenericRepository<Tentity> Repository<Tentity>() where Tentity : class
        {
            if(_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(Tentity).Name;
            if(!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<Tentity>(_dbcontext);
                _repositories.Add(type, repository);
            }

            return (IGenericRepository<Tentity>) _repositories[type];
        }
    }
}
