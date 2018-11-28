using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EYE.Model
{
    public class Processo
    {

        private int codProcesso;
        private string nomeProcesso;
        private string nomeAplicacao;


        public int CodProcesso { get => codProcesso; set => codProcesso = value; }
        public string NomeProcesso { get => nomeProcesso; set => nomeProcesso = value; }
        public string NomeAplicacao { get => nomeAplicacao; set => nomeAplicacao = value; }


        public static DropDownList AlimentarProcessos(DropDownList ddlProcesso, List<Processo> lista)
        {
            ddlProcesso.Items.Add(new ListItem("", null));
            foreach (Processo item in lista) {
                if (item.NomeAplicacao == null || item.NomeAplicacao.Equals(""))
                    ddlProcesso.Items.Add(new ListItem(item.NomeAplicacao, item.CodProcesso.ToString()));
                else
                    ddlProcesso.Items.Add(new ListItem(item.NomeProcesso, item.CodProcesso.ToString()));
            }
            return ddlProcesso;
        }
    }
}