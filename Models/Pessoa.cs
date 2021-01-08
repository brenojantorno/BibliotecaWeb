using System.Collections.Generic;
using System;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class Pessoa : IBaseId
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string NumeroRg { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}