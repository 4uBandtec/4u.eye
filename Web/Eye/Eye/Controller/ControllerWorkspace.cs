using Eye.DAO;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Eye.Controller
{
    public class ControllerWorkspace
    {
        public bool AutenticaWorkspace(string workspacename, string senha)
        {
            var statementWorkspace = new StatementWorkspace();
            var salt = statementWorkspace.BuscaSalt(workspacename);
            var senhaBanco = statementWorkspace.BuscaSenhaHash(workspacename);
            return ValidaSenha(senhaBanco, senha, salt);
        }
        public string GerarSenhaHash(string senha, int salt)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes($"{senha}{salt}"));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public int GerarSalt()
        {
            return new Random().Next();
        }
        public int GetCodigo(string workspacename)
        {
            return new StatementWorkspace().BuscaCodigo(workspacename);
        }
        public bool ValidaSenha(string senhaBanco, string senha, int salt)
        {
            return senhaBanco.Equals(GerarSenhaHash(senha, salt));
        }
    }
}