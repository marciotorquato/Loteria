using Loteria.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using Loteria.Modelo;

namespace Loteria.Negocio
{
    public class MegaSenaServico : IMegaSenaServico
    {
        //Metodo responsavel por retornar um lista do tipo INT com numeros aleatorios
        public List<int> GerarRandom(int quantidade)
        {
            List<int> valores = new List<int>();

            while (valores.Count < quantidade)
            {
                Random random = new Random();
                int valor = random.Next(1, 60);

                if (!valores.Contains(valor))
                {
                    valores.Add(valor);
                }
            }

            return valores;
        }

        //Metodo Responsavel por verificar os jogos e retornar os objetos com a quantidade de acerto
        public List<MegaSena> VerificarJogos(List<int> resultado, List<MegaSena> jogos)
        {
            foreach (MegaSena mega in jogos)
            {
                List<int> valores = mega.valores;
                var quantidadeAcertos = resultado.Intersect(valores).ToList();

                mega.acerto = quantidadeAcertos.Count;
            }

            return jogos;
        }

        //Metodo responsavel por adicionar jogo em lista
        public List<MegaSena> AddJogo(List<MegaSena> listaJogos, List<int> valores)
        {
            MegaSena jogo = new MegaSena();

            //Primeiro Jogo
            if (listaJogos.Count == 1)
            {
                jogo.id = 1;
            }
            //Caso ja existam jogos salvos
            else
            {
                jogo.id = listaJogos.Count + 1;
            }

            jogo.valores = valores;

            //Adiciona Data e Hora
            jogo.DataHora = DateTime.Now;

            //Adiciono jogo a Lista de jogos
            listaJogos.Add(jogo);

            return listaJogos;
        }
        
    }
}