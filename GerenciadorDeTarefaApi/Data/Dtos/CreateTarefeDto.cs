using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefaApi.Data.Dtos;

public class CreateTarefaDto
{
    [Required]
    public string TituloTarefa {get; set;}

    [Required]
    public string DescricaoTarefa {get; set;}

    [Required]
    public DateTime DataTarefa {get; set;}
    
    [Required]
    public string StatusTarefa {get; set;}
}