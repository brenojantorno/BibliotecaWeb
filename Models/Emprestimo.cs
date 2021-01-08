using System.Collections.Generic;
using System;
using BibliotecaWeb.Data;
using BibliotecaWeb.Models.Enums;
using BibliotecaWeb.Models.Extends;

namespace BibliotecaWeb.Models
{
    public class Emprestimo : IBaseId
    {
        public int Id { get; set; }
        public DateTime DataDevolucao { get; set; }
        public TSituacaoEmprestimo Situacao { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int IdLivro { get; set; }
        public virtual Livro Livro { get; set; }
        public int IdPessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<RenovacaoEmp> RenovacoesEmp { get; set; }
    }
}