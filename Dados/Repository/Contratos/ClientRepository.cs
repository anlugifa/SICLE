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
    public class ClientRepository : BaseRepository<Client, int>
    {
        public ClientRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override Client Get(int id)
        {
            return _context.Clients.First(o => o.Id == id);
        }

        public override int GetPkValue(Client entity)
        {
            return (int)typeof(Client).GetProperty("Id").GetValue(entity);
        }        
    }
}