using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Util
{
    public class AppLooger
    {
        private static ILoggerFactory _factory = null;

        public static ILoggerFactory Factory 
        { 
            get
            {
                if (_factory == null)
                {
                    _factory = LoggerFactory.Create(builder =>
                    {
                        builder
                            .AddFilter((category, level) =>
                                category == DbLoggerCategory.Database.Command.Name
                                && level == LogLevel.Information).AddConsole();
                    });
                }
                return _factory;
            }
        }

        public static ILogger CreateLogger(String name) => Factory.CreateLogger(name);
    }   
}
