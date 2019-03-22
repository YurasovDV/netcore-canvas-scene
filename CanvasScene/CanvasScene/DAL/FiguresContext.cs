using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CanvasScene.DAL
{
    public class FiguresContext : DbContext
    {
        public FiguresContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Figure> Figures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FigureEntityConfiguration());

            modelBuilder.Entity<Figure>().HasData(
                new Figure()
                {
                    ID = 1,
                    Depth = 1,
                    Name = "N1",
                    Height = 10,
                    Width = 10
                },

                new Figure()
                {
                    ID = 2,
                    Depth = 2,
                    Name = "N2",
                    Height = 20,
                    Width = 20
                });

        }

    }
}
