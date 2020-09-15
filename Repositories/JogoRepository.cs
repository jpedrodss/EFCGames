using EFCGames.Contexts;
using EFCGames.Domains;
using EFCGames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCGames.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly GamesContext _ctx;

        public JogoRepository()
        {
            _ctx = new GamesContext();
        }

        public void Adicionar(Jogo jogo)
        {
            try
            {
                _ctx.Jogos.Add(jogo);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Jogo BuscarID(Guid id)
        {
            try
            {
                return _ctx.Jogos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Jogo jogo)
        {
            try
            {
                Jogo jogoTemp = BuscarID(jogo.Id);

                if (jogoTemp == null)
                    throw new Exception("Jogo não encontrado.");

                jogoTemp.Nome = jogo.Nome;
                jogoTemp.Descricao = jogo.Descricao;
                jogoTemp.DataLanc = jogo.DataLanc;

                _ctx.Jogos.Update(jogoTemp);

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
                Jogo jogo = BuscarID(id);

                if (jogo == null)
                    throw new Exception("Jogo não encontrado.");

                _ctx.Jogos.Remove(jogo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Jogo> Listar()
        {
            try
            {
                List<Jogo> jogos = _ctx.Jogos.ToList();
                return jogos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
