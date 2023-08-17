using GerenciadorDeTarefaApi.Data.Dtos;
using GerenciadorDeTarefaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefaApi.Data;
public class TarefaContext : DbContext
{
    public TarefaContext(DbContextOptions<TarefaContext> opts) : base(opts)
    {

    }

    public DbSet<Tarefa> Tarefas {get; set;}
}