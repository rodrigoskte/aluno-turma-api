using AlunoTurma.Application.Api.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlunoTurma.Infraestructure.Data.Mappings;

public class TurmaMap : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        //Table
        builder.ToTable("Turma");
        
        // Chave Primária
        builder.HasKey(x => x.Id);
        
        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        // Propriedades
        builder.Property(x => x.NomeTurma)
            .IsRequired()
            .HasColumnName("NomeTurma")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(45);
        
       builder.Property(x => x.Ano)
            .IsRequired()
            .HasColumnName("Ano")
            .HasColumnType("INT")
            .HasMaxLength(4);
    }
}