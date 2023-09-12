using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities.Config
{
    public class AliasConfig : IEntityTypeConfiguration<Alias>
    {
        public void Configure(EntityTypeBuilder<Alias> builder)
        {
            builder.ToTable("aliases");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AliasSlug)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
