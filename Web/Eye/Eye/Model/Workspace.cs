using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EYE.Model
{
    public class Workspace
    {

        public int CodWorkspace { get; set; }
        public string Workspacename { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Salt { get; set; }

        
        
    }
}