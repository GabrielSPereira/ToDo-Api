using GerenciamentoTodo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoTodo.Infrastructure.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UsuarioId)
                .IsRequired();
        }
    }
}
