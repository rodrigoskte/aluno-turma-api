using AlunoTurma.Application.Api.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlunoTurma.Infraestructure.Data.Mappings;

public class AlunoxTurmaMap: IEntityTypeConfiguration<AlunoxTurma>
{
    public void Configure(EntityTypeBuilder<AlunoxTurma> builder)
    {
        builder.ToTable("aluno_turma");

        builder.Property(e => e.AlunoId).HasColumnName("aluno_id");
        builder.Property(e => e.TurmaId).HasColumnName("turma_id");

        builder.HasKey(e => new { e.AlunoId, e.TurmaId });

        builder.HasOne(d => d.Aluno)
            .WithMany(p => p.AlunoTurmas)
            .HasForeignKey(d => d.AlunoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_aluno_turma_1_idx");

        builder.HasOne(d => d.Turma)
            .WithMany(p => p.AlunoTurmas)
            .HasForeignKey(d => d.TurmaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_turma_1_idx");
    }
}