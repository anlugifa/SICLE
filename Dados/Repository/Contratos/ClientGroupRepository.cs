using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados.Repository.Base;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repository
{
    public class ClientGroupRepository : BaseRepository<ClientGroup, long>
    {
        public ClientGroupRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override ClientGroup Get(long id)
        {
            return _context.ClientGroups.First(o => o.Id == id);
        }

        public override long GetPkValue(ClientGroup entity)
        {
            return (long)typeof(ClientGroup).GetProperty("Id").GetValue(entity);
        }        
    }
}