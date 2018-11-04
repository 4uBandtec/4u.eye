using Eye.DAO;
using Eye.Model;

namespace Eye.Controller
{
    public class ControllerWorkspace
    {
        public bool AutenticarWorkspace(string workspacename, string senha)
        {
            var statementWorkspace = new StatementWorkspace();
            var salt = statementWorkspace.BuscaSalt(workspacename);
            var senhaBanco = statementWorkspace.BuscaSenhaHash(workspacename);
            return ValidaSenha(senhaBanco, senha, salt);
        }
        public bool Cadastrar(Workspace workspace)
        {
            var statementWorkspace = new StatementWorkspace();
            statementWorkspace.VerificaWorkspacenameUnico(workspace.Workspacename);
            statementWorkspace.VerificaEmailUnico(workspace.Email);
            workspace.Salt = new ControllerCriptografia().GerarSalt();
            workspace.Senha = new ControllerCriptografia().GerarSenhaHash(workspace.Senha, workspace.Salt);
            return statementWorkspace.InserirWorkspace(workspace);
        }

        public int GetCodigo(string workspacename)
        {
            return new StatementWorkspace().BuscaCodigo(workspacename);
        }
        public bool ValidaSenha(string senhaBanco, string senha, int salt)
        {
            return senhaBanco.Equals(new ControllerCriptografia().GerarSenhaHash(senha, salt));
        }
    }
}