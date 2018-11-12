using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EYE.Model.DAO;
using EYE.Model;

namespace EYE.Controller
{
    public class ControllerComputador
    {
        public int ContarComputadorUsuario(int codUsuario)
        {
            return StatementComputador.ContaComputador(codUsuario);
        }
        public Computador[] ListarComputadoresUsuario(int codUsuario)
        {
            return StatementComputador.ListarComputadores(codUsuario);
        }
    }
}