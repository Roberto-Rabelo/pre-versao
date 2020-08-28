using AdminLTE.MVC.Areas.Identity.Pages.Account;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminLTE.MVC.Models
{
    [Table("Apartamento")]
    public class Apartamento
    {
        public int ApartamentoId { get; set; }

        [Required]
        [Display(Name = "Nome do hóspede")]

        public string Nome { get; set; }

        [Required]
        [Display(Name = "Numero do apt")]
        public int apartamento { get; set; }

        [Required]
        [Display(Name = "Bloco do apt")]
        public string Bloco { get; set; }

       // public string IdAspNetUsers { get; set; }

        [Display(Name = "Condominio")]
        public int CondominioId { get; set; }
        public virtual Condominio Condominio { get; set; }

       // public virtual List<LoginModel> AspNetUsers { get; set; }
        public virtual List<AguaApartamento> AguaApartamento
        {
            get; set;
        }
    }
}
