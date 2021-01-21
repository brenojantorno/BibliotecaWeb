namespace BibliotecaWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }

    }
}