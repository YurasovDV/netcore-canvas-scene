using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CanvasScene.DAL
{
    public class CirclesContext : DbContext
    {
        public CirclesContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Circle> Circles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CircleEntityConfiguration());

            modelBuilder.Entity<Circle>().HasData(
                new Circle()
                {
                    ID = 1,
                    Depth = 1,
                    Name = "N1",
                    Height = 10,
                    Width = 10
                },

                new Circle()
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
