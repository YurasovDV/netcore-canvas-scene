using CanvasScene.AppServices;
using CanvasScene.DAL;
using CanvasScene.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CanvasScene.IoC
{
    public class CompositionRoot
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AuthContext>(builder =>
            {
                builder.UseInMemoryDatabase("FiguresDatabase",
                    b => { });
            }, ServiceLifetime.Scoped);

            services.AddDbContext<FiguresContext>(builder =>
            {
                builder.UseInMemoryDatabase("FiguresDatabase",
                    b => { });
            }, ServiceLifetime.Scoped);

            services.Add(new ServiceDescriptor(typeof(IFiguresService), typeof(FiguresService), ServiceLifetime.Scoped));

            services.Add(new ServiceDescriptor(typeof(IRepository<Figure>), typeof(FiguresRepository), ServiceLifetime.Scoped));
        }
    }
}