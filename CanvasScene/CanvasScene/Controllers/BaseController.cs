using System;
using CanvasScene.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace CanvasScene.Controllers
{
    public class BaseController : Controller
    {
        protected ICircleService CircleService { get; }

        public BaseController(ICircleService circleService)
        {
            CircleService = circleService ?? throw new ArgumentNullException(nameof(circleService));
        }
    }
}
