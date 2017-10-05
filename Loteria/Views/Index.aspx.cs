using Loteria.Modelo;
using Loteria.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace Loteria.Views
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["jogos"] != null) {
                PreencherTabela();
            }
        }

        public void PreencherTabela() {

            List<MegaSena> listaJogos = new List<MegaSena>();
            listaJogos = (List<MegaSena>)Session["jogos"];


            DataTable tabela = new DataTable();
            tabela.Columns.Add("id", typeof(int));
            tabela.Columns.Add("jogo", typeof(string));
            tabela.Columns.Add("dataHora", typeof(string));

            foreach (MegaSena m in listaJogos) {
                DataRow Row = tabela.NewRow();

                Row["id"] = m.id;

                string numeros = string.Empty;
                foreach (int i in m.valores) {
                    numeros += " - " + i.ToString();
                }
                Row["jogo"] = numeros.Substring(2);

                Row["dataHora"] = m.DataHora;
                tabela.Rows.Add(Row);
            }            

            gridJogo.DataSource = tabela;
            gridJogo.DataBind();             
            
        }

        protected void btnAddJogo_Click(object sender, EventArgs e)
        {
            //Obtenho todos os textbox
            var textBoxes = new TextBox[] { txtPrimeiro, txtSegundo, txtTerceiro, txtQuarto, txtQuinto, txtSexto };

            //Verifico se algum textbox esta vazio
            if (textBoxes.Any(tb => tb.Text == String.Empty))
            {
                lblRetorno.Text = "Favor preencher todos os campos do formulário.";
            }
            //Verifico se valores informados vao de 1 a 60
            else if (textBoxes.Any(tb => Convert.ToInt32(tb.Text) < 1 || Convert.ToInt32(tb.Text) > 60))
            {
                lblRetorno.Text = "Só é aceito valores de 1 a 60.";
            }
            else {
                List<int> valores = new List<int>();

                //Preencho a lista de valores
                foreach (TextBox t in textBoxes)
                {
                    valores.Add(Convert.ToInt32(t.Text));
                }

                //Verifico se tem algum numero duplicado
                var query = valores.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
                if (query.Count > 0) {
                    lblRetorno.Text = "Não pode haver numeros repetidos.";
                }
                else {
                    List<MegaSena> listaJogos = new List<MegaSena>();

                    //Primeiro Jogo
                    if (Session["jogos"] != null)
                        listaJogos = (List<MegaSena>)Session["jogos"];

                    listaJogos = new MegaSenaServico().AddJogo(listaJogos, valores);

                    //Adiciono a lista de jogos na sessao
                    Session["jogos"] = listaJogos;

                    //Preencher GridView
                    PreencherTabela();
                }
            }            
        }
        
        
        protected void btnSurpresinha_Click(object sender, EventArgs e)
        {
            List<MegaSena> listaJogos = new List<MegaSena>();

            if (Session["jogos"] != null)
            {
                listaJogos = (List<MegaSena>)Session["jogos"];
            }            

            List<int> valores = new MegaSenaServico().GerarRandom(6);

            listaJogos = new MegaSenaServico().AddJogo(listaJogos, valores);
            
            Session["jogos"] = listaJogos;
            PreencherTabela();
        }

        protected void btnSortear_Click(object sender, EventArgs e)
        {
            //Verifico se algum jogo foi feito
            if (Session["jogos"] == null)
            {
                lblRetorno.Text = "Nenhum jogo feito.";
            }
            else {
                Response.Redirect("Resultado.aspx");
            }
        }

        protected void btnResetar_Click(object sender, EventArgs e)
        {
            Session["jogos"] = null;
            Response.Redirect("Index.aspx");
        }
    }
}