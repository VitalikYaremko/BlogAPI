using BlogAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Header).HasMaxLength(100);
            builder.Property(x => x.Content).HasMaxLength(1000);
            builder.Property(x => x.Footer).HasMaxLength(100);
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.CreatedOn);
            builder.Property(x => x.IsVisible).HasDefaultValue(1).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(1).IsRequired();

            builder.ToTable("Posts");
        }
    }
}
