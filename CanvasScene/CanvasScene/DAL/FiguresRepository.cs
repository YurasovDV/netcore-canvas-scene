using System;

namespace CanvasScene.DAL
{
    public class FiguresRepository : Repository<Figure>
    {
        public FiguresContext DbContext { get; }

        public FiguresRepository(FiguresContext context) : base(context)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
