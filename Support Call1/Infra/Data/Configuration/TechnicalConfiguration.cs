using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support_Call1.Domain.Entities;

namespace Support_Call1.Infra.Data.Configuration
{
    public class TechnicalConfiguration : IEntityTypeConfiguration<Technical>
    {
        public void Configure(EntityTypeBuilder<Technical> builder)
        {
            builder.HasKey(t => t.id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.Speciality)
                .IsRequired()
                .HasMaxLength(255);



            builder.ToTable("Technicals");
        }
    }
}
