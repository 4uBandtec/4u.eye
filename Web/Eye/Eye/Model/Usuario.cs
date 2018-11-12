using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EYE.Model
{
    public class Usuario
    {
        public int CodUsuario { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int Salt { get; set; }
        public string CodWorkspace { get; set; }

        public Computador[] ComputadoresUsuario { get; set; }
    }
}