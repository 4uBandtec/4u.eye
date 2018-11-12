namespace EYE.Model
{
    public class Computador
    {
        private int codComputador;
        private string user;
        private int perfil;
        private string nomeComputador;
        private decimal hdTotal;
        private decimal ramTotal;
        private string sistemaOperacional;
        private string versaoSistema;
        private int versaoBits;
        private string processador;
        private int codUsuario;


        public int CodComputador
        {
            get
            {
                return codComputador;
            }
            set
            {
                codComputador = value;
            }
        }

        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        public int Perfil
        {
            get
            {
                return perfil;
            }
            set
            {
                perfil = value;
            }
        }

        public string NomeComputador
        {
            get
            {
                return nomeComputador;
            }
            set
            {
                nomeComputador = value;
            }
        }

        public decimal HDTotal
        {
            get
            {
                return hdTotal;
            }
            set
            {
                hdTotal = value;
            }
        }

        public decimal RAMTotal
        {
            get
            {
                return ramTotal;
            }
            set
            {
                ramTotal = value;
            }
        }

        public string SistemaOperacional
        {
            get
            {
                return sistemaOperacional;
            }
            set
            {
                sistemaOperacional = value;
            }
        }

        public string VersaoSistema
        {
            get
            {
                return versaoSistema;
            }
            set
            {
                versaoSistema = value;
            }
        }

        public int VersaoBits
        {
            get
            {
                return versaoBits;
            }
            set
            {
                versaoBits = value;
            }
        }

        public string Processador
        {
            get
            {
                return processador;
            }
            set
            {
                processador = value;
            }
        }

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
    }
}