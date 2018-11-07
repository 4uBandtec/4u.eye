using Eye.DAO;
using Eye.Model;

namespace Eye.Controller
{
    public class ControllerUsuario
    {

        public static bool Cadastrar(Usuario usuario)
        {
            usuario.Salt = ControllerCriptografia.GerarSalt();
            usuario.Senha = ControllerCriptografia.GerarSenhaHash(usuario.Senha, usuario.Salt);
            return StatementUsuario.InserirUsuario(usuario);
        }
        public static bool VerificaEmailUnico(string email)
        {
            return StatementUsuario.VerificaEmailUnico(email);
        }

        public static bool VerificaUsernameUnico(string username)
        {
            return StatementUsuario.VerificaUsernameUnico(username);
        }

        public static int ContaUsuarioWorkspace(int codWorkspace)
        {
            return StatementUsuario.ContaUsuario(codWorkspace);
        }

        public static Usuario[] ListarUsuarios(int codWorkspace)
        {
            return StatementUsuario.ListarUsuarios(codWorkspace);
        }
    }
}