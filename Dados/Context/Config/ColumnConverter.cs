using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Dominio.Entidades.Pricing;
using Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sicle.Dados.Context.Config
{
    public class ColumnConverter 
    {
        private ColumnConverter()
        {
        }

        public static ValueConverter SAPEnvConverter()
        {
            return new ValueConverter<String, SAPEnv>(
                b => b.Equals("P72") ? SAPEnv.P72 : SAPEnv.EAB,
                b => b.ToString()
            );
        }

        public static ValueConverter BooToCharConverter()
        {
            return new ValueConverter<bool, char>(
                b => b ? '1' : '0',
                b => b.Equals("1") ? true : false
            );
        }

        public static ValueConverter TipoLocalidadeConverter()
        {
            return new ValueConverter<TipoLocalidade, char>(
                v => Char.Parse(v.ToString()),
                v => (TipoLocalidade)Enum.Parse(typeof(TipoLocalidade), v.ToString())
            );
        }

        public static ValueConverter ContractStatusConverter()
        {
            return new ValueConverter<ContractStatus, String>(
                v => v.ToString(),
                v => (ContractStatus)Enum.Parse(typeof(ContractStatus), v)
            );
        }

        public static ValueConverter SAPEnvTypeConverter()
        {
            return new ValueConverter<SAPEnvType, String>(
                v => v.ToString(),
                v => (SAPEnvType)Enum.Parse(typeof(SAPEnvType), v)
            );
        }

        public static ValueConverter EndorsementStatusConverter()
        {
            return new ValueConverter<EndorsementStatus, String>(
                v => v.ToString(),
                v => (EndorsementStatus)Enum.Parse(typeof(EndorsementStatus), v)
            );
        }

        public static ValueConverter ProductEsalqConverter()
        {
            return new ValueConverter<ProductEsalqType, String>(
                v => v.ToString(),
                v => (ProductEsalqType)Enum.Parse(typeof(ProductEsalqType), v)
            );
        }

        public static ValueConverter ClientGroupTypeConverter()
        {
            return new ValueConverter<ClientGroupType, String>(
                v => v.ToString(),
                v => (ClientGroupType)Enum.Parse(typeof(ClientGroupType), v)
            );
        }

        public static ValueConverter ClientTypeConverter()
        {
            return new ValueConverter<ClientType, String>(
                v => v.ToString(),
                v => (ClientType)Enum.Parse(typeof(ClientType), v)
            );
        }

        public static ValueConverter StatusLocalidadeConverter()
        {
            return new ValueConverter<StatusLocalidade?, String>(
                v => v.ToString(),
                v => (StatusLocalidade)Enum.Parse(typeof(StatusLocalidade), v)
            );
        }

        public static ValueConverter TaxGroupTypeConverter()
        {
            return new ValueConverter<TaxGroupType, String>(
                v => v.ToString(),
                v => (TaxGroupType)Enum.Parse(typeof(TaxGroupType), v)
            );
        }

        public static ValueConverter PaymentTermTypeConverter()
        {
            return new ValueConverter<PaymentTermType, String>(
                v => v.ToString(),
                v => (PaymentTermType)Enum.Parse(typeof(PaymentTermType), v)
            );
        }

        public static ValueConverter PeriodTypeConverter()
        {
            return new ValueConverter<Nullable<PeriodType>, String>(
                v => v.ToString(),
                v => (PeriodType)Enum.Parse(typeof(PeriodType), v)
            );
        }

        public static ValueConverter CGCTypeConverter()
        {
            return new ValueConverter<Nullable<CGCType>, String>(
                v => v.ToString(),
                v => (CGCType)Enum.Parse(typeof(CGCType), v)
            );
        }

        public static ValueConverter SaleTypeConverter()
        {
            return new ValueConverter<Nullable<SaleType>, String>(
                v => v.ToString(),
                v => (SaleType)Enum.Parse(typeof(SaleType), v)
            );
        }

        public static ValueConverter EsalqTypeConverter()
        {
            return new ValueConverter<EsalqType, String>(
                v => v.ToString(),
                v => (EsalqType)Enum.Parse(typeof(EsalqType), v)
            );
        }

        public static ValueConverter PrecoPBPeriodTypeConverter()
        {
            return new ValueConverter<PrecoPBPeriodType, String>(
                v => v.ToString(),
                v => (PrecoPBPeriodType)Enum.Parse(typeof(PrecoPBPeriodType), v)
            );
        }

        public static ValueConverter PricingIncidenceTypeConverter()
        {
            return new ValueConverter<PricingIncidenceType, String>(
                v => v.ToString(),
                v => (PricingIncidenceType)Enum.Parse(typeof(PricingIncidenceType), v)
            );
        }

        public static ValueConverter PricingTypeConverter()
        {
            return new ValueConverter<PricingType, String>(
                v => v.ToString(),
                v => (PricingType)Enum.Parse(typeof(PricingType), v)
            );
        }

        public static ValueConverter PricingAdjustReferenceTypeConverter()
        {
            return new ValueConverter<PricingAdjustReferenceType, String>(
                v => v.ToString(),
                v => (PricingAdjustReferenceType)Enum.Parse(typeof(PricingAdjustReferenceType), v)
            );
        }
    }
}