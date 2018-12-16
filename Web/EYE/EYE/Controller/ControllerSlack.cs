using EYE.Model;
using EYE.Model.DAO;
using System.Drawing;
using System.Web.UI.WebControls;

namespace EYE.Controller
{
	public class ControllerSlack
	{
		public bool Cadastrar(TextBox txtUrl, int cod_workspace, Label lblMensagem)
		{
			if (!Validacao.StringVazia(txtUrl))
			{
				lblMensagem.ForeColor = Color.Red;
				lblMensagem.Text = "Ops, acho que faltou digitar algo";
				return false;
			}

			var slack = new Slack();
			slack.Url = txtUrl.Text;
			slack.CodWorkspace = cod_workspace;
			if (StatementSlack.InserirSlack(slack))
			{

				lblMensagem.ForeColor = Color.YellowGreen;
				lblMensagem.Text = "Agora o EYE está conectado no seu workspace no Slack :)";
				txtUrl.Text = "";
				return true;
			}
			lblMensagem.Text = "Ops, deu algo errado, acho que a culpa é nossa";
			return false;
		}
		public void VerificaSlackCadastrado(TextBox txtUrl, Button btnCadastrar, int codWorkspace)
		{
			var url = StatementSlack.VerificaUrlCadastrada(codWorkspace);
			if (url != null && url.Length>0)
			{
				txtUrl.Text = url;
				btnCadastrar.Text = "Atualizar";
			}
		}

	}
}