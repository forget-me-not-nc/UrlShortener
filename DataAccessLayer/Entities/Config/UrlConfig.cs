using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities.Config
{
    internal class UrlConfig : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.ToTable("urls");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Urls)
                .HasForeignKey(x => x.UserId);

            builder.Property(x => x.BaseUrl)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasOne(x => x.Alias)
                .WithMany(x => x.Urls)
                .HasForeignKey(x => x.AliasId);

            builder.Property(x => x.Slug)
                .IsRequired();
        }
    }
}
