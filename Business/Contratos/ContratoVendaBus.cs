using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sicle.Logs.Bases;

namespace Sicle.Business.Contratos
{
    public class ContratoVendaBus<T> : SicleBusiness<T> where T : SaleContract
    {
        public override T MergeFromDB(T localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: ContratoVenda");

            objFromDB.Name = localCopy.Name;
            objFromDB.Nickname = localCopy.Nickname;
            //objFromDB.ContratoVendaAnteriorId = localCopy.ContratoVendaAnteriorId;
            objFromDB.ContratoMestreId = localCopy.ContratoMestreId;

            objFromDB.Begin = localCopy.Begin;
            objFromDB.End = localCopy.End;

            objFromDB.EconomicGroup = localCopy.EconomicGroup;
            objFromDB.Observation = localCopy.Observation;

            objFromDB.IsAvailableForBroker = localCopy.IsAvailableForBroker;
            objFromDB.IsDeleted = localCopy.IsDeleted;
            objFromDB.IsOperacaoNNE = localCopy.IsOperacaoNNE;
            objFromDB.IsActive = localCopy.IsActive;

            objFromDB.Safra = localCopy.Safra;

            //objFromDB.Flexibility = localCopy.Flexibility;
            //objFromDB.TotalVolume = localCopy.TotalVolume;
            //objFromDB.Reason = localCopy.Reason;

            objFromDB.CreationDate = localCopy.CreationDate;
            objFromDB.DateOfApproval = localCopy.DateOfApproval;
            objFromDB.DateOfTradingApproval = localCopy.DateOfTradingApproval;
            objFromDB.DateOfFinancesApproval = localCopy.DateOfFinancesApproval;

            objFromDB.Approver = localCopy.Approver;
            objFromDB.TradingApprover = localCopy.TradingApprover;
            //objFromDB.FinancesApprover = localCopy.FinancesApprover;
            objFromDB.ContractVersion = localCopy.ContractVersion;

            //objFromDB.MaxForecast = localCopy.MaxForecast;
            //objFromDB.HasForecast = localCopy.HasForecast;
            objFromDB.HasNegotiationBC = localCopy.HasNegotiationBC;
            objFromDB.IsOperacaoNNE = localCopy.IsOperacaoNNE;

            //objFromDB.Status = localCopy.Status;
            objFromDB.Period = localCopy.Period;
            objFromDB.EndorsementStatus = localCopy.EndorsementStatus;

            objFromDB.CreationUserId = localCopy.CreationUserId;
            //objFromDB.EditorId = localCopy.EditorId;
            objFromDB.TraderId = localCopy.TraderId;
            objFromDB.BrokerId = localCopy.BrokerId;

            objFromDB.ProductGroupId = localCopy.ProductGroupId;
            objFromDB.ClientGroupId = localCopy.ClientGroupId;

            objFromDB.PaymentTermId = localCopy.PaymentTermId;

            return objFromDB;
        }

        public IQueryable<SaleContract> Query()
        {
            return AsQueryable()
                    .Include(p => p.ContratoMestre)
                    .Include(p => p.PaymentTerm)
                    .Include(p => p.ClientGroup)
                    .Include(p => p.ProductGroup);
        }

        //
        // Verifica se o contrato alterado precisa seguir para aprovação
        //
        public Boolean NeedApproval(SaleContract localCopy)
        {
            if (localCopy == null)
            {
                var e = new SicleException("Contrato não pode ser null!");
                e.LogarErro();

                throw e;
            }

            var contractFromDB = new ApprovalContractBus().Get(localCopy.Id);

            if (contractFromDB == null)
            {
                var e = new SicleException("Contrato em edição não pode ser encontrado no banco de dados!");
                e.LogarErro();

                throw e;
            }

            return CheckIfPropertyChanged(localCopy, contractFromDB) ||
                    CheckIfQuotasChanged(localCopy, contractFromDB) ||
                    CheckIfPricingRulesChanged(localCopy, contractFromDB) ||
                    CheckIfPricingPeriodsChanged(localCopy, contractFromDB);
        }

