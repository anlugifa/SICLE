using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados.Repository.Base;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repository
{
    public class ConfiguracaoRepository : BaseRepository<Configuracao, String>
    {
        public ConfiguracaoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override Configuracao Get(String id)
        {
            return _context.Configuracoes.First(o => o.Code.Equals(id));
        }

        public override String GetPkValue(Configuracao entity)
        {
            return typeof(Configuracao).GetProperty("Code").GetValue(entity).ToString();
        }
    }
}