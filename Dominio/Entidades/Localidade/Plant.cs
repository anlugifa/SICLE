using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Localidades
{
    public abstract class Plant : LocalidadeGeografica
    {
        public String IE {get; set;} = null!;
        public String CNPJ { get; set; } = null!;
        public String Operation { get; set; } = null!;
        
        public Double FixedCost { get; set; }
        public Double FixedCostZero { get; set; }
        public String NickName { get; set; } = null!;
        public String ShortName { get; set; } = null!;
        public String Initials { get; set; } = null!;
        public String DefaultObservation { get; set; } = null!;

        public Double HSun { get; set; }
        public Double HMon { get; set; }
        public Double HTue { get; set; }
        public Double HWed { get; set; }
        public Double HThu { get; set; }
        public Double HFri { get; set; }
        public Double HSat { get; set; }

        public Double LogistcPrize { get; set; }
        public Boolean IsCosan { get; set; }
        public String Ovmi { get; set; } = null!;
        public String Ovme { get; set; } = null!;

        public String Enterprise { get; set; } = null!;

        public Boolean IsLiter { get; set; }

        [EmailAddress]
        public String Email { get; set; } = null!;

        public Double Diflog { get; set; }

        public Boolean IsPossibleOriginationDestinations{ get; set; }
        public Boolean IsPisCofinsNotApplied { get; set; }

        public int ImportCompanyId { get; set; }
    	public Company ImportCompany { get; set; } = null!;

        public long OperatorId { get; set; }
        public ClientGroup Operator { get; set; } = null!;

        public ICollection<RestricaoCargaDescarga> LoadUnloadRestriction { get; set; }  = null!;
	    public ICollection<ProductInPlant> ProductInLocation { get; set; } = null!;
    }
}
