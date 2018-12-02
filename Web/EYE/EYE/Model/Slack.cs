namespace EYE.Model
{
    public class Slack
    {
        private string url;
        private string nome;
        private string canal;
        private int codWorkspace;

        public string Url { get => url; set => url = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Canal { get => canal; set => canal = value; }
        public int CodWorkspace { get => codWorkspace; set => codWorkspace = value; }
    }
}