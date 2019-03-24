using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CanvasScene.DAL.Specifications;
using System.Linq;
using CanvasScene.Entities;

namespace CanvasScene.DAL
{
    public class FiguresRepository : Repository<Figure>
    {
        public FiguresContext DbContext { get; }

        public FiguresRepository(FiguresContext context) : base(context)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override async Task<IEnumerable<Figure>> GetBy(FilterParams filter)
        {
            IQueryable<Figure> figuresSet = _dbContext.Set<Figure>();

            figuresSet = figuresSet.GetByName<Figure>(filter);
            figuresSet = figuresSet.GetByWidth<Figure>(filter);

            List<Figure> matched = await figuresSet.ToListAsync();
            return matched;
        }
    }
}
