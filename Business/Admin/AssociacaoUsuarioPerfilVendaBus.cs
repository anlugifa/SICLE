using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades;
using System.Linq;
using Dominio.Entidades.Acesso;

namespace Sicle.Business.Admin
{
    public class AssociacaoUsuarioPerfilVendaBus : SicleBusiness<AssociacaoUsuarioPerfilVenda>
    {
        public AssociacaoUsuarioPerfilVendaBus()
        {
        }

        public override AssociacaoUsuarioPerfilVenda MergeFromDB(AssociacaoUsuarioPerfilVenda localCopy)
        {
            var objFromDB = Get(p=> p.UsuarioId == localCopy.UsuarioId && p.PerfilVendaId == localCopy.PerfilVendaId);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.PerfilVendaId +
                    " NOT FOUND FOR ENTITY: AssociacaoPerfilVenda");


            objFromDB.PerfilVendaId = localCopy.PerfilVendaId;
            objFromDB.UsuarioId = localCopy.UsuarioId;
            
            return objFromDB;
        }
    }
}
