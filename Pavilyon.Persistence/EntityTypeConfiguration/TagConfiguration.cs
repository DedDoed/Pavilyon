using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavilyon.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Persistence.EntityTypeConfiguration
{
    class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(tag => tag.Id);
            builder.HasIndex(tag => tag.Id).IsUnique();
        }
    }
}
