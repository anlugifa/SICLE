using System;
using Dominio.Entidades.Contrato;

namespace Web.Util
{
    public static class ConvertString
    {
        public static String ToStr(this double value)
        {
            return String.Format("{0:N0}", value);
        }

        public static String ToStr(this double? value)
        {
            double valor = 0;
            if (value.HasValue)
                valor = value.Value;

            return valor.ToStr();
        }

        public static String ToStr(this DateTime value)
        {
            return value.ToString("dd/MM/yyyy");
        }

        public static String ToStr(this DateTime? value)
        {
            if (!value.HasValue)
                return "-";

            return value.Value.ToStr();
        }
    }
}