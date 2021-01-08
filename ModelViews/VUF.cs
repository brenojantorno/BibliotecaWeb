using System.Xml.Schema;
using BibliotecaWeb.Models;
using BibliotecaWeb.Data;

namespace BibliotecaWeb.ModelsViews
{
    public class VUF
    {
        public int? Id { get; set; }

        public string nome { get; set; }
        public string sigla { get; set; }

        public static UF InitializeObject(IRepository<UF> _repository, VUF modelView)
        {
            var obj = _repository.Load(modelView.Id);
            if (obj == null)
                obj = new UF();

            obj.Nome = modelView.nome;
            obj.Sigla = modelView.sigla;

            return obj;
        }
    }
}