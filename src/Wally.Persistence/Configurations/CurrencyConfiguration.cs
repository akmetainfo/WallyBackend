using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Persistence.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(p => p.Code)
                   .IsRequired()
                   .HasMaxLength(Currency.CodeMaxLength);
        }
    }
}