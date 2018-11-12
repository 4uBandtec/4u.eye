
namespace EYE.Model
{
    public class Usuario
    {
        private int codUsuario;
        private string username;
        private string nome;
        private string email;
        private string senha;
        private string dataNascimento;
        private string sexo;
        private int salt;
        private string codWorkspace;

        private Computador[] computadoresUsuario;


        public int CodUsuario
        {
            get
            {
                return codUsuario;
            }
            set
            {
                codUsuario = value;
            }
        }


        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }
            set
            {
                senha = value;
            }
        }

        public string DataNascimento
        {
            get
            {
                return dataNascimento;
            }
            set
            {
                dataNascimento = value;
            }
        }

        public string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        public int Salt
        {
            get
            {
                return salt;
            }
            set
            {
                salt = value;
            }
        }

        public string CodWorkspace
        {
            get
            {
                return codWorkspace;
            }
            set
            {
                codWorkspace = value;
            }
        }


        public Computador[] ComputadoresUsuario
        {
            get
            {
                return computadoresUsuario;
            }
            set
            {
                computadoresUsuario = value;
            }
        }
    }
}