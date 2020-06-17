using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Contrato
{
    public class ClientGroup
    {
        public long Id { get; set; }
        public String Code { get; set; } = null!;
        public ClientGroupType Type { get; set; }

        [MaxLength(40)]
        public String Description { get; set; } = null!;

        [EmailAddress]
        public String Email { get; set; } = null!;

        public ICollection<Client> Clientes { get; set; } = null!;

        public override String ToString()
        {
            String first = Description.Substring(0, 1);
            if (first.Equals("B")) 
            {
                return Description.Substring(1, Description.Length-1);			
            }

            return Description;
	    }
    }
}