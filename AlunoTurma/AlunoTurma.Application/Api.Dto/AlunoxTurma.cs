﻿namespace AlunoTurma.Application.Api.Dto;

public class AlunoxTurma
{
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }
    public int TurmaId { get; set; }
    public Turma Turma { get; set; }
}