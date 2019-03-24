using System;
using CanvasScene.AppServices;
using Microsoft.AspNetCore.Mvc;
using CanvasScene.Entities;
using Microsoft.AspNetCore.Identity;

namespace CanvasScene.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IFiguresService _figuresService;
        protected readonly UserManager<AppUser> _userManager;

        public BaseController(IFiguresService figuresService, UserManager<AppUser> userManager)
        {
            _figuresService = figuresService ?? throw new ArgumentNullException(nameof(figuresService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
    }
}
