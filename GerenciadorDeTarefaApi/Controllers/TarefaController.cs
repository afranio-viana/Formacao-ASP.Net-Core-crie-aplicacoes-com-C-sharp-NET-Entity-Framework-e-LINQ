using AutoMapper;
using GerenciadorDeTarefaApi.Data;
using GerenciadorDeTarefaApi.Data.Dtos;
using GerenciadorDeTarefaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    private TarefaContext _context;
    private IMapper _mapper;

    public TarefaController (TarefaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarTarefa ([FromBody] CreateTarefaDto tarefaDto)
    {
        Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarTarefaPorId),
            new{id = tarefa.IdTarefa}, tarefa);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarTarefaPorId(int id)
    {
        Tarefa tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.IdTarefa == id);
        if(tarefa != null)
        {
            ReadTarefaDto tarefaDto = _mapper.Map<ReadTarefaDto>(tarefa);
            return Ok(tarefaDto);
        }else
        {
            return NotFound($"Tarefa naõ encontrada");
        }
    }
}