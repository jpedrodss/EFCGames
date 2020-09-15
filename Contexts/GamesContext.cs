using EFCGames.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCGames.Contexts
{
    public class GamesContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<JogoJogador> JogosJogadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data source=.\SQLEXPRESS;Initial Catalog=Jogos;user id=sa;password=sa132");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
