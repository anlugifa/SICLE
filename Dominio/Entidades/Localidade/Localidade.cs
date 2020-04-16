using System;

namespace Dominio.Entidades.Localidade
{
    public abstract class Localidade
    {
        public int Id { get; set; }

        public String Name { get; set; }
        
        public String Code { get; set; }

        public TipoLocalidade Tipo { get; set; }
    }
}
