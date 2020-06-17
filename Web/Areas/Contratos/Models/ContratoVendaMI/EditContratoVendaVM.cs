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
        public SaleContract Contrato { get; set; }

        public IEnumerable<ProductGroup> ProductGroups { get; set; }

        public EditContratoVendaVM()
        {
        }

        public EditContratoVendaVM(SaleContract contrato)
        {
            this.Contrato = contrato;            
        }
    }
}
