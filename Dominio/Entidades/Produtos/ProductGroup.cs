using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Produtos
{
    public class ProductGroup
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(20)]
        public String Code{ get; set; }

         [MaxLength(200)]
        public String Description{ get; set; }
        public String EnglishDescription{ get; set; }
        public ProductEsalqType EsalqType{ get; set; }
        public Double? ProductPremium{ get; set; }

        public ICollection<Product> Products {get; set;}
    }
}
