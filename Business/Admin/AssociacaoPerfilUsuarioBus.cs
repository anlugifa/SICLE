using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades;
using System.Linq;
using Dominio.Entidades.Acesso;

namespace Sicle.Business.Admin
{
    public class AssociacaoPerfilUsuarioBus : SicleBusiness<AssociacaoUsuarioPerfil>
    {
        public AssociacaoPerfilUsuarioBus()
        {
        }

        public override AssociacaoUsuarioPerfil MergeFromDB(AssociacaoUsuarioPerfil localCopy)
        {
            var objFromDB = Get(p=> p.UsuarioId == localCopy.UsuarioId && p.PerfilId == localCopy.PerfilId);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.PerfilId +
                    " NOT FOUND FOR ENTITY: AssociacaoGrupoUsuario");


            objFromDB.PerfilId = localCopy.PerfilId;
            objFromDB.UsuarioId = localCopy.UsuarioId;
            
            return objFromDB;
        }
    }
}
