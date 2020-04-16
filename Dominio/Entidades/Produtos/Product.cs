using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades
{
    public class Product
    {
        [Required]
        public long Id { get; set; }
        public String Code { get; set; }
        public String CodeCL { get; set; }
        public String CodeH1 { get; set; }
        public String CodeH2 { get; set; }
        public String CodeH3 { get; set; }
        public String DescriptionH1 { get; set; }
        public String DescriptionH2 { get; set; }
        public String DescriptionH3 { get; set; }
        public String Description { get; set; }
        public double ProductionPrize { get; set; }

        public Boolean IsReference { get; set; }
        public Boolean IsImported { get; set; }
        public Boolean IsScaProfile { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsAnidroCorante { get; set; }

        public int SpecialUnitId { get; set; }
        public SpecialUnit SpecialUnit { get; set; }

        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup  { get; set; }

        public ProductPurpose Purpose { get; set; }        
        public ProductEsalqType ProductEsalqType { get; set; }
        public PurchaseSaleType PurchaseSaleType { get; set; }
        

        public ICollection<ProductComponent> Components { get; set; }
    }
}
