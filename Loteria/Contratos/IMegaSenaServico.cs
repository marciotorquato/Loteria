using Loteria.Modelo;
using System.Collections.Generic;

namespace Loteria.Contratos
{
    public interface IMegaSenaServico
    {
        List<int> GerarRandom(int quantidade);

        List<MegaSena> VerificarJogos(List<int> resultado, List<MegaSena> jogos);

        List<MegaSena> AddJogo(List<MegaSena> listaJogos, List<int> valores);
    }
}
