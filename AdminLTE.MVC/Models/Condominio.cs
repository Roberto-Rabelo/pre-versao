using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminLTE.MVC.Models
{
    [Table("Condominio")]
    public class Condominio
    {
        //public int CategoriaId { get; set; }
        
        //public string CategoriaNome { get; set; }

        //[Required]
        //[StringLength(200)]
        //public string Descricao { get; set; }
        //public virtual List<Lanche> Lanches { get; set; }

        public int CondominioId { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string FotoPath { get; set; }

        public virtual List<Apartamento> Apartamentos { get; set; }

        public virtual List<AguaCondominio> AguaCondominios { get; set; }
    }
}
