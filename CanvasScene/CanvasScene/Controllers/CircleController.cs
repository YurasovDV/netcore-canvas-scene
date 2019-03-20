using System.Collections.Generic;
using System.Threading.Tasks;
using CanvasScene.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace CanvasScene.Controllers
{
    [Route("api/v1/[controller]")]
    public class CircleController : BaseController
    {
        public CircleController(ICircleService circleService) : base(circleService)
        {
        }

        // OData?
        [HttpGet()]
        public async Task<IEnumerable<Circle>> Get()
        {
            return await CircleService.GetCircles();
        }
    }
}
