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
            services.AddDbContext<CirclesContext>(builder =>
            {
                builder.UseInMemoryDatabase("CirclesDatabase",
                    b => { });
            }, ServiceLifetime.Scoped);

            services.Add(new ServiceDescriptor(typeof(ICircleService), typeof(CircleService), ServiceLifetime.Scoped));
        }
    }
}