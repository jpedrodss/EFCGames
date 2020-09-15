using EFCGames.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCGames.Interfaces
{
    public interface IJogoRepository
    {
        void Adicionar(Jogo jogo);
        void Excluir(Guid id);
        void Editar(Jogo jogo);
        List<Jogo> Listar();
        Jogo BuscarID(Guid id);
    }
}
