using EYE.Model;
using EYE.Model.DAO;

namespace EYE.Controller
{
	public class ControllerNotificacao
	{
		public void EnviarNotificacao(string mensagem, int codWorkspace, int codUsuario, bool usuario, bool workspace, int canal)
		{
			var codRemetente = Notificacao.GetCodRemetente(workspace, usuario, codWorkspace, codUsuario);
			if (codRemetente.Count>0)
				foreach(var remetente in codRemetente)
					StatementNotificacao.RegistrarNotificacao(mensagem, remetente.CodRemetente, canal, remetente.Remetente);
		}
	}
}