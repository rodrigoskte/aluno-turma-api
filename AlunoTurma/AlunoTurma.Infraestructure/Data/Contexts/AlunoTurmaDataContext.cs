using AlunoTurma.Application.Api.Dto;
using AlunoTurma.Infraestructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

public class AlunoTurmaDataContext : DbContext
{
    public AlunoTurmaDataContext(DbContextOptions<AlunoTurmaDataContext> options) : base(options){}
    
    public DbSet<Aluno> Alunos { get; set; }
    
    public DbSet<Turma> Turma { get; set; }
    
    public DbSet<AlunoxTurma> AlunosTurmas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlunoMap());
        modelBuilder.ApplyConfiguration(new TurmaMap());
        modelBuilder.ApplyConfiguration(new AlunoxTurmaMap());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared");
}