using System.Collections.Generic;
using System.Threading.Tasks;
using CanvasScene.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace CanvasScene.Controllers
{
    [Route("api/v1/[controller]")]
    public class FigureController : BaseController
    {
        public FigureController(IFiguresService figuresService) : base(figuresService)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<Figure>> Get([FromQuery]FilterParams filter)
        {
            IEnumerable<Figure> result = null;
            if (filter != null && !FilterParams.Empty.Equals(filter))
            {
                result = await FiguresService.GetBy(filter);
            }
            else
            {

                result = await FiguresService.GetFigures();
            }
            return result;
        }
    }
}
