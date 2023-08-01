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

    [HttpPost]
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine($"{filme.Titulo}");
    }

    [HttpGet]
    public void ExibirFilme()
    {
        foreach (Filme filme in filmes)
        {
            Console.WriteLine($"{filme.Titulo}");
        }
    }

}