using FilmesApi.Models;
using FilmesApi.Data.Dtos;

namespace FilmesApi.Data.Dtos;

public class ReadSessaoDto
{
    public int FilmeId { get; set;}  
    public int CinemaId {get; set;}
}