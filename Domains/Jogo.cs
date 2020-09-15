using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCGames.Domains
{
    public class Jogo : BaseDomain
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLanc { get; set; }
    }
}
