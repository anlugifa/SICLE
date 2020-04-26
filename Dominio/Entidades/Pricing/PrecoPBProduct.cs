using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Pricing
{
    public class PrecoPBProduct
    {
        public long Id { get; set; }

        public String Product { get; set; }

        public String Address { get; set; }

        public DateTime Data { get; set; }

        public Boolean HaveToImport { get; set; }
    }  
}