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
				codRemetente.Add(new Notificacao
				{
					codRemetente = codUsuario,
					Remetente = Remetente.Usuario
				});
			if (workspace)
				codRemetente.Add(new Notificacao
				{
					codRemetente = codWorkspace,
					Remetente = Remetente.Workspace
				});
			return codRemetente;
		}
		public static string GerarMensagem(TipoMensagem tipo)
		{
			var numero = new Random().Next() % 3;
			switch (tipo)
			{
				case TipoMensagem.CadastroUsuario:
					if (numero == 0)
						return "Bem vindo ao Eye";
					else if (numero == 1)
						return "Bem vindo ao Eye";
					else if (numero == 2)
						return "Bem vindo ao Eye";
					else
						return "Bem vindo ao Eye";

				case TipoMensagem.CadastroTarefa:
					if (numero == 0)
						return "Uma nova tarefa foi cadastrada";
					else if (numero == 1)
						return "Uma nova tarefa foi cadastrada";
					else if (numero == 2)
						return "Uma nova tarefa foi cadastrada";
					else
						return "Uma nova tarefa foi cadastrada";

				case TipoMensagem.CadastroSlack:
					if (numero == 0)
						return "Agora estamos conectados";
					else if (numero == 1)
						return "Agora estamos conectados";
					else if (numero == 2)
						return "Agora estamos conectados";
					else
						return "Agora estamos conectados";

				case TipoMensagem.CPUElevada:
					if (numero == 0)
						return "Um de seus computadores vai fritar";
					else if (numero == 1)
						return "CPU alta";
					else if (numero == 2)
						return "CPU alta";
					else
						return "CPU alta";

				case TipoMensagem.RAMElevada:
					if (numero == 0)
						return "Um de seus vai explor";
					else if (numero == 1)
						return "RAM alta";
					else if (numero == 2)
						return "RAM alta";
					else
						return "RAM alta";
				case TipoMensagem.HDElevado:
					if (numero == 0)
						return "Um de seus vai explor";
					else if (numero == 1)
						return "RAM alta";
					else if (numero == 2)
						return "RAM alta";
					else
						return "RAM alta";
				default:
					return "Parece que algo de errado não está certo";
			}
		}
	}
}