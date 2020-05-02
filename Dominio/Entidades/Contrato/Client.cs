using System;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Localidades;

namespace Dominio.Entidades.Contrato
{
    public class Client : LocalidadeGeografica
    {
        [EmailAddress]
        public String Email { get; set; } = null!;
        public String UndoingEmail { get; set; } = null!;
        public String IE { get; set; } = null!;
        public String CNPJ { get; set; } = null!;
        public String Operation { get; set; } = null!;
        
        public ClientType? Type { get; set; } = null!;
        public Double? CreditLimit { get; set; } = null!;
        public Double? CreditDisp{ get; set; } = null!;
        public DateTime? DataUltimaCompra { get; set; } = null!;
        public String Hierarchy1 { get; set; } = null!;
        public String Hierarchy2 { get; set; } = null!;
        public String Hierarchy3 { get; set; } = null!;
        
        public String Rating { get; set; } = null!;
        
        public Boolean IsBlockade { get; set; }
        public Boolean IsArmazenagem { get; set; }
        public Boolean IsScaProfile { get; set; }

        public long? ClientGroupId { get; set; }
        public virtual ClientGroup ClientGroup { get; set; } = null!;

        public long? OperatorId { get; set; }
        public ClientGroup Operator { get; set; } = null!;

        public Client()
        {
            this.Tipo = TipoLocalidade.C;
        }

    }
}