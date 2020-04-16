using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Produtos
{
    public class SpecialUnit
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Unit { get; set; }
        public String UnitES { get; set; }
        public Double ConversionFactor { get; set; }
        public Boolean UsePallet { get; set; }
        public String PalletUnit { get; set; }
        public String PalletMaterial { get; set; }
        public Double PalletValue { get; set; }
        public int PalletCapacity { get; set; }
        public int PalletWeight { get; set; }
    }
}