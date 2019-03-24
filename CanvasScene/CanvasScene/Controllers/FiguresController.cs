using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanvasScene.AppServices;
using CanvasScene.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CanvasScene.Controllers
{
    [Route("api/v1/[controller]")]
    public class FigureController : BaseController
    {
        public FigureController(IFiguresService figuresService, UserManager<AppUser> userManager) : base(figuresService, userManager)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<Figure>> Get([FromQuery]FilterParams filter)
        {
            IEnumerable<Figure> result = null;
            if (filter != null && !FilterParams.Empty.Equals(filter))
            {
                result = await _figuresService.GetBy(filter);
            }
            else
            {

                result = await _figuresService.GetFigures();
            }
            return result;
        }
    }
}
