
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using log4net;
using log4net.Repository;
using Sicle.Logs.Model;

namespace Sicle.Logs.Client
{
    /// <summary>
    /// Classe que configura e carrega os providers e adapters utilizados com o log4net
    /// </summary>
    public static class Log4Net
    {        
        static ILog _logger = LogManager.GetLogger(Assembly.GetEntryAssembly(), "LogRaizen4Net");
        static ILog _loggerRollingFile = LogManager.GetLogger(Assembly.GetEntryAssembly(), "LogRollingFile");

        private static readonly ILog log = LogManager.GetLogger(typeof(Log4Net));

        private const string LOG_CONFIG_FILE = "Log4Net.config";
       
        /// <summary>
        /// Realiza operação polimórfica no appender do Log4Net
        /// </summary>
        /// <param name="logErro">Contém o objeto de log</param>
        public static void Logger(LogErro logErro)
        {           
            if (_logger != null)
            {
                _logger.Error(logErro);
            }

            if (_loggerRollingFile != null)
            {
                _loggerRollingFile.Error(FormatarErroLogArquivo(logErro));
            }
        }
        

        /// <summary>
        /// Realiza operação de log em arquivo .txt
        /// </summary>
        /// <param name="logErro">Contém o objeto de log</param>
        /// <param name="mensagem">Mensagem de erro</param>
        public static void LoggerFile(LogErro logErro = null, string mensagem = "")
        {
            string Erro = "";            

            if (logErro != null)
            {
                Erro = FormatarErroLogArquivo(logErro);
            }

            Erro += mensagem;

            if (_loggerRollingFile != null)
            {
                _loggerRollingFile.Error(Erro);
            }
        }       

        /// <summary>
        /// Formata as informações de log de erro para serem gravadas no arquivo txt 
        /// </summary>
        /// <param name="logErro">Contém o objeto de log</param>
        /// <returns>String com o erro formatado</returns>
        private static string FormatarErroLogArquivo(LogErro logErro)
        {
            StringBuilder builderErro = new StringBuilder();
            builderErro.AppendLine();
            

            if (!string.IsNullOrWhiteSpace(logErro.Username))
            {
                builderErro.Append("Username: " + logErro.Username);
                builderErro.AppendLine();
            }

            builderErro.Append("DateOccurrence: " + logErro.DateOccurrence.ToShortDateString());
            builderErro.AppendLine();
           
            if (!string.IsNullOrWhiteSpace(logErro.Message))
            {
                builderErro.Append("Message: " + logErro.Message ?? "Sem informações de Message");
                builderErro.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(logErro.InnerException))
            {
                builderErro.Append("InnerException: " + logErro.InnerException ?? "Sem informações de Inner Exception");
                builderErro.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(logErro.StackTrace))
            {
                builderErro.Append("StackTrace: " + logErro.StackTrace ?? "Sem informações de StackTrace");
                builderErro.AppendLine();
            }

            return builderErro.ToString();
        }
    }
}