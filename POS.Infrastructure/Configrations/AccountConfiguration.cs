using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Username)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Role)
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}
