namespace FilmesApi.Controllers;

/*Importanto o padrão Mvc para APi*/
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;

/*Indicando que é um controlador*/
[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionarFilme ([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        /*Usamos o crea */
        return CreatedAtAction(nameof(RecuperarFilmePorId),
            new {id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperarFilmes ([FromQuery] int skip = 0,
    [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId (int id)
    {
        var filme = filmes.FirstOrDefault (filme => filme.Id == id);
        if(filme == null)
        {
            return NotFound("Filme não encontrado :(");
        }else
        {
            return Ok(filme);
        }
    }

}