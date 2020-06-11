using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using Sicle.Logs.Config;
using Sicle.Logs.Model;

namespace Sicle.Logs.DAL
{
    public class LogDBContext : DbContext
    {
        private IConfiguration Configuration;

        public LogDBContext() : base()
        {           
           var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            this.Configuration = builder.Build();
        }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Configuration.GetConnectionString("LogContext");     
            
            optionsBuilder.UseOracle(connString, b =>
                    b.UseOracleSQLCompatibility("11")
            );

            if (Configuration.GetValue("Environment", "DEV").Equals("DEV"))
            {                  
                ILoggerFactory factory = new LoggerFactory(new[] { 
                            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()  });

                optionsBuilder.UseLoggerFactory(factory).EnableSensitiveDataLogging();                
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {            
            ConfigError.Config(model);
        }

        public DbSet<LogErro> LogErros { get; set; }       
    }
}
