using System;

namespace Dominio.Entidades.Localidade
{
    public abstract class LocalidadeGeografica : Localidade
    {
        private String Latitude {get; set;}
        private String Longitude {get; set;}
        private String City {get; set;}
        private String State {get; set;}
        private Regiao Region {get; set;}
        private TaxGroupType TaxGroupType {get; set;}
        private Boolean IsAgro {get; set;}
        private StatusLocalidade status {get; set;}
    }
}
