using EFCGames.Contexts;
using EFCGames.Domains;
using EFCGames.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCGames.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly GamesContext _ctx;

        public JogadorRepository()
        {
            _ctx = new GamesContext();
        }

        public void Adicionar(Jogador jogador)
        {
            try
            {
                _ctx.Jogadores.Add(jogador);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Jogador BuscarID(Guid id)
        {
            try
            {
                return _ctx.Jogadores.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Jogador jogador)
        {
            try
            {
                Jogador jogadorTemp = BuscarID(jogador.Id);

                if (jogadorTemp == null)
                    throw new Exception("Jogador não encontrado");

                jogadorTemp.Nome     = jogador.Nome;
                jogadorTemp.Email    = jogador.Email;
                jogadorTemp.Senha    = jogador.Senha;
                jogadorTemp.DataNasc = jogador.DataNasc;

                _ctx.Jogadores.Update(jogadorTemp);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                Jogador jogadorTemp = BuscarID(id);

                if (jogadorTemp == null)
                    throw new Exception("Jogador não encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Jogador> Listar()
        {
            try
            {
                List<Jogador> jogadores = _ctx.Jogadores.ToList();
                return jogadores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
