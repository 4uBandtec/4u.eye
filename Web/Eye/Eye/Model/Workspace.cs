namespace EYE.Model
{
    public class Workspace
    {

        private int codWorkspace;
        private string workspacename;
        private string nome;
        private string email;
        private string senha;
        private int salt;

		public int CodWorkspace { get => codWorkspace; set => codWorkspace = value; }
		public string Workspacename { get => workspacename; set => workspacename = value; }
		public string Nome { get => nome; set => nome = value; }
		public string Email { get => email; set => email = value; }
		public string Senha { get => senha; set => senha = value; }
		public int Salt { get => salt; set => salt = value; }
	}
}