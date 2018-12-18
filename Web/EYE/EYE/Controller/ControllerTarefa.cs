using EYE.Model;
using EYE.Model.DAO;
using EYE.Model.Enum;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace EYE.Controller
{
    public class ControllerTarefa
    {
        public bool Cadastrar(string txtNome, string txtDescricao, string txtDataInicio, string txtDataFim, int codWorkspace, string lblMensagem, List<string> listaCodUsersTarefa, List<string> listaProcTarefa, List<string> listaTempoTarefa, bool notificacaoEquipe, bool notificacaoUsuarios)
        {
            if (!Validacao.StringVazia(txtNome, txtDescricao, txtDataInicio, txtDataFim))
            {
                return false;
            }
            var codTarefa = CadastrarTarefa(txtNome, txtDescricao, txtDataInicio, txtDataFim, codWorkspace, lblMensagem);
            var lista = ProcessoTarefa.ConstruirLista(listaCodUsersTarefa, listaProcTarefa, listaTempoTarefa);
            lista = StatementProcesso.GetNomeUsuario(lista);
            if (StatementTarefa.CadastrarProcessos(lista, codTarefa))
            {
                ControllerNotificacao.CadastrarNotificacaoTarefa(lista, codWorkspace, notificacaoEquipe, notificacaoUsuarios);
                return true;
            }

            return false;
        }

        private static int CadastrarTarefa(string txtNome, string txtDescricao, string txtDataInicio, string txtDataFim, int codWorkspace, string lblMensagem)
        {
            var tarefa = new Tarefa
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                DataInicio = txtDataInicio,
                DataFim = txtDataFim,
                CodAndamento = Andamento.NaoIniciada,
                StatusVida = StatusVida.Ativo,
                CodWorkspace = codWorkspace
            };

            var codTarefa = StatementTarefa.InserirTarefa(tarefa);

            if (codTarefa > 0)
            {
                lblMensagem = "A nova tarefa ja foi cadastrada, coloque os funcinarios pra trabalhar";
                txtNome = "";
                txtDescricao = "";
                txtDataInicio = "";
                txtDataFim = "";
            }
            else
            {
                lblMensagem = "Ops, deu algo errado, acho que a culpa é nossa";
            }
            return codTarefa;
        }

        public Panel CarregarPainel(int codWorkspace)
        {
            var listaUsuarios = StatementUsuario.ListarUsuarios(codWorkspace);
            var ddlUsuarios = Usuario.AlimentarUsuarios(new DropDownList(), listaUsuarios);
            var listaProcessos = StatementProcesso.ListarProcessos();
            var ddlProcesso = Processo.AlimentarProcessos(new DropDownList(), listaProcessos);
            return new Tarefa().ConstruirConteudo(ddlUsuarios, ddlProcesso);


        }
        public List<Tarefa> ListarTarefas(int codWorkspace)
        {
            var lista = StatementTarefa.ListarTarefas(codWorkspace);
            lista = StatementTarefa.AdicionaProcessos(lista);
            lista = StatementTarefa.AdicionaNomeUsuario(lista);
            lista = StatementTarefa.AdicionaNomeProcesso(lista);
            lista = Tarefa.CalculaPorcentagem(lista);
            return lista;
        }

        public static bool ClassificarProcesso(string codProcesso, string ddlPerfil)
        {
            return StatementPerfil.UpdatePerfilProcesso(codProcesso, int.Parse(ddlPerfil));
        }

        public static Processo BuscaProcessoSemPerfil(int codWorkspace)
        {
            return StatementPerfil.BuscaProcessoSemPerfil(codWorkspace);
        }

        public static DropDownList CarregaDropDownListPerfil(DropDownList ddlPerfil)
        {
            return StatementPerfil.AlimentaDropDownListPerfil(ddlPerfil);
        }
    }
}