namespace EYE.Model.Enum
{
	public class Mensagens
	{
		private Mensagens(string value) { Value = value; }

		public string Value { get; set; }

		public static Mensagens TarefaCadastrada { get { return new Mensagens("Uma tarefa foi cadastrada em seu nome"); } }
		public static Mensagens TarefaAtrasada { get { return new Mensagens("Você tem tarefas para serem feitas"); } }

	}
}