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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sessao>()
            .HasKey(sessao => new {sessao.FilmeId, sessao.CinemaId});

        modelBuilder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);
        
        modelBuilder.Entity<Sessao>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);

        modelBuilder.Entity<Endereco>()
        .HasOne(endereco => endereco.Cinema)
        .WithOne(cinema => cinema.Endereco)
        .OnDelete(DeleteBehavior.Restrict);
    }
    /*Essa é uma propriedade que permite acesso aos
    filmes que existem na base*/
    public DbSet<Filme> Filmes {get; set;}
    public DbSet<Cinema> Cinemas {get; set;}
    public DbSet<Endereco> Enderecos {get; set;}
    public DbSet<Sessao> Sessoes {get; set;}

}