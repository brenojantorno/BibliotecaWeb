namespace BibliotecaWeb.Models
{
    public class Sessao
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
    }
}