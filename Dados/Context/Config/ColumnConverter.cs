using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidade;
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
    }
}