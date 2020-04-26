using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Pricing;

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

    static class ProductEsalqTypeMethods
    {

        public static EsalqType ToEsalqType(this ProductEsalqType e)
        {
            switch (e)
            {
                case ProductEsalqType.ANIDRO:
                    return EsalqType.ANIDRO; 

                case ProductEsalqType.HIDRATADO:
                    return EsalqType.HIDRATADO;

                default:
                    throw new Exception("Não há conversão para: " + e);                   
            }
        }
    }
}