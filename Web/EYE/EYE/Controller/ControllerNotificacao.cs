using System.Collections.Generic;
using EYE.Model;
using EYE.Model.DAO;
using EYE.Model.Enum;

namespace EYE.Controller
{
	public class ControllerNotificacao
	{
		public static void EnviarNotificacao(string mensagem, int codWorkspace, int codUsuario, bool workspace, bool usuario, CanalNotificacao canal)
		{
			var codRemetente = Notificacao.GetCodRemetente(workspace, usuario, codWorkspace, codUsuario);
			if (codRemetente.Count > 0)
				foreach (var remetente in codRemetente)
					StatementNotificacao.RegistrarNotificacao(mensagem, remetente.CodRemetente, canal, remetente.Remetente);
		}
		public static void CadastrarNotificacaoTarefa(List<ProcessoTarefa> lista, int codWorkspace, bool notificacaoEquipe, bool notificacaoUsuarios)
		{
			foreach (var item in lista)
			{
				EnviarNotificacao(Notificacao.GerarMensagem(TipoMensagem.CadastroProcessoTarefa, item.NomeUsuario), codWorkspace, item.CodUsuario, false, notificacaoUsuarios, CanalNotificacao.Local);

			}
			EnviarNotificacao(Notificacao.GerarMensagem(TipoMensagem.CadastroTarefa, ""), codWorkspace, 0, notificacaoEquipe, false, CanalNotificacao.SlackApp);

		}
		public static void CadastrarNotificacaoUsuario(int codWorkspace, int codUsuario)
		{

			EnviarNotificacao(Notificacao.GerarMensagem(TipoMensagem.CadastroUsuario, StatementUsuario.GetNomeUsuario(codUsuario)), codWorkspace, codUsuario, false, true, CanalNotificacao.Local);
			EnviarNotificacao(Notificacao.GerarMensagem(TipoMensagem.CadastroUsuarioSlack, StatementUsuario.GetNomeUsuario(codUsuario)), codWorkspace, codUsuario, true, false, CanalNotificacao.SlackApp);

		}
	}
}