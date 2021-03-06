using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Localidades
{    
    public class RestricaoCargaDescarga 
    {
        public double Capacity { get; set; }

        public int PlantId {get; set;}
        public Plant Plant {get; set;} = null!;

	    public TipoRestricao TipoRestricao {get; set;}
    }
}