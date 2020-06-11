using System;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Sicle.Logs.BLL.Base;
using Sicle.Logs.Model;
using System.ComponentModel.DataAnnotations;
using Sicle.Logs.Bases;
using System.Threading.Tasks;
using Sicle.Logs.Extensions;
using Sicle.Logs.Utils.CustomAnnotation;

namespace Sicle.Logs.BLL
{
    /// <summary>
    /// Classe de negócios para geração de Log de Erro em banco de dados
    /// </summary>
    internal class LogErroBusiness : LogBusinessBase<LogErro>
    {
        /// <summary>
        /// Verifica se o campo Message do log de erro excede o valor máximo definido para este campo.
        /// Caso exceda, concatena o conteúdo do campo com o conteúdo da InnerException, e adiciona uma
        /// mensagem informativa solicitando que seja verificado este campo. Com isso, evitamos que
        /// informações sejam perdidas, já que o campo InnerException no banco de dados suporta até
        /// 2 GB de informações
        /// </summary>
        /// <param name="logErro">Instância do log de erro a ser verificado</param>
        private void VerificarCampoMensagem(LogErro logErro)
        {
            if (logErro != null && !logErro.Message.IsNullOrWhiteSpace())
            {
                // Valor default do tamanho do campo Message
                var maxStringLength = 500;

                // Obtemos o atributo StringLengthRaizen da propriedade Message
                var maxStringLengthAttribute = logErro.GetCustomAttribute<LogErro, StringLengthRaizen, string>(i => i.Message);
                if (maxStringLengthAttribute != null)
                {
                    // O atributo existe. Usamos o valor definido para ele
                    maxStringLength = maxStringLengthAttribute.MaximumLength;
                }

                // O tamanho da mensagem excede o máximo permitido?
                if (logErro.Message.Length > maxStringLength)
                {
                    // Nesta situação, concatenamos a mensagem atual no início da mensagem de InnerException
                    // e informamos que é necessário verificar os detalhes da InnerException
                    var sb = new StringBuilder();

                    // Evita linhas em branco
                    if (logErro.InnerException.IsNullOrWhiteSpace())
                    {
                        sb.Append(logErro.Message);
                    }
                    else
                    {
                        sb.AppendLine(logErro.Message);
                        sb.Append(logErro.InnerException);
                    }
                    logErro.InnerException = sb.ToString();
                    logErro.Message = "Framework Raizen: Dados transferidos para a InnerException. Verificar este campo para mais detalhes.";
                }
            }
        }

        /// <summary>
        /// Adiciona um log de erro
        /// </summary>
        /// <param name="logErro">Dados do erro</param>
        /// <returns>Flag indicando se a operação foi bem sucedida (true) ou não (false)</returns>
        internal Task<bool> AdicionarLogErroClient(LogErro logErro)
        {
            if (logErro == null)
                throw new SicleException("Objeto de Log Erro Nulo");

            VerificarCampoMensagem(logErro);
            
            return base.Adicionar(logErro);
        }

        /// <summary>
        /// Realiza busca de registros de log de erro
        /// </summary>
        /// <param name="where">Expressão lambda a ser usada na busca</param>
        /// <returns>Lista de registros de log de erro que atendem a expressão especificada</returns>
        internal List<LogErro> PesquisarLogErro(Expression<Func<LogErro, bool>> where)
        {
            return base.Listar(where);
        }     
    }
}