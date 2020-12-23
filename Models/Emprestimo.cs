using System.Collections.Generic;
using System;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class Emprestimo : IBaseId
    {
        public int Id { get; set; }

        public DateTime DataDevolucao { get; set; }

        public string Situacao { get; set; }
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

        public int IdLivro { get; set; }
        public Livro Livro { get; set; }

        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }

        public ICollection<RenovacaoEmp> RenovacoesEmp { get; set; }
        public Emprestimo()
        {
            RenovacoesEmp = new List<RenovacaoEmp>();
        }
    }
}