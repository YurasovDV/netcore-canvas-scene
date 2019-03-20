using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CanvasScene.AppServices
{
    public interface ICircleService
    {
        Task<IEnumerable<Circle>> GetCircles();
        Task<IEnumerable<Circle>> GetBy(Expression<Func<Circle, bool>> predicate);
    }
}
