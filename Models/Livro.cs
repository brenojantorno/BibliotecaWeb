using System.Collections.Generic;
using System;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class Livro : IBaseId
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Editora { get; set; }
        public string NomeAutor { get; set; }
        public int Ano { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public int QtdCopias { get; set; }
        public string CodigoNacional { get; set; }
        public string CodigoInternacional { get; set; }
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}