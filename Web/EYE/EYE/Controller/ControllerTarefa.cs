using EYE.Model;
using EYE.Model.DAO;
using System.Web.UI.WebControls;

namespace EYE.Controller
{
	public class ControllerTarefa
	{
		public bool Cadastrar(TextBox txtNome, TextBox txtDescricao, TextBox txtDataInicio, TextBox txtDataFim, TextBox txtDataConclusao, string codWorkspace, Label lblMensagem)
		{
			if (!Validacao.StringVazia(txtNome, txtDescricao, txtDataInicio, txtDataFim, txtDataConclusao))
			{
				lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";
				return false;
			}

			var tarefa = new Tarefa();
			tarefa.Nome = txtNome.Text;
			tarefa.Descricao = txtDescricao.Text;
			tarefa.DataInicio = txtDataInicio.Text;//Colocar data de hoje
			tarefa.DataFim = txtDataFim.Text;
			tarefa.DataConclusao = txtDataConclusao.Text;  
			tarefa.CodWorkspace = int.Parse(codWorkspace);


			if (StatementTarefa.InserirTarefa(tarefa))
			{
				lblMensagem.Text = "A nova tarefa ja foi cadastrada, coloque os funcinarios pra trabalhar";

				txtNome.Text = "";
				txtDescricao.Text = "";
				txtDataInicio.Text = "";
				txtDataFim.Text = "";
				txtDataConclusao.Text = "";

				return true;
			}
			lblMensagem.Text = "Ops, deu algo errado, acho que a culpa é nossa";
			return false;
		}
	}
}