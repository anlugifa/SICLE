using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Localidades
{
    public class ConfigRegiao
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Regiao>(t =>
            {
                t.ToTable("TB_LOCALIDADES");
            });
        }
    }
}
