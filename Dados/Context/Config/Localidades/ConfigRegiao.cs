using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidade;
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
                t.ToTable("TP_LOCALIDADE");
            });
        }
    }
}
