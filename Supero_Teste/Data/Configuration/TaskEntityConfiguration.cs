using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Tarefa", "dbo");
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasColumnName("Titulo").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100).ValueGeneratedNever();
            builder.Property(x => x.Description).HasColumnName("Descricao").HasColumnType("nvarchar(1000)").IsRequired().HasMaxLength(1000).ValueGeneratedNever();
            builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.CreateDate).HasColumnName("DataCriacao").HasColumnType("datetime").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ConclusionDate).HasColumnName("DataConclusao").HasColumnType("datetime").ValueGeneratedNever();
            builder.Property(x => x.EditionDate).HasColumnName("DataEdicao").HasColumnType("datetime").ValueGeneratedNever();
            builder.HasKey(x => x.Id);
        }
    }
}
