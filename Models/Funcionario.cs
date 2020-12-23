using System.Collections.Generic;
using System;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class Funcionario : IBaseId
    {
        public int Id { get; set; }
        public decimal Salario { get; set; }
        public int NumeroCTPS { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int CargaHoraria { get; set; }
        public int IdCargo { get; set; }
        public Cargo Cargo { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}

