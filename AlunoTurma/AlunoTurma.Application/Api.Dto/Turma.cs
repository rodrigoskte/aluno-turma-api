using System.ComponentModel.DataAnnotations;

namespace AlunoTurma.Application.Api.Dto;

public class Turma
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [StringLength(45, ErrorMessage = "O nome da turma não deve exceder 45 caracteres.")]
    public string NomeTurma { get; set; }
    
    [Required]
    [Range(1900, 2100, ErrorMessage = "O ano deve estar entre 1900 e 2100.")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "O ano deve ser um número de 4 dígitos.")]
    public int Ano { get; set; }
    
    public List<AlunoxTurma> AlunoTurmas { get; set; }
}