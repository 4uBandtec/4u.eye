using System;
using System.Security.Cryptography;
using System.Text;

namespace Eye.Controller
{
    public class ControllerCriptografia
    {
        public static string GerarSenhaHash(string senha, int salt)
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

        public static int GerarSalt()
        {
            return new Random().Next();
        }
    }
}