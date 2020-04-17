using System;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Localidade;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    public enum PaymentTermType
    {
        C, //purchase
        V, //sale
        E //external
    }

    ///
    // Mapeado no Sicle como SaleContract
    ///
    public class PaymentTerm
    {
        public long Id { get; set; }
        public String Code { get; set; }
        public PaymentTermType PaymentTermType { get; set; }
        public SAPEnvType Env { get; set; }        
        public double Days{ get; set; }

        [MaxLength(100)]
        public String Description { get; set; }
        public Boolean IsFixDate { get; set; }
        public Boolean IsActive { get; set; }
    }
}