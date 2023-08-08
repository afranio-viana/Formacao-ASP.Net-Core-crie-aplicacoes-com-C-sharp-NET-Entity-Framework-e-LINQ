namespace FilmesApi.Models;
using System.ComponentModel.DataAnnotations;

public class Filme
{
    [Key]
    [Required]
    public int Id {get; set;}
    
    [Required(ErrorMessage = "O título do Filme é obrigatório!")]
    public string Titulo {get; set;}

    [Required(ErrorMessage = "O Gênero do filme é obrigatório!")]
    [MaxLength(50, ErrorMessage = "O tamanhoo do Gênero não pode exceder 50 caracteres!")]
    public string Genero {get; set;}

    [Required(ErrorMessage = "A duração do filme é obrigatória")]
    [Range(40, 600, ErrorMessage = "A duração deve ser entre 40 e 600 minutos!")]
    public int Duracao {get; set;}

    [Required(ErrorMessage = "O Diretor é obrigatório")]
    public string Diretor {get; set;}
    public virtual ICollection<Sessao> Sessoes {get; set;}

}