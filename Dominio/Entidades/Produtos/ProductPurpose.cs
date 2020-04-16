using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Produtos
{
    public enum ProductPurpose
    {
        [Description("Carburante")]
        CARBURANTE,
        
        [Description("Industrial")]
        INDUSTRIAL
    }
}