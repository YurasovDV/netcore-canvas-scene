﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CanvasScene.DAL;

namespace CanvasScene.AppServices
{
    public class FiguresService : IFiguresService
    {
        public IRepository<Figure> Repository { get; }

        public FiguresService(IRepository<Figure> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Figure>> GetFigures()
        {
           var res = await Repository.GetAll();
            return res;
        }

        public async Task<IEnumerable<Figure>> GetBy(Expression<Func<Figure, bool>> predicate)
        {
            var res = await Repository.GetBy(predicate);
            return res;
        }
    }
}
