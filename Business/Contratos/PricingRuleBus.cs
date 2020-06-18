

using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class PricingRuleBus : SicleBusiness<SaleContractPricingRule>
    {
        public Boolean AreEquals(SaleContractPricingRule localRule, SaleContractPricingRule dbRule)
        {            
            if (localRule.AdjustReferenceType != dbRule.AdjustReferenceType)
                return false;

            if (localRule.IsCumulativeGrossDiscount != dbRule.IsCumulativeGrossDiscount)
                return false;

            if (localRule.IsCumulativeNetDiscount != dbRule.IsCumulativeNetDiscount)
                return false;

            if (localRule.DiflogIncidenceType != dbRule.DiflogIncidenceType)
                return false;
         
            if (localRule.IsEsalqCurrent != dbRule.IsEsalqCurrent)
                return false;

            if (localRule.EsalqDescriptionId != dbRule.EsalqDescriptionId)
                return false;          
           
            if (localRule.EsalqPeriodType != dbRule.EsalqPeriodType)
                return false;     

            if (localRule.EsalqType != dbRule.EsalqType)
                return false;    

            if (localRule.FlatPrice != dbRule.FlatPrice)
                return false;    
          
            if (localRule.FreightIncidenceType != dbRule.FreightIncidenceType)
                return false;
            
            if (localRule.GrossDiscount != dbRule.GrossDiscount)
                return false;

            if (localRule.GrossDiscountPercent != dbRule.GrossDiscountPercent)
                return false;

            if (localRule.NetDiscount != dbRule.NetDiscount)
                return false;
            
            if (localRule.NetDiscountPercent != dbRule.NetDiscountPercent)
                return false;
            
            if (localRule.PricingType != dbRule.PricingType)
                return false;

            if (localRule.Rebate != dbRule.Rebate)
                return false;

            if (localRule.PrecoPBDescription != dbRule.PrecoPBDescription)
                return false;

            if (localRule.PrecoPBProduct != dbRule.PrecoPBProduct)
                return false;
            
            if (localRule.PrecoPBPeriodType != dbRule.PrecoPBPeriodType)
                return false;
            
            if (localRule.IsRebateWithinTaxes != dbRule.IsRebateWithinTaxes)
                return false;

            if (localRule.IsWeeklyAverage != dbRule.IsWeeklyAverage)
                return false;
         
            return true;
        }
    }
}