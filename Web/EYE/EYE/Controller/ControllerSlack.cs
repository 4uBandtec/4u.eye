using EYE.Model;
using EYE.Model.DAO;
using System.Drawing;
using System.Web.UI.WebControls;

namespace EYE.Controller
{
    public class ControllerSlack
    {
        public bool Cadastrar(TextBox txtUrl, TextBox txtCanal, string cod_workspace, Label lblMensagem)
        {
            if (!Validacao.StringVazia(txtUrl, txtCanal))
            {
                lblMensagem.ForeColor = Color.Red;
                lblMensagem.Text = "Ops, acho que faltou digitar algo";
                return false;
            }

            var slack = new Slack();
            slack.Url = txtUrl.Text;
            slack.Canal = txtCanal.Text;
            slack.CodWorkspace = int.Parse(cod_workspace);
            if (StatementSlack.InserirSlack(slack))
            {

                lblMensagem.ForeColor = Color.YellowGreen;
                lblMensagem.Text = "Agora o EYE está no canal "+txtCanal.Text+" do seu workspace no Slack :)";
                txtUrl.Text = "";
                txtCanal.Text = "";
                return true;
            }
            lblMensagem.Text = "Ops, deu algo errado, acho que a culpa é nossa";
            return false;
        }
    }
}