        internal Boolean CheckIfQuotasChanged(SaleContract localCopy, ApprovalSaleContract contractFromDB)
        {
            if (contractFromDB.EvaluatedContract.Quotas.Count != localCopy.Quotas.Count)
            {
                return true;
            }

            var contractQuotaBus = new ContractQuotaBus(); 
            bool sendToApproval = false;

            //Testando se as cotas e volumes mudaram
            foreach (var screenQuota in contractFromDB.EvaluatedContract.Quotas)
            {
                bool quotaFound = false;
                foreach (var selectedQuota in localCopy.Quotas)
                {
                    if (contractQuotaBus.AreEquals(selectedQuota, screenQuota))
                    {
                        quotaFound = true;
                        break;
                    }
                }
                sendToApproval = quotaFound ? false : true;
                if (sendToApproval)
                {
                    return true;
                }
            }

            return sendToApproval;
        }

        internal Boolean CheckIfPricingPeriodsChanged(SaleContract localCopy, ApprovalSaleContract contractFromDB)
        {
            var pricingBus = new PricingPeriodBus();

            foreach (SaleContractPricingPeriod screenPeriod in contractFromDB.EvaluatedContract.PricingPeriods)
            {
                foreach (var selectedPeriod in localCopy.PricingPeriods)
                {
                    if (pricingBus.AreEquals(selectedPeriod, screenPeriod))
                    {
                        continue;
                    }
                    else if (!pricingBus.SamePeriodAndRules(selectedPeriod, screenPeriod))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal Boolean CheckIfPricingRulesChanged(SaleContract localCopy, ApprovalSaleContract contractFromDB)
        {

            var pricingRulesBus = new PricingRuleBus();

            //Testando se as regras de precificação mudaram
            foreach (var originalRule in contractFromDB.EvaluatedContract.PricingRules)
            {
                foreach (var selectedRule in localCopy.PricingRules)
                {
                    if (selectedRule.ParentRuleId != null)
                    {
                        if (selectedRule.ParentRuleId == originalRule.Id) // TODO: Entender essa regra 
                        {
                            if (!pricingRulesBus.AreEquals(selectedRule, originalRule))
                            {
                                return true;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (!pricingRulesBus.AreEquals(selectedRule, originalRule))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        internal Boolean CheckIfPropertyChanged(SaleContract localCopy, SaleContract contractFromDB)
        {
            // TODO: Como altera o nome do Mestre na ediçao do Contrato?
            // if (contractFromDB.ContratoMestreId == null || !contractFromDB.ContratoMestre.Nickname.Equals(masterSaleContract.Nickname))
            // {
            //     return false;
            // }

            // vínculo do contrato mestre que pertence à instancia sendo alterada localmente
            MasterSaleContract masterSaleContract = null;
            if (localCopy.ContratoMestreId.HasValue && localCopy.ContratoMestreId.Value > 0)
                masterSaleContract = new MasterSaleContractBus().Get(localCopy.ContratoMestreId.Value);

            if ((localCopy.ContratoMestreId == null && contractFromDB.ContratoMestreId != null) ||
                 (localCopy.ContratoMestreId != null && contractFromDB.ContratoMestreId == null))
            {
                return true;
            }

            // TODO: Se usuário não tem perfil de ForecastApprover também deve ser aprovado.
            if (localCopy.TotalVolume != contractFromDB.TotalVolume)
                return true;

            if (localCopy.IsAvailableForBroker != contractFromDB.IsAvailableForBroker)
                return true;

            if (localCopy.Begin != contractFromDB.Begin)
                return true;

            if (localCopy.BrokerId != contractFromDB.BrokerId)
                return true;

            if (localCopy.ClientGroupId != contractFromDB.ClientGroupId)
                return true;

            if (localCopy.EconomicGroup != contractFromDB.EconomicGroup)
                return true;

            if (localCopy.End != contractFromDB.End)
                return true;

            if (localCopy.Flexibility != contractFromDB.Flexibility)
                return true;

            if (!localCopy.Nickname.Equals(contractFromDB.Nickname))
                return true;

            if (localCopy.PaymentTermId != contractFromDB.PaymentTermId)
                return true;

            if (localCopy.Period != contractFromDB.Period)
                return true;

            if (localCopy.ProductGroupId != contractFromDB.ProductGroupId)
                return true;

            if (localCopy.CGCId != contractFromDB.CGCId)
                return true;

            if (!localCopy.Safra.Equals(contractFromDB.Safra))
                return true;

            if (localCopy.MaxForecast != contractFromDB.MaxForecast)
                return true;

            return false;
        }
    }
}