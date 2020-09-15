using EFCGames.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCGames.Interfaces
{
    public interface IJogadorRepository
    {
        void Adicionar(Jogador jogador);
        void Excluir(Guid id);
        void Editar(Jogador jogador);
        List<Jogador> Listar();
        Jogador BuscarID(Guid id);
    }
}
