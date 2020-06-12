using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sicle.Web.Models;
using Sicle.Web.Util;
using Util;
using Dominio.Entidades.Produtos;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class EditContratoVendaVM
    {
        public long ContratoVendaId { get; set; }
        public long ContratoMestreId { get; set; }
        public ContratoVenda Contrato { get; set; }


        public IEnumerable<ProductGroup> ProductGroups { get; set; }
        public IEnumerable<SaleContractQuota> Quotas { get; set; }

        public EditContratoVendaVM(ContratoVenda contrato)
        {
            this.Contrato = contrato;
            this.ContratoVendaId = contrato.Id;
            this.ContratoMestreId = contrato.ContratoMestreId ?? 0;
        }
    }
}
