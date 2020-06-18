

using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class PricingPeriodBus : SicleBusiness<SaleContractPricingPeriod>
    {
        public Boolean AreEquals(SaleContractPricingPeriod localRule, SaleContractPricingPeriod dbRule)
        {
            if (localRule == null || dbRule == null)
                return false;

            if (localRule.Month != dbRule.Month)
                return false;

            if (localRule.Week != dbRule.Week)
                return false;

            if (localRule.Year != dbRule.Year)
                return false;

            return true;
        }


        public Boolean SamePeriodAndRules(SaleContractPricingPeriod localPeriod, SaleContractPricingPeriod other)
        {
            if (localPeriod == null || other == null)
                return false;

            if (localPeriod.Flexibility != other.Flexibility)
                return false;

            if (localPeriod.Flexibility != other.Flexibility)
                return false;

            if (!AreEquals(localPeriod, other))
                return false;


            if ( (localPeriod.MapPricingRules == null && other.MapPricingRules != null) ||
                 (localPeriod.MapPricingRules != null && other.MapPricingRules == null))
            {
                return false;
            }
            else
            {
                foreach (var thisRule in localPeriod.MapPricingRules)
                {
                    bool ruleFound = false;

                    foreach (var otherRule in other.MapPricingRules)
                    {
                        if (thisRule.SaleContractPricingRule.ParentRuleId != null && 
                            thisRule.SaleContractPricingRule.ParentRuleId == otherRule.SaleContractPricingRule.ParentRuleId)
                        {
                            ruleFound = true;
                            break;
                        }
                    }

                    if (!ruleFound)
                    {
                        return false;
                    }
                }

                foreach (var thisRule in other.MapPricingRules)
                {
                    bool ruleFound = false;

                    foreach (var otherRule in localPeriod.MapPricingRules)
                    {
                        if (thisRule.SaleContractPricingRule != null &&  otherRule.SaleContractPricingRule != null)
                        {
                            if (thisRule.SaleContractPricingRule.Id == otherRule.SaleContractPricingRule.ParentRuleId)
                            {
                                ruleFound = true;
                                break;
                            }
                        }
                    }

                    if (!ruleFound)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}