using System;
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
        public String code { get; set; }
        public PaymentTermType PaymentTermType { get; set; }
        public SAPEnv Env { get; set; }
        public Boolean FixDate { get; set; }
        public double Days{ get; set; }
        public String Description { get; set; }
        public Boolean IsActive { get; set; }
    }
}
