using EYE.Model;
using EYE.Model.DAO;
using EYE.Model.Enum;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EYE.Controller
{
	public class ControllerTarefa
	{
		public bool Cadastrar(TextBox txtNome, TextBox txtDescricao, TextBox txtDataInicio, TextBox txtDataFim, int codWorkspace, Label lblMensagem, List<string> listaCodUsersTarefa, List<string> listaProcTarefa, List<string> listaTempoTarefa)
		{
			if (!Validacao.StringVazia(txtNome, txtDescricao, txtDataInicio, txtDataFim))
			{
				lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";
				return false;
			}
			var codTarefa = CadastrarTarefa(txtNome, txtDescricao, txtDataInicio, txtDataFim, codWorkspace, lblMensagem);
			var lista = ProcessoTarefa.ConstruirLista(listaCodUsersTarefa, listaCodUsersTarefa, listaTempoTarefa);
			return StatementTarefa.CadastrarProcessos(lista, codTarefa);
		}

		private static int CadastrarTarefa(TextBox txtNome, TextBox txtDescricao, TextBox txtDataInicio, TextBox txtDataFim, int codWorkspace, Label lblMensagem)
		{
			var tarefa = new Tarefa
			{
				Nome = txtNome.Text,
				Descricao = txtDescricao.Text,
				DataInicio = txtDataInicio.Text,
				DataFim = txtDataFim.Text,
				CodAndamento = Andamento.NaoIniciada,
				StatusVida = StatusVida.Ativo,
				CodWorkspace = codWorkspace
			};

			var codTarefa = StatementTarefa.InserirTarefa(tarefa);

			if (codTarefa > 0)
			{
				lblMensagem.Text = "A nova tarefa ja foi cadastrada, coloque os funcinarios pra trabalhar";
				txtNome.Text = "";
				txtDescricao.Text = "";
				txtDataInicio.Text = "";
				txtDataFim.Text = "";
			}
			else
			{
				lblMensagem.Text = "Ops, deu algo errado, acho que a culpa é nossa";
			}
			return codTarefa;
		}

		public Panel CarregarPainel(int codWorkspace)
        {
            var listaUsuarios=StatementUsuario.ListarUsuarios(codWorkspace);
            var ddlUsuarios = Usuario.AlimentarUsuarios(new DropDownList(), listaUsuarios);
            var listaProcessos = StatementProcesso.ListarProcessos();
            var ddlProcesso=Processo.AlimentarProcessos(new DropDownList(), listaProcessos);
            return new Tarefa().ConstruirConteudo(ddlUsuarios, ddlProcesso);          
            

        }
    }
}