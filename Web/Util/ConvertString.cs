using System;
using System.Text;
using Dominio.Entidades.Contrato;
using Util.Language;

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

        public static String PricingPeriodString(this SaleContractPricingPeriod period)
        {
            // Se semanal
            if (period.Week.HasValue && period.Week.Value > 0)
            {
                return LanguageManager.Instance()
                        .Format("SaleContractInsertView.Week", 
                            period.Week, String.Format("{0:00}/{1}",
                            (period.Month + 1), period.Year));
            }
            
            return String.Format("{1}/{2}", period.Week, period.Month + 1, period.Year);         
        }

        public static String PricingRulesString(this SaleContractPricingPeriod period)
        {
            var sb = new StringBuilder();

            var iterator = period.MapPricingRules.GetEnumerator();
            var last = !iterator.MoveNext();

            while(!last)
            {
                var current = iterator.Current;                
                sb.Append(current.SaleContractPricingRule.Name.ToString());

                last = !iterator.MoveNext();
                if (!last)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }
    }
}