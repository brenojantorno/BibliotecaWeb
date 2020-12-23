using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class Cargo : IBaseId
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}