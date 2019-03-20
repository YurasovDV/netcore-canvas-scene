using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CanvasScene.DAL;

namespace CanvasScene.AppServices
{
    public class CircleService : ICircleService
    {
        public CirclesContext CirclesContext { get; }

        public CircleService(CirclesContext circlesContext)
        {
            CirclesContext = circlesContext ?? throw new ArgumentNullException(nameof(circlesContext));
        }

        public async Task<IEnumerable<Circle>> GetCircles()
        {
            return await CirclesContext.Circles.ToAsyncEnumerable().ToList();
        }

        public async Task<IEnumerable<Circle>> GetBy(Expression<Func<Circle, bool>> predicate)
        {
            var list = await CirclesContext.Circles.Where(predicate).ToAsyncEnumerable().ToList();
            return list;
        }
    }
}
