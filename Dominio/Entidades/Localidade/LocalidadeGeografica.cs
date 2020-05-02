using System;

namespace Dominio.Entidades.Localidades
{
    public abstract class LocalidadeGeografica : Localidade
    {
        public String Latitude {get; set;} = null!;
        public String Longitude {get; set;} = null!;
        public String City {get; set;} = null!;
        public String State {get; set;} = null!;     
        
        public Boolean IsAgro {get; set;}

        public TaxGroupType? TaxGroupType {get; set;}
        public StatusLocalidade? Status {get; set;}

        public int?  RegionId {get; set;}
        public Regiao Region {get; set;} = null!;
    }
}
