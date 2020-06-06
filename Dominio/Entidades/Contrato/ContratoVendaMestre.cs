using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Acesso;

namespace Dominio.Entidades.Contrato
{
    public class ContratoVendaMestre
    {
        public long Id {get; set;}

        //Utilizado em heranças pelo Sicle antigo.
        public String Discriminator {get; set;} = "MasterSaleContract";
        
        public String Nickname {get; set;} = null!;        
        public String Observation {get; set;} = null!;

        public Boolean IsActive {get; set;}
        
        public DateTime CreationDate {get; set;}

        public long CreationUserId {get; set;}
        public Usuario CreationUser {get; set;} = null!;
        
        public ICollection<ContratoVenda> Contratos {get; set;} = null!;

        public override string ToString()
        {
            return "RM-" + Id;
        }
    }
}
