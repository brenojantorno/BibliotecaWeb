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
        public Endereco Endereco { get; set; }

        public int? IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}