using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CanvasScene.DAL;

namespace CanvasScene.AppServices
{
    public class FiguresService : IFiguresService
    {
        public FiguresContext DbContext { get; }

        public FiguresService(FiguresContext context)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Figure>> GetFigures()
        {
            return await DbContext.Figures.ToAsyncEnumerable().ToList();
        }

        public async Task<IEnumerable<Figure>> GetBy(Expression<Func<Figure, bool>> predicate)
        {
            var list = await DbContext.Figures.Where(predicate).ToAsyncEnumerable().ToList();
            return list;
        }
    }
}
