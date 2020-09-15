using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCGames.Domains
{
    public class JogoJogador : BaseDomain
    {
        public Guid IdJogo { get; set; }
        [ForeignKey("IdJogo")]
        public Jogo Jogo { get; set; }

        public Guid IdJogador { get; set; }
        [ForeignKey("IdJogador")]
        public Jogador Jogador { get; set; }

    }
}
