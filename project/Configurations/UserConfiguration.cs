using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.Models;

namespace project.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure Id as the primary key
            builder.HasKey(u => u.Id);

            // Configure FirstName, LastName, UserName and Email with a max length of 100
            builder.Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(u => u.UserName)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(u => u.Password)
              .HasMaxLength(150)
              .IsRequired();

            // Configure Email to be unique using an index
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasIndex(u => u.UserName)
               .IsUnique();

        }
    }
}
