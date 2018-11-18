namespace EYE.Model
{
	public partial class Perfil
	{
		private int jogo;
		private int trabalho;
		private int social;
		private int outros;

		public int Jogo { get => jogo; set => jogo = value; }
		public int Trabalho { get => trabalho; set => trabalho = value; }
		public int Social { get => social; set => social = value; }
		public int Outros { get => outros; set => outros = value; }
		public TiposDePerfil CalculaPerfilUsuario(Perfil perfil)
		{
			var maior = 0;
			var tipoPerfil = TiposDePerfil.Indefinido;
			if (perfil.Jogo > maior)
			{
				maior = perfil.Jogo;
				tipoPerfil = TiposDePerfil.Jogo;
			}
			if (perfil.Trabalho > maior)
			{
				maior = perfil.Trabalho;
				tipoPerfil = TiposDePerfil.Trabalho;
			}
			if (perfil.Social > maior)
			{
				maior = perfil.Social;
				tipoPerfil = TiposDePerfil.Social;
			}
			if (perfil.Outros > maior)
			{
				maior = perfil.Outros;
				tipoPerfil = TiposDePerfil.Outros;
			}
			return tipoPerfil;
		}
	}

}