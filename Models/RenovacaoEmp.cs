using System;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class RenovacaoEmp : IBaseId
    {
        public int Id { get; set; }

        public DateTime DataDevolucao { get; set; }

        public int IdEmprestimo { get; set; }

        public Emprestimo Emprestimo { get; set; }

    }
}