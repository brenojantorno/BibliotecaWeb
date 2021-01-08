using System.ComponentModel.DataAnnotations;
using System;
namespace BibliotecaWeb.Models.Enums
{
    public enum TSituacaoEmprestimo
    {
        [Display(Name = "Finalizado")]
        Finalizado = 'F',
        [Display(Name = "Vencido")]
        Vencido = 'V',
        [Display(Name = "Em Andamento")]
        EmAndamento = 'E'
    }
}