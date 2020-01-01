using Usol.Wally.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Usol.Wally.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(Account.TitleMaxLength);

            builder.Property(p => p.Notes)
                   .IsRequired()
                   .HasMaxLength(Account.NotesMaxLength);
        }
    }
}