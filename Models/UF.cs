using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class UF : IBaseId
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Sigla { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}

