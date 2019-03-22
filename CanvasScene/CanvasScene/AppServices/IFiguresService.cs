using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CanvasScene.AppServices
{
    public interface IFiguresService
    {
        Task<IEnumerable<Figure>> GetFigures();
        Task<IEnumerable<Figure>> GetBy(Expression<Func<Figure, bool>> predicate);
    }
}
