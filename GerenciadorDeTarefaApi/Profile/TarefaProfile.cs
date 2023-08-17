
using AutoMapper;
using GerenciadorDeTarefaApi.Data.Dtos;
using GerenciadorDeTarefaApi.Models;

public class TarefaProfile : Profile
{
    public TarefaProfile()
    {
        CreateMap<CreateTarefaDto, Tarefa>();
        CreateMap<Tarefa,ReadTarefaDto>();
    }
}