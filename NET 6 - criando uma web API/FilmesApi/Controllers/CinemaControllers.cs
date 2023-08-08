using AutoMapper;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;
[ApiController]
[Route("[controller]")]

public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController (FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarCinema ([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarCinemaPorId), new {id = cinema.Id}, cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperarCinemas([FromQuery] int skip = 0,
    [FromQuery] int take = 50, int? enderecoId = null)
    {
        if (enderecoId == null)
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take).ToList());
        }else
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.FromSqlRaw(
                $"SELECT Id, Nome, EnderecoId FROM Cinemas WHERE Cinemas.EnderecoId = {enderecoId}").ToList());
        }
    }

    [HttpGet("{id}")]

    public IActionResult RecuperarCinemaPorId (int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema != null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }else
        {
            return NotFound("Cinema não encontrado!");
        }
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarCinema (int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema != null)
        {
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }else
        {
            return NotFound("Cinema não encontrado!");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarCinema (int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema != null)
        {
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }else
        {
            return NotFound("Cinema não encontrado!");   
        }
    }
}