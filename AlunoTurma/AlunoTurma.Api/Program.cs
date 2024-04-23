using AlunoTurma.Application.Api.Dto;
using AlunoTurma.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder);

var app = builder.Build();
GetAluno();
PostAluno();
GetTurma();
PostTurma();
GetAlunoxTurma();
PostAlunoxTurma();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<AlunoTurmaDataContext>();
}

void GetAluno()
{
    app.MapGet("/v1/alunos", ([FromServices] AlunoTurmaDataContext context) =>
    {
        var alunos = context.Alunos.ToList();
        return new ResultViewModel<List<Aluno>>(alunos);
    });
}

void PostAluno()
{
    app.MapPost("/v1/alunos", async ([FromBody] Aluno model,
                                                 [FromServices] AlunoTurmaDataContext context) =>
    {
        if (model is null || !model.IsValid())
        {
            var validationProblems = model.GetValidationProblems();
            return Results.ValidationProblem(validationProblems);
        }
        
        try
        {
            var aluno = new Aluno()
            {
                Nome = model.Nome.ToLower(),
                Usuario = model.Usuario.ToLower(),
                Password = model.Password,
            };
            
            await context.Alunos.AddAsync(aluno);
            await context.SaveChangesAsync();
            return Results.Created($"/v1/alunos/{aluno.Id}", new ResultViewModel<Aluno>(aluno));
        }
        catch (DbUpdateException ex)
        {
            return Results.Problem(new ResultViewModel<string>("Não foi possível cadastrar o aluno. Erro: " + ex.Message).ToString(), statusCode: 500);
        }
        catch (Exception ex)
        {
            return Results.Problem(new ResultViewModel<string>("Falha interna do servidor. Erro: " + ex.Message).ToString(), statusCode: 500);
        }
    });
}

void GetTurma()
{
    app.MapGet("/v1/turma", ([FromServices] AlunoTurmaDataContext context) =>
    {
        var turma = context.Turma.ToList();
        return new ResultViewModel<List<Turma>>(turma);
    });
}

void PostTurma()
{
    app.MapPost("/v1/turma", async ([FromBody] Turma model, 
                                                  [FromServices] AlunoTurmaDataContext context) =>
    {
        if (model is null || !model.IsValid())
        {
            var validationProblems = model.GetValidationProblems();
            return Results.ValidationProblem(validationProblems);
        }
        
        try
        {
            var turma = new Turma()
            {
                NomeTurma = model.NomeTurma.ToLower(),
                Ano = model.Ano,
            };
            
            await context.Turma.AddAsync(turma);
            await context.SaveChangesAsync();
            return Results.Created($"/v1/turma/{turma.Id}", new ResultViewModel<Turma>(turma));
        }
        catch (DbUpdateException ex)
        {
            return Results.Problem(new ResultViewModel<string>("Não foi possível cadastrar a turma. Erro: " + ex.Message).ToString(), statusCode: 500);
        }
        catch (Exception ex)
        {
            return Results.Problem(new ResultViewModel<string>("Falha interna do servidor. Erro: " + ex.Message).ToString(), statusCode: 500);
        }
    });
}

void GetAlunoxTurma()
{
    app.MapGet("/v1/alunoxturma", ([FromServices] AlunoTurmaDataContext context) =>
    {
        var alunosxturmas = context.AlunosTurmas.ToList();
        return new ResultViewModel<List<AlunoxTurma>>(alunosxturmas);
    });
}

void PostAlunoxTurma()
{
    app.MapPost("/v1/alunoxturma", async ([FromBody] AlunoxTurma model, 
        [FromServices] AlunoTurmaDataContext context) =>
    {
        if (model is null || !model.IsValid())
        {
            var validationProblems = model.GetValidationProblems();
            return Results.ValidationProblem(validationProblems);
        }
        
        try
        {
            var alunoxTurma = new AlunoxTurma()
            {
                TurmaId = model.TurmaId,
                AlunoId = model.AlunoId,
            };
            
            await context.AlunosTurmas.AddAsync(alunoxTurma);
            await context.SaveChangesAsync();
            return Results.Created($"/v1/turma/{alunoxTurma.TurmaId}", new ResultViewModel<AlunoxTurma>(alunoxTurma));
        }
        catch (DbUpdateException ex)
        {
            return Results.Problem(new ResultViewModel<string>("Não foi possível cadastrar a turma. Erro: " + ex.Message).ToString(), statusCode: 500);
        }
        catch (Exception ex)
        {
            return Results.Problem(new ResultViewModel<string>("Falha interna do servidor. Erro: " + ex.Message).ToString(), statusCode: 500);
        }
    });
}