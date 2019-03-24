using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanvasScene.AppServices
{
    public interface IFiguresService
    {
        Task<IEnumerable<Figure>> GetFigures();
        Task<IEnumerable<Figure>> GetBy(FilterParams filter);
    }
}
