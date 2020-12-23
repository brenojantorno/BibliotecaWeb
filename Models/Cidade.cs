using System.ComponentModel.DataAnnotations.Schema;
using System;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class Cidade : IBaseId
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int IdUF { get; set; }

        public UF UF { get; set; }
    }
}