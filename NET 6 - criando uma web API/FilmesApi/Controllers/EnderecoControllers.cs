using AutoMapper;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdiconarEndereco ([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarEnderecoPorId), 
            new{id = endereco.Id}, endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperaEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
    }

    [HttpGet ("{id}")]
    public IActionResult RecuperarEnderecoPorId (int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco != null)
        {
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(enderecoDto);
        }else
        {
            return NotFound($"Endereco não encontrado");
        }
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco (int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco !=null)
        {
            _mapper.Map(enderecoDto,endereco);
            _context.SaveChanges();
            return NoContent();
        }else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarEndereco (int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco != null)
        {
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }else
        {
            return NotFound();
        }
    }
}