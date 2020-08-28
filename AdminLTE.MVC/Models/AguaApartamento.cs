using AdminLTE.MVC.Areas.Identity.Pages.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminLTE.MVC.Models
{
    [Table("AguaApartamento")]
    public class AguaApartamento
    {
        public int AguaApartamentoId { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        //public DateTime dt_leitura_ant { get; set; }
        public DateTime dt_leitura_atual { get; set; }

        //public double re_leitura_ant { get; set; }
        public double re_leitura_atual { get; set; }

        public long re_valor_atual { get; set; }


        public string FotoPath { get; set; }

        [Display(Name = "Apartamento")]
        public int ApartamentoId { get; set; }
        public virtual Apartamento Apartamento { get; set; }

       /// public virtual List<LoginModel> AspNetUsers { get; set; }
    }
}
