using AutoMapper;
using GerenciadorDeTarefaApi.Data;
using GerenciadorDeTarefaApi.Data.Dtos;
using GerenciadorDeTarefaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

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

    /*Recebe uma TarefaDto e converte em tarefa*/
    [HttpPost]
    public IActionResult AdicionarTarefa ([FromBody] CreateTarefaDto tarefaDto)
    {
        Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarTarefaPorId),
            new{id = tarefa.IdTarefa}, tarefa);
    }

    /*Recebe cada tarefa e transforma em uma lista de ReadTarefaDto*/
    [HttpGet]
    public IEnumerable<ReadTarefaDto> RecuperarTarefa ()
    {
           return _mapper.Map<List<ReadTarefaDto>>(_context.Tarefas.ToList());
    }
    
    /*Recebe a tarefa e converte em uma ReadTarefaDto*/
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
            return NotFound($"Tarefa não encontrada");
        }
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizarTarefaPatch(int id, JsonPatchDocument<UpdateTarefaDto> patch)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.IdTarefa == id);
        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada :(");
        }else
        {
            var tarefaParaAtualizar = _mapper.Map<UpdateTarefaDto>(tarefa);
            patch.ApplyTo(tarefaParaAtualizar, ModelState);
            if(!TryValidateModel(tarefaParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }else
            {
                _mapper.Map(tarefaParaAtualizar, tarefa);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarTarefa(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.IdTarefa == id);
        if (tarefa == null)
        {
            return NotFound("Tarefa não encotrada :(");
        }else
        {
            _context.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}