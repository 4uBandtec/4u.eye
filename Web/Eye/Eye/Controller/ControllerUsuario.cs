using Eye.DAO;
using Eye.Model;

namespace Eye.Controller
{
    public class ControllerUsuario
    {

        public bool Cadastrar(Usuario usuario)
        {
            var statementUsuario = new StatementUsuario();
            if (!statementUsuario.VerificaUsernameUnico(usuario.Username))
            {
                return false;
            }
            if (!statementUsuario.VerificaEmailUnico(usuario.Email))
            {
                return false;
            }
            usuario.Salt = new ControllerCriptografia().GerarSalt();
            usuario.Senha = new ControllerCriptografia().GerarSenhaHash(usuario.Senha, usuario.Salt);
            return statementUsuario.InserirUsuario(usuario);
        }
        public bool VerificaEmailUnico(string email)
        {
            return new StatementUsuario().VerificaEmailUnico(email);
        }

        public bool VerificaUsernameUnico(string username)
        {
            return new StatementUsuario().VerificaUsernameUnico(username);
        }
    }
}