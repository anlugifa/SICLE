using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Entidades.Localidades;

namespace Dominio.Entidades.Produtos
{    
    public class ProductInPlant 
    {
        public long ProductId {get; set;}
        public Product Product  {get; set;}

        public int PlantId  {get; set;}
        public Plant Plant  {get; set;}
        
        public int Month  {get; set;}
        public int Year  {get; set;}
        public double MinimumCapacity {get; set;}
        public double MaximumCapacity {get; set;}
        public double Target {get; set;}
        public double StockWheel {get; set;}
    }
}