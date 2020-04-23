using System;

namespace Dominio.Entidades.Localidades
{
    public abstract class LocalidadeGeografica : Localidade
    {
        public String Latitude {get; set;}
        public String Longitude {get; set;}
        public String City {get; set;}
        public String State {get; set;}        
        
        public Boolean IsAgro {get; set;}

        public TaxGroupType? TaxGroupType {get; set;}
        public StatusLocalidade? Status {get; set;}

        public int?  RegionId {get; set;}
        public Regiao Region {get; set;}
    }
}
