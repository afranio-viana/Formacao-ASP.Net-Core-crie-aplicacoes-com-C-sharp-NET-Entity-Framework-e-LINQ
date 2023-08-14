using System.ConponentModel.DataAnnotations;
namespace UsuariosApi.Data.Dtos

public class CreateUsuarioDto
{
  [Required]
  public string UserName {get; set;}

  [Required]
  public DateTime DataNascimento {get; set;}  

  [Required]
  [DataType(DataType.Password)]
  public string Password {get; set;}

  [Required]
  [Compare("Password")]
  public string RePassword {get; set;}
}