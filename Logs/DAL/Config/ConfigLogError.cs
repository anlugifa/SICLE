using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Sicle.Logs.Model;

namespace Sicle.Logs.Config
{
    internal class ConfigError
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<LogErro>(t =>
            {
                t.ToTable("TB_ERROR");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("ID") //.UseOracleIdentityColumn();
                                        .ValueGeneratedOnAdd()
                                        .ForOracleUseSequenceHiLo("SEQ_TB_ERROR");

                t.Property(p => p.Message).HasColumnName("MESSAGE");
                t.Property(p => p.InnerException).HasColumnName("INNEREXCEPTION");
                t.Property(p => p.StackTrace).HasColumnName("STACKTRACE");
                t.Property(p => p.DateOccurrence).HasColumnName("OCCURRENCE");
                t.Property(p => p.Username).HasColumnName("USERNAME");
                t.Property(p => p.ErrorType).HasColumnName("ERRORTYPE");
            });
        }

    }
}
