using Usol.Wally.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Usol.Wally.Persistence.Configurations
{
    public class TransactionCategoryConfiguration : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Comment)
                   .HasMaxLength(TransactionCategory.CommentMaxLength);

            builder.HasOne(p => p.Transaction)
                   .WithMany(x => x.TransactionCategories)
                   .HasForeignKey(x => x.TransactionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Category)
                   .WithMany(x => x.TransactionCategories)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}