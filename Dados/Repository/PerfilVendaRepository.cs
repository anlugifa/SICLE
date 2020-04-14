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
    public class PerfilVendaRepository : BaseRepository<PerfilVenda, int>
    {
        public PerfilVendaRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override PerfilVenda Get(int id)
        {
            return _context.PerfisVendas.First(o => o.Id == id);
        }

        public override int GetPkValue(PerfilVenda entity)
        {
            return (int)typeof(PerfilVenda).GetProperty("Id").GetValue(entity);
        }

        public IQueryable<AssociacaoUsuarioPerfilVenda> GetAssociacaoUsuario(int perfilId)
        {
            return _context.AssociacaoUsuarioPerfilVendas.Where(g => g.PerfilVendaId == perfilId)
                                    .AsQueryable<AssociacaoUsuarioPerfilVenda>();
        }
    }
}