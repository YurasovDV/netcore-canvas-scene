using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CanvasScene.DAL
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var result = await _dbContext.Set<T>().ToAsyncEnumerable().ToList();
            return result;
        }

        public virtual async Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> predicate)
        {
            var list = await _dbContext.Set<T>().Where(predicate).ToAsyncEnumerable().ToList();
            return list;
        }
    }
}
