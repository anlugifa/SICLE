using System;
using System.Threading.Tasks;
using log4net.Appender;
using Sicle.Logs.Bases;
using Sicle.Logs.Model;

namespace Sicle.Logs.Client
{
    /// <summary>
    /// Classe appender do Log4Net para gerar log em banco de dados no modelo do framework
    /// </summary>
    /// ATENÇÃO: nesta classe não podemos utilizar o método "LogarErro", pois isso causaria um loop infinito
    /// em cenários de falha! Usar sempre o método LogUtil.TratarErroClientLog4Net, que foi escrito especificamente
    /// para tratamento de erros no próprio cliente do Log4Net
    internal class LogErroAppender : AppenderSkeleton
    {
        /// <summary>
        /// Ocorre quando o log4Net é acionado para realizar operações de log
        /// </summary>
        /// <param name="loggingEvent"></param>
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            try
            {
                if (loggingEvent.LoggerName.ToString().Equals("LogRaizen4Net"))
                {
                    LogErro erro = loggingEvent.MessageObject as LogErro;

                    if (erro == null)
                        throw new SicleException("Objeto de Erro dentro do MessageObject está nulo ou não é do tipo LogErro no momento da gravação do log!");

                    Logger.GerarLogErro(erro);
                }
                else
                {
                    throw new SicleException("Appender não encontrado!");
                }
            }
            catch (Exception ex)
            {
                LogUtil.TratarErroClienteLog4Net(ex, "Appender Log Raízen:");
            }
        }  
    }
}