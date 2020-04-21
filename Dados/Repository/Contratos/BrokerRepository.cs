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
    public class BrokerRepository : BaseRepository<Broker, string>
    {
        public BrokerRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override Broker Get(string code)
        {
            return _context.Brokers.First(o => o.Code.Equals(code));
        }

        public override string GetPkValue(Broker entity)
        {
            return (string)typeof(Broker).GetProperty("Code").GetValue(entity);
        }        
    }
}