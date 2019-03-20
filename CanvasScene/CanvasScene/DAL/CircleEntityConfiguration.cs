using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CanvasScene.DAL
{
    public class CircleEntityConfiguration : IEntityTypeConfiguration<Circle>
    {
        public void Configure(EntityTypeBuilder<Circle> builder)
        {
            builder.ToTable("Circles", "dbo");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Name).HasColumnType("nvarchar(100)");
        }
    }
}
