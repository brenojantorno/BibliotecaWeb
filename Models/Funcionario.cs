using System.Collections.Generic;
using System;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class Funcionario : IBaseId
    {
        public int Id { get; set; }
        public double Salario { get; set; }
        public int NumeroCTPS { get; set; }
        public virtual DateTime DataAdmissao { get; set; }
        public int CargaHoraria { get; set; }
        public int IdCargo { get; set; }
        public virtual Cargo Cargo { get; set; }
        public int IdPessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}

