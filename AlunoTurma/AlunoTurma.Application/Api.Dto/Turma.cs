using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlunoTurma.Application.Api.Dto;

public class Turma
{
    [JsonIgnore]
    public int Id { get; set; }
    
    [Required]
    [StringLength(45, ErrorMessage = "O nome da turma não deve exceder 45 caracteres.")]
    public string NomeTurma { get; set; }
    
    [Required]
    [Range(1900, 2100, ErrorMessage = "O ano deve estar entre 1900 e 2100.")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "O ano deve ser um número de 4 dígitos.")]
    public int Ano { get; set; }
    
    [JsonIgnore]
    public List<AlunoxTurma> AlunoTurmas { get; set; }
    
    public bool IsValid()
    {
        if (string.IsNullOrEmpty(NomeTurma) || NomeTurma.Contains("string"))
        {
            return false;
        }

        if (Ano < 1900 || Ano > 2100 || Ano.ToString().Length != 4)
        {
            return false;
        }

        return true;
    }

    public IDictionary<string, string[]> GetValidationProblems()
    {
        var problems = new Dictionary<string, string[]>();
        if (string.IsNullOrEmpty(NomeTurma) || NomeTurma.Contains("string"))
        {
            problems.Add(nameof(NomeTurma), new string[] { "O nome da turma é obrigatório." });
        }
        
        if (Ano < 1900 || Ano > 2100 || Ano.ToString().Length != 4)
        {
            problems.Add(nameof(Ano), new string[] { "Ano inválido" });
        }
        return problems;
    }
}