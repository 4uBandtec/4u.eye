using System;
using System.Collections.Generic;
using EYE.Model.Enum;

namespace EYE.Model
{
	public class Notificacao
	{
		private int codRemetente;
		private string mensagem;
		private CanalNotificacao canalEnvio;
		private Remetente remetente;
		private StatusVida vida;

		public int CodRemetente { get => codRemetente; set => codRemetente = value; }
		public string Mensagem { get => mensagem; set => mensagem = value; }
		public CanalNotificacao CanalEnvio { get => canalEnvio; set => canalEnvio = value; }
		public Remetente Remetente { get => remetente; set => remetente = value; }
		public StatusVida Vida { get => vida; set => vida = value; }
		
		public static List<Notificacao> GetCodRemetente(bool workspace, bool usuario, int codWorkspace, int codUsuario)
		{
			List<Notificacao> codRemetente = null;
			if (usuario)
				codRemetente.Add(new Notificacao {
				codRemetente= codUsuario,
				Remetente=Remetente.Usuario
				});
			if (workspace)
				codRemetente.Add(new Notificacao
				{
					codRemetente = codWorkspace,
					Remetente = Remetente.Workspace
				});
			return codRemetente;
		}
	}
}