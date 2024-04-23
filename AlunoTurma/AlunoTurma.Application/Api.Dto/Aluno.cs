using System.ComponentModel.DataAnnotations;

namespace AlunoTurma.Application.Api.Dto;

public class Aluno
{
    [Required]
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
    
    public List<AlunoxTurma> AlunoTurmas { get; set; }
}