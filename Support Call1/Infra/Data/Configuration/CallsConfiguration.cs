using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support_Call1.Domain.Entities;

namespace Support_Call1.Infra.Data.Configuration
{
    public class CallsConfiguration : IEntityTypeConfiguration<Calls>
    {
        public void Configure(EntityTypeBuilder<Calls> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.ProblemType)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
