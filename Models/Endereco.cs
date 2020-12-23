using System.Collections.Generic;
using System;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.Models
{
    public class Endereco : IBaseId
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Complemento { get; set; }
        public int Bairro { get; set; }
        public string Cep { get; set; }
        public int IdCidade { get; set; }
        public Cidade Cidade { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; }
    }
}
