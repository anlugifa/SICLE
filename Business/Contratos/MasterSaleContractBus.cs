using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Sicle.Business.Contratos
{
    public class MasterSaleContractBus : SicleBusiness<MasterSaleContract>
    {
        public struct MestreStatus
        {
            public ContractStatus? Status {get; set;}
            public EndorsementStatus? EndorsementStatus {get; set;}
            public Double TotalVolume {get; set;}
            public Double MaxVolume {get; set;}
            public DateTime? MinDate {get; set;}
            public DateTime? MaxDate {get; set;}
        }

        public MasterSaleContractBus()
        {

        }

        public override MasterSaleContract MergeFromDB(MasterSaleContract localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: ContratoVendaMestre");

            objFromDB.Nickname = localCopy.Nickname;
            objFromDB.Discriminator = localCopy.Discriminator;
            objFromDB.Observation = localCopy.Observation;
            objFromDB.IsActive = localCopy.IsActive;

            return objFromDB;
        }

        public async Task<List<SaleContract>> GetByMaster(long masterId, int pageIndex, int pageSize)
        {
            using (var repo = new BaseRepository<SaleContract>())
            {
                var q = await repo.AsQueryable()
                            .Where(x => x.ContratoMestreId == masterId)
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

                return q;
            }
        }

        public double GetTotalVolume(MasterSaleContract mestre)
        {
            double totalVolume = 0;

            if (mestre.Contratos.Count  == 0)
                return totalVolume;

            foreach (SaleContract contract in mestre.Contratos)
            {
                double? realVolume = contract.HasForecast ? contract.MaxForecast.Value : contract.TotalVolume;                

                totalVolume += (realVolume.HasValue ? realVolume.Value : 0);
            }

            return totalVolume;
        }

        public MestreStatus GetMestreStatus(MasterSaleContract mestre)
        {
            MestreStatus status = new MestreStatus();

            if (mestre.Contratos != null && mestre.Contratos.Count > 0)
            {
                status.Status = ContractStatus.REJECTED;
                status.EndorsementStatus = EndorsementStatus.NONE;
            }

            foreach (SaleContract contract in mestre.Contratos)
            {
                status.Status = GetContractStatus(status.Status, contract);
                status.EndorsementStatus = GetEndosementStatus(status.EndorsementStatus, contract);

                Double? realVolume = contract.HasForecast ? contract.MaxForecast.Value : contract.TotalVolume;
                if (realVolume.HasValue && realVolume.Value > status.MaxVolume)
                {
                    status.MaxVolume = realVolume.Value;
                }

                status.TotalVolume += (realVolume.HasValue ? realVolume.Value : 0);

                if (status.MinDate == null || DateTime.Compare(contract.Begin, status.MinDate.Value) < 0)
                {
                    status.MinDate = contract.Begin;
                }

                if (status.MaxDate == null || DateTime.Compare(contract.End, status.MaxDate.Value) > 0)
                {
                    status.MaxDate = contract.End;
                }
            }

            return status;
        }
        

        public ContractStatus? GetContractStatus(ContractStatus? statusMestre, SaleContract contract)
        {
            switch (contract.Status)
            {
                case ContractStatus.APPROVED:
                    if (statusMestre != ContractStatus.MODIFIED_IN_APPROVAL &&
                        statusMestre != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.APPROVED;
                    }
                    break;
                case ContractStatus.REJECTED:
                    if (statusMestre != ContractStatus.MODIFIED_IN_APPROVAL &&
                        statusMestre != ContractStatus.APPROVED &&
                        statusMestre != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.REJECTED;
                    }
                    break;
                case ContractStatus.CREATED_IN_APPROVAL:
                    return ContractStatus.CREATED_IN_APPROVAL;

                case ContractStatus.MODIFIED_IN_APPROVAL:
                    if (statusMestre != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.MODIFIED_IN_APPROVAL;
                    }
                    break;
                case ContractStatus.REMOVED:
                    if (statusMestre != ContractStatus.MODIFIED_IN_APPROVAL &&
                        statusMestre != ContractStatus.APPROVED &&
                        statusMestre != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.REMOVED;
                    }
                    break;
                default:
                    break;
            }

            return null;
        }

        public EndorsementStatus? GetEndosementStatus(EndorsementStatus? status, SaleContract contract)
        {
            switch (contract.EndorsementStatus)
            {
                case EndorsementStatus.ENDORSED:
                    if (status != EndorsementStatus.IN_ENDORSEMENT)
                    {
                        return EndorsementStatus.ENDORSED;
                    }
                    break;
                case EndorsementStatus.IN_ENDORSEMENT:
                    return EndorsementStatus.IN_ENDORSEMENT;

                case EndorsementStatus.NOT_NECESSARY:
                    if (status != EndorsementStatus.IN_ENDORSEMENT &&
                       status != EndorsementStatus.ENDORSED)
                    {
                        return EndorsementStatus.NOT_NECESSARY;
                    }
                    break;
                case EndorsementStatus.UNVALUED:
                    if (status != EndorsementStatus.IN_ENDORSEMENT)
                    {
                        return EndorsementStatus.UNVALUED;
                    }
                    break;
                case EndorsementStatus.NONE:
                    if (status != EndorsementStatus.IN_ENDORSEMENT &&
                        status != EndorsementStatus.NOT_NECESSARY &&
                        status != EndorsementStatus.ENDORSED &&
                        status != EndorsementStatus.UNVALUED)
                    {
                        return EndorsementStatus.NONE;
                    }
                    break;
            }

            return null;
        }
        
    }
}
