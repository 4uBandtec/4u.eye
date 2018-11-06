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

            if(salt == 0 || senhaBanco == null)
            {
                return false;
            }

            return ValidaSenha(senhaBanco, senha, salt);
        }
        public bool Cadastrar(Workspace workspace)
        {
            workspace.Salt = new ControllerCriptografia().GerarSalt();
            workspace.Senha = new ControllerCriptografia().GerarSenhaHash(workspace.Senha, workspace.Salt);
            return new StatementWorkspace().InserirWorkspace(workspace);
        }

        public int GetCodigo(string workspacename)
        {
            return new StatementWorkspace().BuscaCodigo(workspacename);
        }
        public bool ValidaSenha(string senhaBanco, string senha, int salt)
        {
            return senhaBanco.Equals(new ControllerCriptografia().GerarSenhaHash(senha, salt));
        }

        public bool VerificaEmailUnico(string email)
        {
            return new StatementWorkspace().VerificaEmailUnico(email);
        }

        public bool VerificaWorkspacenameUnico(string workspacename)
        {
            return new StatementWorkspace().VerificaWorkspacenameUnico(workspacename);
        }
    }
}