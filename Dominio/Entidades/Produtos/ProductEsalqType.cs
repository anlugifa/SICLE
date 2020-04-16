using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Produtos
{

    public enum ProductEsalqType 
    {

        [Description("Anidro")]
        ANIDRO,
        
        [Description("Hidratado")]
        HIDRATADO,
        
        [Description("Outros Fins")]
        OUTROS_FINS,
        
        [Description("Biodiesel")]
        BIODIESEL,
        
        [Description("Subproduto")]
        SUBPRODUTO
    }
}