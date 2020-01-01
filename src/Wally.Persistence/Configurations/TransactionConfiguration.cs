using Usol.Wally.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Usol.Wally.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(p => p.Source)
                   .WithMany(x => x.SourceTransactions)
                   .HasForeignKey(x => x.SourceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Destination)
                   .WithMany(x => x.DestinationTransactions)
                   .HasForeignKey(x => x.DestinationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.AmountSource)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.AmountDestination)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Comment)
                   .HasMaxLength(Transaction.CommentMaxLength);
        }
    }
}