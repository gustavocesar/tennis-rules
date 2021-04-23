using System;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TennisContext : DbContext
    {
        public TennisContext(DbContextOptions<TennisContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(builder =>
            {
                builder.OwnsOne(x => x.Empatado)
                    .Property(x => x.Value)
                    .IsRequired();

                builder.OwnsOne(x => x.PontuacaoJogador1)
                    .Property(x => x.Pontos)
                    .IsRequired();

                builder.OwnsOne(x => x.PontuacaoJogador2)
                    .Property(x => x.Pontos)
                    .IsRequired();
            });
        }
    }
}