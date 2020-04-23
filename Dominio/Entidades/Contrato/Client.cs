using System;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Localidades;

namespace Dominio.Entidades.Contrato
{
    public class Client : LocalidadeGeografica
    {
        [EmailAddress]
        public String Email { get; set; }
        public String UndoingEmail { get; set; }
        public String IE { get; set; }
        public String CNPJ { get; set; }
        public String Operation { get; set; }
        
        public ClientType? Type { get; set; }
        public Double? CreditLimit { get; set; }
        public Double? CreditDisp{ get; set; }
        public DateTime? DataUltimaCompra { get; set; }
        public String Hierarchy1 { get; set; }
        public String Hierarchy2 { get; set; }
        public String Hierarchy3 { get; set; }
        
        public String Rating { get; set; }
        
        public Boolean IsBlockade { get; set; }
        public Boolean IsArmazenagem { get; set; }
        public Boolean IsScaProfile { get; set; }

        public long? ClientGroupId { get; set; }
        public virtual ClientGroup ClientGroup { get; set; }

        public long? OperatorId { get; set; }
        public ClientGroup Operator { get; set; }

        public Client()
        {
            this.Tipo = TipoLocalidade.C;
        }

    }
}