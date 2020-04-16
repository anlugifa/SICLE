using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Contrato;

namespace Dominio.Entidades.Localidade
{
    public abstract class Plant : LocalidadeGeografica
    {
        public String IE {get; set;}
        public String CNPJ { get; set; }
        public String Operation { get; set; }
        
        public Double FixedCost { get; set; }
        public Double FixedCostZero { get; set; }
        public String NickName { get; set; }
        public String ShortName { get; set; }
        public String Initials { get; set; }
        public String DefaultObservation { get; set; }

        public Double HSun { get; set; }
        public Double HMon { get; set; }
        public Double HTue { get; set; }
        public Double HWed { get; set; }
        public Double HThu { get; set; }
        public Double HFri { get; set; }
        public Double HSat { get; set; }

        public Double LogistcPrize { get; set; }
        public Boolean IsCosan { get; set; }
        public String Ovmi { get; set; }
        public String Ovme { get; set; }

        public String Enterprise { get; set; }

        public Boolean IsLiter { get; set; }

        [EmailAddress]
        public String Email { get; set; }

        public Double Diflog { get; set; }

        public Boolean PossibleOriginationDestinations{ get; set; }
        public Boolean PisCofinsNotApplied { get; set; }

    	public Company ImportCompany { get; set; }

        public ClientGroup Operator { get; set; }

        public ICollection<RestricaoCargaDescarga> LoadUnloadRestriction { get; set; }
        
	    public ICollection<ProductInPlant> ProductInLocation { get; set; }
    }
}
