using System.Web.UI.WebControls;

namespace Eye.Model
{
    public class Valida
    {
        public static void StringVazia(params TextBox[] campos)
        {
            foreach (var campo in campos)
            {
                if (campo == null || string.IsNullOrWhiteSpace(campo.Text))
                {
                    campo.Focus();
                    return;
                }
            }
        }
        public static void DropDownListVazia(params DropDownList[] listas)
        {
            foreach (var lista in listas)
            {
                if (lista.SelectedValue.Equals(""))
                {
                    lista.Focus();
                    return;
                }
            }
        }
        public static void Numero(params TextBox[] campos)
        {
            foreach (var campo in campos)
            {
                if (int.TryParse(campo.Text, out var numero) == false)
                {
                    campo.Focus();
                    return;
                }
            }
        }
        public static void Email(params TextBox[] campos)
        {
            foreach (var campo in campos)
            {
                var email = campo.Text.Trim();
                var arroba = email.IndexOf('@');
                var arroba2 = email.LastIndexOf('@');
                var ponto = email.LastIndexOf('.');
                if (arroba <= 0 || ponto <= (arroba + 1) || ponto == (email.Length - 1) || arroba2 != arroba)
                {
                    campo.Focus();
                    return;
                }
            }
        }
        public static void SenhasIguais(TextBox senha, TextBox confirmaSenha)
        {
            senha.Text.Equals(confirmaSenha.Text);
         }
    }
}