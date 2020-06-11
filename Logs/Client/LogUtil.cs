using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Raizen.Framework.Log.Bases;
using Raizen.Framework.Utils.Extensions;
using Sicle.Logs.Bases;

namespace Sicle.Logs.Client
{
    /// <summary>
    /// Classe utilitária para o cliente de geração do Log4Net
    /// </summary>
    internal static class LogUtil
    {
        /// <summary>
        /// Trata e loga uma exceção ocorrida dentro do escopo de execução do cliente Log4Net
        /// </summary>
        /// <param name="ex">Exceção a ser tratada</param>
        /// <param name="mensagem">[OPCIONAL] Mensagem a ser adicionada aos detalhes do log</param>
        /// <remarks>
        /// Este tratamento utiliza o mecanismo de log de contingência para escrever o erro, o que
        /// garante que não será utilizado o caminho "normal" (que justamente pode estar em situação
        /// de erro). Se usarmos o caminho "normal" para tratamento deste erro, arriscamos entrar em
        /// um loop infinito
        /// </remarks>
        public static void TratarErroClienteLog4Net(Exception ex, string mensagem = "")
        {
            var rex = ex as SicleException;

            if (rex != null)
            {
                if (String.IsNullOrEmpty(mensagem))
                    // Não recebemos mensagem customizada. Utiliza a própria mensagem da exceção
                    mensagem = rex.Message;
                else
                    // Recebemos uma mensagem customizada. Concatenamos com a mensagem já existente na exceção
                    mensagem = string.Format("{0} {1}", mensagem.Trim(), rex.Message);

                // Precisamos criar uma nova instância de RaizenException, para conseguirmos setar a mensagem customizada
                var rexcust = new SicleException(mensagem, rex.InnerException);

                // Loga erro em contingência
                rexcust.LogarErroContingencia();
            }
            else
            {
                // Gera uma nova instância do RaizenException, para que seja possível logar a contingência
                new SicleException(mensagem, ex).LogarErroContingencia();
            }
        }
    }
}
