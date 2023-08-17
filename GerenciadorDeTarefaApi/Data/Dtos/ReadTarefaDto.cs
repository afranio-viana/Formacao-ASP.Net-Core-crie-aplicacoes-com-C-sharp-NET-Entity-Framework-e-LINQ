using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefaApi.Data.Dtos;

public class ReadTarefaDto
{
    public int IdTarefa { get; set;}
    public string TituloTarefa {get; set;}
    public string DescricaoTarefa {get; set;}
    public DateTime DataTarefa {get; set;}
    public string StatusTarefa {get; set;}
}