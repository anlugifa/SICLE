using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades;
using System.Linq;
using Dominio.Entidades.Acesso;

namespace Sicle.Business.Admin
{
    public class GrupoUsuarioBus : SicleBusiness<GrupoUsuario>
    {
        public GrupoUsuarioBus()
        {

        }        

        public IQueryable<AssociacaoGrupoUsuario> GetAssociacaoGrupoUsuarios(int grupoId)
        {
            using (var repo = new BaseRepository<AssociacaoGrupoUsuario>())
            {
                return repo.AsQueryable().Where(g => g.GrupoUsuarioId == grupoId);
            }             
        }

        public override GrupoUsuario MergeFromDB(GrupoUsuario localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Code +
                    " NOT FOUND FOR ENTITY: GrupoUsuario");


            objFromDB.Code = localCopy.Code;
            objFromDB.Nome = localCopy.Nome;
            
            return objFromDB;
        }
    }
}
