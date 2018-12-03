using EYE.Model;
using EYE.Model.DAO;
using System.Web.UI.WebControls;

namespace EYE.Controller
{
    public class ControllerSlack
    {
        public bool Cadastrar(TextBox txtUrl, TextBox txtCanal, string cod_workspace, Label lblMensagem)
        {
            if (!Validacao.StringVazia(txtUrl, txtCanal))
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";
                return false;
            }

            var slack = new Slack();
            slack.Url = txtUrl.Text;
            slack.Canal = txtCanal.Text;
            slack.CodWorkspace = int.Parse(cod_workspace);
            if (StatementSlack.InserirSlack(slack))
            {
                lblMensagem.Text = "O cadastro funcionou, henrique troca essa mensahe, pq ta feio";
                txtUrl.Text = "";
                txtCanal.Text = "";
                return true;
            }
            lblMensagem.Text = "Ops, deu algo errado, acho que a culpa é nossa";
            return false;
        }
    }
}