using System;
using Dominio.Entidades.Localidade;

namespace Dominio.Entidades.Contrato
{
    public class Client : LocalidadeGeografica
    {
        public String Email { get; set; }
        public String UndoingEmail { get; set; }
        public String Ie { get; set; }
        public String Cnpj { get; set; }
        public String Operation { get; set; }
        public ClientGroup Operator { get; set; }

        public ClientType Type { get; set; }
        public Double CreditLimit { get; set; }
        public Double CreditDisp{ get; set; }
        public DateTime DataUltimaCompra { get; set; }
        public String Hierarchy1 { get; set; }
        public String Hierarchy2 { get; set; }
        public String Hierarchy3 { get; set; }
        public Boolean Blockade { get; set; }
        public String Rating { get; set; }
        public ClientGroup ClientGroup { get; set; }
        public Boolean Armazenagem { get; set; }
        public Boolean ScaProfile { get; set; }
    }
}