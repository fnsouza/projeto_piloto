using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("Nome").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100).ValueGeneratedOnAdd();
            builder.Property(x => x.Username).HasColumnName("Usuario").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20).ValueGeneratedOnAdd();
            builder.Property(x => x.Password).HasColumnName("Senha").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20).ValueGeneratedOnAdd();
            builder.Property(x => x.CreateDate).HasColumnName("DataCriacao").HasColumnType("datetime").IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
        }
    }
}
