using AlunoTurma.Application.Api.Dto;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Vai deixar o appDbContext como serviço e o .net sempre vai cuidar
builder.Services.AddDbContext<AlunoTurmaDataContext>();

var app = builder.Build();
GetAluno();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.Run();

void GetAluno()
{
    app.MapGet("/alunos", () =>
    {
        return "RODAO";
        //return alunos;
    });
}