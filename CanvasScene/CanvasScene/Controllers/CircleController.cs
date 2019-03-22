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

        // OData?
        [HttpGet()]
        public async Task<IEnumerable<Figure>> Get()
        {
            return await FiguresService.GetFigures();
        }
    }
}
