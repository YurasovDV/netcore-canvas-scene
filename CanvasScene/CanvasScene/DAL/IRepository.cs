using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CanvasScene.DAL
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> predicate);
    }
}
