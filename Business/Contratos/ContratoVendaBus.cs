using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sicle.Business.Contratos
{
    public class ContratoVendaBus : SicleBusiness<ContratoVenda>
    {
         public override ContratoVenda MergeFromDB(ContratoVenda localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: ContratoVenda");

            objFromDB.Nickname = localCopy.Nickname;
            objFromDB.ContratoVendaAnteriorId = localCopy.ContratoVendaAnteriorId;
            objFromDB.ContratoMestreId = localCopy.ContratoMestreId;                      

            objFromDB.Begin = localCopy.Begin;
            objFromDB.End = localCopy.End;
            objFromDB.Flexibility = localCopy.Flexibility;
            objFromDB.TotalVolume = localCopy.TotalVolume;
            objFromDB.EconomicGroup = localCopy.EconomicGroup;
            objFromDB.Observation = localCopy.Observation;

            objFromDB.IsAvailableForBroker = localCopy.IsAvailableForBroker;
            objFromDB.IsDeleted = localCopy.IsDeleted;
            objFromDB.IsOperacaoNNE = localCopy.IsOperacaoNNE;
            objFromDB.IsActive = localCopy.IsActive;

            objFromDB.Safra = localCopy.Safra;
            objFromDB.Reason = localCopy.Reason;

            objFromDB.CreationDate = localCopy.CreationDate;
            objFromDB.DateOfApproval = localCopy.DateOfApproval;
            objFromDB.DateOfTradingApproval = localCopy.DateOfTradingApproval;
            objFromDB.DateOfFinancesApproval = localCopy.DateOfFinancesApproval;

            objFromDB.Approver = localCopy.Approver;
            objFromDB.TradingApprover = localCopy.TradingApprover;
            objFromDB.FinancesApprover = localCopy.FinancesApprover;
            objFromDB.ContractVersion = localCopy.ContractVersion;

            objFromDB.MaxForecast = localCopy.MaxForecast;
            objFromDB.HasForecast = localCopy.HasForecast;
            objFromDB.HasNegotiationBC = localCopy.HasNegotiationBC;
            objFromDB.IsOperacaoNNE = localCopy.IsOperacaoNNE;

            objFromDB.Status = localCopy.Status;
            objFromDB.Period = localCopy.Period;
            objFromDB.EndorsementStatus = localCopy.EndorsementStatus;

            objFromDB.CreationUserId = localCopy.CreationUserId;
            objFromDB.EditorId = localCopy.EditorId;
            objFromDB.TraderId = localCopy.TraderId;
            objFromDB.BrokerId = localCopy.BrokerId;

            objFromDB.ProductGroupId = localCopy.ProductGroupId;
            objFromDB.ClientGroupId = localCopy.ClientGroupId;

            objFromDB.PaymentTermId = localCopy.PaymentTermId;

            return objFromDB;
        } 

        public IQueryable<ContratoVenda> Query()
        {
            return AsQueryable()
                    .Include(p => p.ContratoMestre)
                    .Include(p => p.PaymentTerm)
                    .Include(p => p.ClientGroup)
                    .Include(p => p.ProductGroup);
        }
    }
}