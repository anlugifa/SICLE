using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Localidade
{    
    public class ProductInPlant 
    {
        public Product Product;
        public Plant Plant;
        
        public int Month;
        public int Year;
        public double MinimumCapacity;
        public double MaximumCapacity;
        public double Target;
        public double StockWheel;
    }
}