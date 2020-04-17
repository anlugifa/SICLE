using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Contrato
{
    public class ClientGroup
    {
        public long Id { get; set; }
        public String Code { get; set; }
        public ClientGroupType Type { get; set; }

        [MaxLength(40)]
        public String Description { get; set; }

        [EmailAddress]
        public String Email { get; set; }

        public ICollection<Client> Clientes { get; set; }
    }
}