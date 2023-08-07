namespace FilmesApi.Data;
using Microsoft.EntityFrameworkCore;
using FilmesApi.Models;

public class FilmeContext : DbContext
{
    /*O contrutor recebe as opçõe de acesso 
    ao banco*/
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {

    }

    /*Essa é uma propriedade que permite acesso aos
    filmes que existem na base*/
    public DbSet<Filme> Filmes {get; set;}
    public DbSet<Cinema> Cinemas {get; set;}
    public DbSet<Endereco> Enderecos {get; set;}
    public DbSet<Sessao> Sessoes {get; set;}

}