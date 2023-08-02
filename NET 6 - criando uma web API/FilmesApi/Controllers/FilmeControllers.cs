namespace FilmesApi.Controllers;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Profile;
using AutoMapper;

/*Importanto o padrão Mvc para APi*/
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;

/*Indicando que é um controlador*/
[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper; 

    /*O construtor tem que ser público,
    pois assim o banco pode ser acessado*/
    public FilmeController (FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarFilme ([FromBody] CreateFilmeDto filmeDto)
    {
        /*Convertendo um tipo dto em tipo filme*/
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        /*Usamos o CreatedAtAction para retornar o que foi
        inserido no banco de dados */
        return CreatedAtAction(nameof(RecuperarFilmePorId),
            new {id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes ([FromQuery] int skip = 0,
    [FromQuery] int take = 50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId (int id)
    {
        var filme = _context.Filmes.FirstOrDefault (filme => filme.Id == id);
        if(filme == null)
        {
            return NotFound("Filme não encontrado :(");
        }else
        {
            return Ok(filme);
        }
    }

}