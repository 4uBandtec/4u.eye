using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EYE.Model
{
    public class Criptografia
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