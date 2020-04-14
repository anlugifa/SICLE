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
    public class PerfilRepository : BaseRepository<Perfil, int>
    {
        public PerfilRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override Perfil Get(int id)
        {
            return _context.Perfis.First(o => o.Id == id);
        }

        public override int GetPkValue(Perfil entity)
        {
            return (int)typeof(Perfil).GetProperty("Id").GetValue(entity);
        }

        public IQueryable<AssociacaoUsuarioPerfil> GetAssociacaoUsuario(int perfilId)
        {
            return _context.AssociacaoUsuarioPerfis.Where(g => g.PerfilId == perfilId)
                                    .AsQueryable<AssociacaoUsuarioPerfil>();
        }
    }
}