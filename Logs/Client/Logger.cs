using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sicle.Logs.BLL;
using Sicle.Logs.Model;

namespace Sicle.Logs.Client
{
    /// <summary>
    /// Classe cliente para a geração de Log (Erro e Operacional) em banco de dados
    /// </summary>
    /// <remarks>
    /// ATENÇÃO: nesta classe não podemos utilizar o método "LogarErro", pois isso causaria um loop infinito
    /// em cenários de falha! Usar sempre o método LogUtil.TratarErroClientLog4Net, que foi escrito especificamente
    /// para tratamento de erros no próprio cliente do Log4Net
    /// </remarks>
    public static class Logger
    {
        #region Variáveis de Classe

        private static LogErroBusiness logErroClient = new LogErroBusiness();
       
        #endregion

        #region Log Operacional

        /// <summary>
        /// Cria objeto de log operacional com os dados básicos do front end
        /// </summary>
        /// <param name="idModulo">Id do modulo</param>
        /// <param name="idPagina">Id da página</param>
        /// <returns>Instância do log operacional com os dados de Front End preenchidos</returns>
        public static LogOperacional InstanciarLogOperacionalFrontEnd()
        {
            LogOperacional infoLogOperacional = new LogOperacional();            
              
            // Preenche informações específicas do log operacional          
            infoLogOperacional.DateOccurrence = DateTime.Now;             

            return infoLogOperacional;
        }

       
    
        #endregion

        #region Log de Erro

        /// <summary>
        /// Realiza operação polimórfica no appender do Log4Net
        /// </summary>
        /// <param name="logErro">Contém o objeto de log</param>
        public static async Task<bool> LogError(String message, String username)
        {
            return await Log(message, username, ErrorType.ERROR);
        }

        /// <summary>
        /// Realiza operação polimórfica no appender do Log4Net
        /// </summary>
        /// <param name="logErro">Contém o objeto de log</param>
        public static async Task<bool> Log(String message, String username, ErrorType type)
        {
            return await GerarLogErro(new LogErro(){
                Message = message,
                ErrorType = type,
                Username = username,
                DateOccurrence = DateTime.Now,
            });
        }
        


        /// <summary>
        /// Gera/Adiciona um item à tabela de Log de Erro
        /// </summary>
        /// <param name="logCorrente">Dados de erro a serem adicionados</param>
        /// <returns>Flag indicando se a operação foi bem sucedida (true) ou não (false)</returns>
        public static async Task<bool> GerarLogErro(LogErro logCorrente)
        {
            try
            {
                return await logErroClient.AdicionarLogErroClient(logCorrente);
            }
            catch (Exception ex)
            {
                LogUtil.TratarErroClienteLog4Net(ex, "Erro no método GerarLogErro");
            }

            return false;
        }

        /// <summary>
        /// Realiza busca de registros de log de erro
        /// </summary>
        /// <param name="where">Expressão lambda a ser usada na busca</param>
        /// <returns>Lista de registros de log de erro que atendem a expressão especificada</returns>
        public static List<LogErro> PesquisarLogErro(Expression<Func<LogErro, bool>> where)
        {
            try
            {
                return logErroClient.PesquisarLogErro(where);
            }
            catch (Exception ex)
            {
                LogUtil.TratarErroClienteLog4Net(ex, "Erro no método PesquisarLogErro");
            }

            return null;
        }


        #endregion
    }
}
