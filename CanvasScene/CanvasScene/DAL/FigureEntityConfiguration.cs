using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CanvasScene.DAL
{
    public class FigureEntityConfiguration : IEntityTypeConfiguration<Figure>
    {
        public void Configure(EntityTypeBuilder<Figure> builder)
        {
            builder.ToTable("Figures", "dbo");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Name).HasColumnType("nvarchar(100)");
        }
    }
}
