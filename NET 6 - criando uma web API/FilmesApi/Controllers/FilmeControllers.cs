namespace FilmesApi.Controllers;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

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

   /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    
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
    public IEnumerable<ReadFilmeDto> RecuperarFilmes ([FromQuery] int skip = 0,
    [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
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
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }
    }

    [HttpPut("{id}")]
    /*Está utilizando um FromBody para indicar que as mudanças vão
    constar no corpo da requisição*/
    public IActionResult AtualizarFilme (int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault (filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound("Filme Não encontrado :(");
        }else
        {
            /*Os campos do filmeDto estão sendo mapeados
            no filme*/
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            /*Por padrão o retorno de uma atualização feita 
            com sucesso é NoContent*/
            return NoContent();
        }
    }

    [HttpPatch("{id}")]

    public IActionResult AtualizarFilmePatch (int id, 
        JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound("Filme Não encontrado :(");
        }else
        {
            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
            patch.ApplyTo(filmeParaAtualizar, ModelState);

            if(!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }else
            {
                _mapper.Map(filmeParaAtualizar, filme);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound("Filme Não encontrado :(");
        }else
        {
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }

}