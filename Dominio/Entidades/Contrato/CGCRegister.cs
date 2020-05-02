using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    public class CGCRegister
    {
        public int Id { get; set; }
        public String CGC { get; set; } = null!;
        public Boolean IsActive { get; set; }

        public CGCType Type { get; set; }
                
        public int? ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public long? ClientGroupId { get; set; }
        public ClientGroup ClientGroup { get; set; } = null!;


    }
}