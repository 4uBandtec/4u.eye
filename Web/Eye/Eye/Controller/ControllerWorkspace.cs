using Eye.DAO;
using Eye.Model;

namespace Eye.Controller
{
    public class ControllerWorkspace
    {
        public static bool AutenticarWorkspace(string workspacename, string senha)
        {
            var salt = StatementWorkspace.BuscaSalt(workspacename);
            var senhaBanco = StatementWorkspace.BuscaSenhaHash(workspacename);

            if (salt == 0 || senhaBanco == null)
            {
                return false;
            }

            return ValidaSenha(senhaBanco, senha, salt);
        }
        public static bool Cadastrar(Workspace workspace)
        {
            workspace.Salt = ControllerCriptografia.GerarSalt();
            workspace.Senha = ControllerCriptografia.GerarSenhaHash(workspace.Senha, workspace.Salt);
            return StatementWorkspace.InserirWorkspace(workspace);
        }

        public static int GetCodigo(string workspacename)
        {
            return StatementWorkspace.BuscaCodigo(workspacename);
        }
        public static bool ValidaSenha(string senhaBanco, string senha, int salt)
        {
            return senhaBanco.Equals(ControllerCriptografia.GerarSenhaHash(senha, salt));
        }

        public static bool VerificaEmailUnico(string email)
        {
            return StatementWorkspace.VerificaEmailUnico(email);
        }

        public static bool VerificaWorkspacenameUnico(string workspacename)
        {
            return StatementWorkspace.VerificaWorkspacenameUnico(workspacename);
        }
    }
}