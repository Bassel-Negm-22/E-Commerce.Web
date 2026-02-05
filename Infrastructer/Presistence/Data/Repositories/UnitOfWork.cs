using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;

namespace Presistence.Data.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var typeName = typeof(TEntity).Name;
            if (_repositories.TryGetValue(typeName, out object? Value))
                return (IGenericRepository<TEntity, Tkey>)Value;
            else
            {
                var Repo = new GenericRepository<TEntity, Tkey>(_dbContext);
                _repositories[typeName] = Repo;
                return Repo;
            }
        }

        public async Task<int> SaveChangesAsync() =>await _dbContext.SaveChangesAsync();
        
    }
}
