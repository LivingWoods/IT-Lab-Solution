using System;
using Domain.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("History");
            builder.Property(x => x.Action);
            builder.Property(x => x.Student).HasMaxLength(100).IsRequired();
        }
    }
}

