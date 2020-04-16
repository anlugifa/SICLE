using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades.Localidade
{    
    public class RestricaoCargaDescarga 
    {
        public double Capacity { get; set; }

        public Plant Planta {get; set;}

	    public TipoRestricao TipoRestricao {get; set;}
    }
}