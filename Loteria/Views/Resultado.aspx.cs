using Loteria.Modelo;
using Loteria.Negocio;
using System;
using System.Collections.Generic;
using System.Data;

namespace Loteria.Views
{
    public partial class Resultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Gerar resultado da megasena
            List<int> resultado = new MegaSenaServico().GerarRandom(6);

            string numeros = string.Empty;
            foreach (int i in resultado)
            {
                numeros += " - " + i.ToString();
            }

            //Exibo na tela resultado da MegaSena
            lblResultado.Text = numeros.Substring(2);

            //Obtenho os jogos que estao armazenados na sessão
            List<MegaSena> listaJogos = new List<MegaSena>();
            listaJogos = (List<MegaSena>)Session["jogos"];

            //Obtenho o resultado do sorteio e subscrevo a lista de jogos da megasena
            listaJogos = new MegaSenaServico().VerificarJogos(resultado, listaJogos);

            //Exibo resultado para usuário
            PreencherTabela(listaJogos);
        }

        public void PreencherTabela(List<MegaSena> jogos)
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("id", typeof(int));
            tabela.Columns.Add("jogo", typeof(string));
            tabela.Columns.Add("dataHora", typeof(string));
            tabela.Columns.Add("quantidadeAcertos", typeof(int));

            foreach (MegaSena m in jogos)
            {
                DataRow Row = tabela.NewRow();

                Row["id"] = m.id;

                string numeros = string.Empty;
                foreach (int i in m.valores)
                {
                    numeros += " - " + i.ToString();
                }
                Row["jogo"] = numeros.Substring(2);

                Row["dataHora"] = m.DataHora;

                Row["quantidadeAcertos"] = m.acerto;

                tabela.Rows.Add(Row);
            }

            gridResultado.DataSource = tabela;
            gridResultado.DataBind();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}