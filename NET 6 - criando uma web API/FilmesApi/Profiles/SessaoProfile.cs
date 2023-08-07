using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FilmesApi.Models;
using FilmesApi.Data.Dtos;

namespace FilmesApi.Profiles;
public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
    }
}