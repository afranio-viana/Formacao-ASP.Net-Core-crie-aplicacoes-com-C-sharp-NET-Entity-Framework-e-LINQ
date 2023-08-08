
using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap < CreateCinemaDto, Cinema> ();
        CreateMap <UpdateCinemaDto, Cinema> ();
        /*Para o meu campo de ReadEnderecoDto, 
        eu pego da origem o meu meu campo de endereço e mapeio
        para ReadEnderecoDto, sendo essa operação, algo ensinado em EnderecoProfile*/
        CreateMap < Cinema, ReadCinemaDto> ()
            .ForMember(cinemaDto => cinemaDto.Endereco,
                opt => opt.MapFrom(cinema => cinema.Endereco))
                .ForMember(cinemaDto => cinemaDto.Sessoes,
                opt => opt.MapFrom(cinema => cinema.Sessoes));
    }
    
}