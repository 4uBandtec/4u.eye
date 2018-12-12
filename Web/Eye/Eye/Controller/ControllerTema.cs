using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EYE.Model.DAO;

namespace EYE.Controller
{
    public class ControllerTema
    {
        public static int BuscaTema(int codWorkspace)
        {
            return StatementTema.BuscaTema(codWorkspace);
        }

        public static bool TrocaTema(int codWorkspace, int novoTema)
        {
            return StatementTema.TrocarTema(codWorkspace, novoTema);
        }
    }
}