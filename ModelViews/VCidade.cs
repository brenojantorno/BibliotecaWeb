using BibliotecaWeb.Models;
using BibliotecaWeb.Data;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaWeb.ModelsViews
{
    public class VCidade
    {
        public int? id { get; set; }
        [Required(ErrorMessage = "Um nome é necessário")]
        public string nome { get; set; }
        [Required(ErrorMessage = "UF necessário")]
        public int idUF { get; set; }

        public static Cidade LoadObject(BibliotecaDataContext _repository, VCidade modelView)
        {
            var obj = _repository.Cidade.Find(modelView.id);
            if (obj == null)
                obj = new Cidade();

            obj.Nome = modelView.nome;
            obj.IdUF = modelView.idUF;

            return obj;
        }
    }
}