using System;
using CanvasScene.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace CanvasScene.Controllers
{
    public class BaseController : Controller
    {
        protected IFiguresService FiguresService { get; }

        public BaseController(IFiguresService figuresService)
        {
            FiguresService = figuresService ?? throw new ArgumentNullException(nameof(figuresService));
        }
    }
}
