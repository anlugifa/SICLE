using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Pricing
{
    public enum EsalqType
    {
        [Description("Anidro")]
        ANIDRO,

        [Description("Hidratado")]
        HIDRATADO,

        [Description("Hidratado - Outros Fins")]
        OUTROS_FINS_HIDRATADO,

        [Description("Anidro - Outros Fins")]
        OUTROS_FINS_ANIDRO
    }

    static class EsalqTypeMethods
    {

        public static ProductEsalqType ToProductEsalqType(this EsalqType e)
        {
            switch (e)
            {
                case EsalqType.ANIDRO:
                    return ProductEsalqType.ANIDRO; 

                case EsalqType.HIDRATADO:
                    return ProductEsalqType.HIDRATADO;
                   
                case EsalqType.OUTROS_FINS_HIDRATADO:
                    return ProductEsalqType.OUTROS_FINS;

                case EsalqType.OUTROS_FINS_ANIDRO:
                    return ProductEsalqType.OUTROS_FINS;

                default:
                    throw new Exception("Não há conversão para: " + e);
            }
        }
    }
}