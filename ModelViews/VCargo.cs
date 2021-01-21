using BibliotecaWeb.Models;
using BibliotecaWeb.Data;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaWeb.ModelsViews
{
    public class VCargo
    {
        public int? id { get; set; }
        [Required(ErrorMessage = "Um nome é necessário")]
        public string nome { get; set; }

        public static Cargo LoadObject(BibliotecaDataContext _repository, VCargo modelView)
        {
            var obj = _repository.Cargo.Find(modelView.id);
            if (obj == null)
                obj = new Cargo();

            obj.Nome = modelView.nome;
            return obj;
        }
    }
}