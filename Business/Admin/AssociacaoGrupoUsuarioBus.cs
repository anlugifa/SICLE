using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades;
using System.Linq;
using Dominio.Entidades.Acesso;

namespace Sicle.Business.Admin
{
    public class AssociacaoGrupoUsuarioBus : SicleBusiness<AssociacaoGrupoUsuario>
    {
        public AssociacaoGrupoUsuarioBus()
        {

        }        
        

        public override AssociacaoGrupoUsuario MergeFromDB(AssociacaoGrupoUsuario localCopy)
        {
            var objFromDB = Get(p=> p.UsuarioId == localCopy.UsuarioId && p.GrupoUsuarioId == localCopy.GrupoUsuarioId);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.GrupoUsuarioId +
                    " NOT FOUND FOR ENTITY: AssociacaoGrupoUsuario");


            objFromDB.GrupoUsuarioId = localCopy.GrupoUsuarioId;
            objFromDB.UsuarioId = localCopy.UsuarioId;
            
            return objFromDB;
        }
    }
}
