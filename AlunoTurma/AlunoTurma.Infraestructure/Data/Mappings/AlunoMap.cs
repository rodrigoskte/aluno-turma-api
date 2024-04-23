using AlunoTurma.Application.Api.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlunoTurma.Infraestructure.Data.Mappings;

public class AlunoMap : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        //Table
        builder.ToTable("Aluno");
        
        // Chave Primária
        builder.HasKey(x => x.Id);
        
        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        // Propriedades
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);
        
        builder.Property(x => x.Usuario)
            .IsRequired()
            .HasColumnName("Usuario")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(45);
        
        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Password")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
    }
}