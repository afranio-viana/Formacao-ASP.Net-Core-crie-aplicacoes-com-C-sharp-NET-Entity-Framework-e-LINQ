
using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profile;

public class CinemaProfile : AutoMapper.Profile
{
    public CinemaProfile()
    {
        CreateMap < CreateCinemaDto, Cinema> ();
        CreateMap <UpdateCinemaDto, Cinema> ();
        CreateMap < Cinema, ReadCinemaDto> ();
    }
    
}