using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavilyon.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Persistence.EntityTypeConfiguration
{
    public class StageConfiguration : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.HasKey(stage => stage.Id);
            builder.HasIndex(stage => stage.Id).IsUnique();
        }
    }
}
