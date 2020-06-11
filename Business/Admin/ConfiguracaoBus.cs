using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades;
using System.Linq;
using Dominio.Entidades.Infra;
using Sicle.Logs.Util;

namespace Sicle.Business.Admin
{
    public class ConfiguracaoBus : SicleBusiness<Configuracao>
    {
        public ConfiguracaoBus()
        {            
        }
        
        public Configuracao Get(String code)
        {
            using (var repo = new BaseRepository<Configuracao>())
            {
                return repo.AsQueryable().First(o => o.Code.Equals(code));
            }
        }

        public void Delete(string key)
        {
            using (var repo = new BaseRepository<Configuracao>())
            {
                var conf = repo.AsQueryable().First(p => p.Code.Equals(key));
                if (conf != null)
                    repo.Delete(conf);
            }
        }

        public override Configuracao MergeFromDB(Configuracao localCopy)
        {
            var objFromDB = Get(localCopy.Code);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Code +
                    " NOT FOUND FOR ENTITY: Configuracao");


            objFromDB.Code = localCopy.Code;
            objFromDB.Value = localCopy.Value;
            
            return objFromDB;
        }
    }
}
