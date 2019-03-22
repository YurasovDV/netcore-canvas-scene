using System;
using CanvasScene.AppServices;
using CanvasScene.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CanvasScene
{
    public class CompositionRoot
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FiguresContext>(builder =>
            {
                builder.UseInMemoryDatabase("FiguresDatabase",
                    b => { });
            }, ServiceLifetime.Scoped);

            services.Add(new ServiceDescriptor(typeof(IFiguresService), typeof(FiguresService), ServiceLifetime.Scoped));
        }
    }
}