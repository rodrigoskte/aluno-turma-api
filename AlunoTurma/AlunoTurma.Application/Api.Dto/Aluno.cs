using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace AlunoTurma.Application.Api.Dto;

public class Aluno
{
    [JsonIgnore]
    public int Id { get; set; } 
    
    [Required]
    [StringLength(255, ErrorMessage = "O nome não deve exceder 255 caracteres.")]
    public string Nome { get; set; }
    
    [Required]
    [StringLength(45, ErrorMessage = "O usuário não deve exceder 45 caracteres.")]
    public string Usuario { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [StringLength(60, ErrorMessage = "A senha não deve exceder 60 caracteres.")]
    public string Password { get; set; }
    
    [JsonIgnore]
    public List<AlunoxTurma> AlunoTurmas { get; set; }

    public bool IsValid()
    {
        if (string.IsNullOrEmpty(Nome) || Nome.Contains("string"))
        {
            return false;
        }

        if (string.IsNullOrEmpty(Usuario) || Usuario.Contains("string"))
        {
            return false;
        }
        
        if (string.IsNullOrEmpty(Password) || Password.Length < 6|| Password.Contains("string"))
        {
            return false;
        }

        return true;
    }

    public IDictionary<string, string[]> GetValidationProblems()
    {
        var problems = new Dictionary<string, string[]>();
        if (string.IsNullOrEmpty(Nome) || Nome.Contains("string"))
        {
            problems.Add(nameof(Nome), new string[] { "O nome é obrigatório." });
        }
        
        if (string.IsNullOrEmpty(Usuario)|| Usuario.Contains("string"))
        {
            problems.Add(nameof(Usuario), new string[] { "O usuário é obrigatório." });
        }

        if (string.IsNullOrEmpty(Password) || Password.Length < 6|| Password.Contains("string"))
        {
            problems.Add(nameof(Password), new string[] { "A senha deve ter pelo menos 6 caracteres." });
        }
        return problems;
    }
}