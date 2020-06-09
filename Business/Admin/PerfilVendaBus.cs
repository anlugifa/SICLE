using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades;
using System.Linq;
using Dominio.Entidades.Acesso;

namespace Sicle.Business.Admin
{
    public class PerfilVendaBus : SicleBusiness<PerfilVenda>
    {
        public PerfilVendaBus()
        {

        }       

        public IQueryable<AssociacaoUsuarioPerfilVenda> GetAssociacaoUsuario(int perfilId)
        {
            using (var repo = new BaseRepository<AssociacaoUsuarioPerfilVenda>())
            {
                return repo.AsQueryable().Where(g => g.PerfilVendaId == perfilId);
            }
        }

        public override PerfilVenda MergeFromDB(PerfilVenda localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: PerfilVenda");


            objFromDB.Code = localCopy.Code;
            objFromDB.Nome = localCopy.Nome;
            objFromDB.ProfileLevel = localCopy.ProfileLevel;

            objFromDB.VlPrazo = localCopy.VlPrazo;
            objFromDB.VlValorComplementoPreco = localCopy.VlValorComplementoPreco;
            objFromDB.VlVolume = localCopy.VlVolume;
            objFromDB.VlVolumeComplemento = localCopy.VlVolumeComplemento;
            objFromDB.VlVolumeContrato = localCopy.VlVolumeMaxOrderContrato;
            objFromDB.VlVolumeMaxOrderContrato = localCopy.VlVolumeMaxOrderContrato;
            objFromDB.VlVolumeMaxOrderDerivatives = localCopy.VlVolumeMaxOrderDerivatives;
            objFromDB.VlVolumeMaxOrderSubproduct = localCopy.VlVolumeMaxOrderSubproduct;
            objFromDB.MaxPeriodSaleContract = localCopy.MaxPeriodSaleContract;
            objFromDB.MaxPeriodSaleForeignContract = localCopy.MaxPeriodSaleForeignContract;
            
            objFromDB.IsComplementApprover = localCopy.IsComplementApprover;
            objFromDB.IsContractPriceApprover = localCopy.IsContractPriceApprover;
            objFromDB.IsFinanceEndorsement = localCopy.IsFinanceEndorsement;
            objFromDB.IsForecastApprover = localCopy.IsForecastApprover;
            objFromDB.IsProvisionApprover = localCopy.IsProvisionApprover;
            objFromDB.IsYnorFromYcnrApprover = localCopy.IsYnorFromYcnrApprover;

            return objFromDB;
        }
    }

}
