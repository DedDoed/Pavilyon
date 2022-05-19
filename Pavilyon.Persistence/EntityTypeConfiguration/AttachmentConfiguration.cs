using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavilyon.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Persistence.EntityTypeConfiguration
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(attachment => attachment.Id);
            builder.HasIndex(attachment => attachment.Id).IsUnique();
        }
    }
}
