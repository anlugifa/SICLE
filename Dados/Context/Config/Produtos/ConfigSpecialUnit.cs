using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Produtos
{
    public class ConfigSpecialUnit
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<SpecialUnit>(t =>
            {
                t.ToTable("TB_SPECIAL_UNIT");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("SEQ_SPECIAL_UNIT");
                t.Property(p => p.Name).HasColumnName("NAME");
                t.Property(p => p.Unit).HasColumnName("UNIT");
                t.Property(p => p.UnitES).HasColumnName("UNIT_E_S");
                t.Property(p => p.ConversionFactor).HasColumnName("CONVERSION_FACTOR"); 
                t.Property(p => p.UsePallet).HasColumnName("USE_PALLET"); 
                t.Property(p => p.PalletUnit).HasColumnName("PALLET_UNIT");
                t.Property(p => p.PalletMaterial).HasColumnName("PALLET_MATERIAL");         
                t.Property(p => p.PalletValue).HasColumnName("PALLET_VALUE"); 
                t.Property(p => p.PalletCapacity).HasColumnName("PALLET_CAPACITY"); 
                t.Property(p => p.PalletWeight).HasColumnName("PALLET_WEIGHT");
            });
        }
    }
}
