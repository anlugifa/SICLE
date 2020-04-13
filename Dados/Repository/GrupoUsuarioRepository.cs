using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados.Repository.Base;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repository
{
    public class GrupoUsuarioRepository : BaseRepository<GrupoUsuario, int>
    {
        public GrupoUsuarioRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override GrupoUsuario Get(int id)
        {
            return _context.GruposUsuarios.First(o => o.Code.Equals(id));
        }

        public override int GetPkValue(GrupoUsuario entity)
        {
            return (int)typeof(GrupoUsuario).GetProperty("Id").GetValue(entity);
        }

        public IQueryable<AssociacaoGrupoUsuario> GetAssociacaoGrupoUsuarios(int grupoId)
        {
            return _context.AssociacaoGruposUsuarios.Where(g => g.GrupoUsuarioId == grupoId)
                                    .AsQueryable<AssociacaoGrupoUsuario>();
        }
    }
}