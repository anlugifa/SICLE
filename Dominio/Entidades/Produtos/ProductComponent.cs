using System;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Localidade;

namespace Dominio.Entidades.Produtos
{
    public class ProductComponent
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int ComponentId { get; set; }
        public Product Component { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        public AACLType CodAACL { get; set; }
        public String Bom { get; set; }
        public String BomAL { get; set; }

        public double Quantity { get; set; }
    }
}
