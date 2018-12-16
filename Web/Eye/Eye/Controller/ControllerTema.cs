using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EYE.Model.DAO;

namespace EYE.Controller
{
    public class ControllerTema
    {
        public static int BuscaModo(int codWorkspace)
        {
            return StatementTema.BuscaModo(codWorkspace);
        }
        
        public static int BuscaTema(int codWorkspace)
        {
            return StatementTema.BuscaTema(codWorkspace);
        }


        public static bool TrocaModo(int codWorkspace, int novoModo)
        {
            return StatementTema.TrocarModo(codWorkspace, novoModo);
        }

        public static bool TrocaTema(int codWorkspace, int novoTema)
        {
            return StatementTema.TrocarTema(codWorkspace, novoTema);
        }


        public static int BuscaIntensidade(int codWorkspace)
        {
            return StatementTema.BuscaIntensidade(codWorkspace);
        }

        public static bool TrocaIntensidade(int codWorkspace, int novaIntensidade)
        {
            return StatementTema.TrocarIntensidade(codWorkspace, novaIntensidade);
        }
    }
}