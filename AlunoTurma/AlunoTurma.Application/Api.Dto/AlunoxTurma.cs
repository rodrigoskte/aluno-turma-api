using System.Text.Json.Serialization;

namespace AlunoTurma.Application.Api.Dto;

public class AlunoxTurma
{
    public int AlunoId { get; set; }
    
    [JsonIgnore]
    public Aluno Aluno { get; set; }
    public int TurmaId { get; set; }
    
    [JsonIgnore]
    public Turma Turma { get; set; }
    
    public bool IsValid()
    {
        if (AlunoId.ToString().Length <= 0)
        {
            return false;
        }

        if (TurmaId.ToString().Length <= 0)
        {
            return false;
        }

        return true;
    }

    public IDictionary<string, string[]> GetValidationProblems()
    {
        var problems = new Dictionary<string, string[]>();
        if (AlunoId.ToString().Length <= 0)
        {
            problems.Add(nameof(AlunoId), new string[] { "O Aluno é obrigatório." });
        }
        
        if (AlunoId.ToString().Length <= 0)
        {
            problems.Add(nameof(TurmaId), new string[] { "A Turma é obrigatória." });
        }

        return problems;
    }
}