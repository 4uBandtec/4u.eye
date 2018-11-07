using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eye.DAO;
using Eye.Model;


namespace Eye.Controller
{
    public class ControllerComputador
    {
        public static int ContarComputadorUsuario(int codUsuario){
            return StatementComputador.ContaComputador(codUsuario);
        }
        public static Monitor[] ListarComputadoresUsuario(int codUsuario)
        {
            return StatementComputador.ListarComputadores(codUsuario);
        }
    }
}