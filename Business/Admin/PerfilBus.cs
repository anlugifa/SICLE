using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades;
using System.Linq;
using Dominio.Entidades.Acesso;

namespace Sicle.Business.Admin
{
    public class PerfilBus : SicleBusiness<Perfil>
    {
        public PerfilBus()
        {

        } 


        public override Perfil MergeFromDB(Perfil localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Code +
                    " NOT FOUND FOR ENTITY: Perfil");


            objFromDB.Code = localCopy.Code;
            objFromDB.Nome = localCopy.Nome;
            objFromDB.Volume = localCopy.Volume;
            objFromDB.VolumeComplemento = localCopy.VolumeComplemento;
            objFromDB.VolumeContrato = localCopy.VolumeContrato;
            objFromDB.VlPrazoEnergia = localCopy.VlPrazoEnergia;
            objFromDB.VlPrecoEnergia = localCopy.VlPrecoEnergia;
            objFromDB.VlVolumeComplementoEnergia = localCopy.VlVolumeComplementoEnergia;
            objFromDB.VlVolumeContratoEnergia = localCopy.VlVolumeContratoEnergia;
            objFromDB.VlVolumeEnergia = localCopy.VlVolumeEnergia;
            objFromDB.VlVolumeImportacao = localCopy.VlVolumeImportacao;

            objFromDB.VlVolumeMaxOrderDerivatives = localCopy.VlVolumeMaxOrderDerivatives;
            objFromDB.VlVolumeMaxOrderSubproduct = localCopy.VlVolumeMaxOrderSubproduct;
            objFromDB.VlVolumeMaxPurchaseDerivatives = localCopy.VlVolumeMaxPurchaseDerivatives;
            objFromDB.VlVolumeMaxPurchaseSubproduct = localCopy.VlVolumeMaxPurchaseSubproduct;
            objFromDB.VlVolumeImportacao = localCopy.VlVolumeImportacao;
            
            objFromDB.MaxCreditLimit = localCopy.MaxCreditLimit;
            objFromDB.MaxPeriodContract = localCopy.MaxPeriodContract;
            objFromDB.MaxPeriodImportContract = localCopy.MaxPeriodImportContract;

            objFromDB.IsProvisionApprover = localCopy.IsProvisionApprover;
            objFromDB.Rating = localCopy.Rating;
            objFromDB.ProfileLevel = localCopy.ProfileLevel;
            
            return objFromDB;
        }
    }

}
