using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminLTE.MVC.Models
{
    [Table("AguaCondominio")]
    public class AguaCondominio
    {
        public int AguaCondominioId { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        

        //public DateTime dt_leitura_ant { get; set; }
        public DateTime dt_leitura_atual { get; set; }

        //public double re_leitura_ant { get; set; }
        public double re_leitura_atual { get; set; }

        public long re_valor_atual { get; set; }

        public string FotoPath { get; set; }

        [Display(Name = "Condominio")]
        public int CondominioId { get; set; }
        public virtual Condominio Condominio { get; set; }
    }
}
