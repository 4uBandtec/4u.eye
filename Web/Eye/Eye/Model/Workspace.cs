

namespace EYE.Model
{
    public class Workspace
    {

        private int codWorkspace;
        private string workspacename;
        private string nome;
        private string email;
        private string senha;
        private int salt;

        public int CodWorkspace
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

        public string Workspacename
        {
            get
            {
                return workspacename;
            }
            set
            {
                workspacename = value;
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
    }
}