using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security.Permissions;

using System.Runtime.Serialization;
using Sicle.Logs.Model;
using Sicle.Logs.Client;

namespace Sicle.Logs.Bases
{
    /// <summary>
    /// Classe customizada de erro do framework da Raizen
    /// Utilizada para capturar exception's e gerar log em um local centralizado
    /// Também pode ser utilizada em serviços SOA utilizando WCF, pois é serializável
    /// </summary>
    [Serializable]
    public class SicleException : Exception, ISerializable
    {
        #region Constantes

        private const string MSG_ERRO_GENERICO_TRATADO_FRAMEWORK = "Erro genérico tratado pelo Framework Raizen";
        private const string RESOURCE_REFERENCE_PROPERTY = "ResourceReferenceProperty";

        #endregion

        #region Propriedades

        private string _message;
        /// <summary>
        /// Mensagem customizada da exceção
        /// </summary>
        public override string Message
        {
            get { return _message; }
        }

        /// <summary>
        /// Identificador do mecanismo responsável pela serialização dos dados
        /// </summary>
        public string ResourceReferenceProperty { get; set; }

        #endregion

        #region Construtores

        public SicleException() : base() { }

        public SicleException(string message) : base(message)
        {
            _message = message;
        }

        public SicleException(string message, Exception innerException) : base(message, innerException)
        {
            _message = message;
        }

        protected SicleException(SerializationInfo info, StreamingContext context): base(info, context)
        {
            ResourceReferenceProperty = info.GetString(RESOURCE_REFERENCE_PROPERTY);
            _message = MSG_ERRO_GENERICO_TRATADO_FRAMEWORK;
        }

        #endregion

        #region Métodos Públicos

        #region Override GetObjectData (ISerializable)

        /// <summary>
        /// Override do método de serialização
        /// </summary>
        /// <param name="info">Informações para serialização dos dados</param>
        /// <param name="context">Contexto do streaming de dados</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue(RESOURCE_REFERENCE_PROPERTY, ResourceReferenceProperty);
            base.GetObjectData(info, context);
        }

        #endregion

        #region LogarErro

        /// <summary>
        /// Efetua log de erro, capturando todos os dados de cliente e backend disponíveis.
        /// </summary>
        /// <param name="nivelCaptura">[OPCIONAL] Nível de captura do log, baseado na pilha de execução. Valor padrão: 3</param>
        public void LogarErro(int nivelCaptura = 3)
        {
            try
            {
                LogErro logErro = new LogErro();

                // Captura dados (disponíveis) de informação do client
                // BackEndInformation.CapturarDadosClientErroLog(logErro);

                this.LogarErro(logErro, nivelCaptura, null);
            }
            catch (Exception ex)
            {
                var rex = new SicleException("Erro no Método LogarErro (public nivel)", ex);
                rex.LogarErroContingencia();
            }
        }

        /// <summary>
        /// Efetua log de erro, capturando todos os dados de cliente e backend disponíveis.
        /// </summary>
        /// <param name="nomeModulo">Nome do módulo cuja captura ocorrerá (considera método mais externo)</param>
        public void LogarErro(string nomeModulo)
        {
            try
            {
                LogErro logErro = new LogErro();

                // Captura dados (disponíveis) de informação do client
                // BackEndInformation.CapturarDadosClientErroLog(logErro);

                this.LogarErro(logErro, 0, nomeModulo);
            }
            catch (Exception ex)
            {
                var rex = new SicleException("Erro no Método LogarErro (public modulo)", ex);
                rex.LogarErroContingencia();
            }
        }

        /// <summary>
        /// Efetua log de erro, utilizando dados de cliente já capturados, e preenchendo apenas dados de backend disponíveis, baseado no nome do módulo desejado.
        /// </summary>
        /// <param name="logErro">Dados de erro, com informações de client pré preenchidos</param>
        /// <param name="nomeModulo">Nome do módulo cuja captura ocorrerá (considera método mais externo)</param>
        public void LogarErro(LogErro logErro, string nomeModulo)
        {
            this.LogarErro(logErro, 0, nomeModulo);
        }

        /// <summary>
        /// Efetua log de erro, utilizando dados de cliente já capturados, e preenchendo apenas dados de backend disponíveis, baseado no nível de captura desejado.
        /// </summary>
        /// <param name="logErro">Dados de erro, com informações de client pré preenchidos</param>
        /// <param name="nivelCaptura">[OPCIONAL] Nível de captura do log, baseado na pilha de execução. Valor padrão: 3</param>
        public void LogarErro(LogErro logErro, int nivelCaptura = 3)
        {
            this.LogarErro(logErro, nivelCaptura, null);
        }

        /// <summary>
        /// Método privado para geração de log de erro
        /// </summary>
        /// <param name="logErro">Dados de erro, com informações de client pré preenchidos</param>
        /// <param name="nivelCaptura">Nível de captura do log, baseado na pilha de execução</param>
        /// <param name="nomeModulo">Nome do módulo cuja captura ocorrerá (considera método mais externo)</param>
        private void LogarErro(LogErro logErro, int nivelCaptura, string nomeModulo)
        {
            try
            {
                // Timestamp da ocorrência do erro
                logErro.DateOccurrence = DateTime.Now;

                logErro.InnerException = this.GetInnerException();
                logErro.StackTrace = this.GetStackTrace();
                logErro.Message = this.GetMessage();
                logErro.ErrorType = ErrorType.ERROR;
                
                Log4Net.Logger(logErro);
            }
            catch (Exception ex)
            {
                var rex = new SicleException("Erro no Método LogarErro (private)", ex);
                rex.LogarErroContingencia();
            }
        }

        #endregion

        #endregion

        #region Métodos Protegidos

        #region GetInnerException

        /// <summary>
        /// Retorna o InnerException tratado, incluindo a própria instância de exceção
        /// </summary>
        /// <returns>String com o InnerException</returns>
        public virtual string GetInnerException()
        {
            return GetInnerExceptionResursive(this);
        }

        /// <summary>
        /// Retorna o InnerException tratado, executando a leitura recursiva das exceções
        /// </summary>
        /// <param name="inner">Exceção inicial cujas InnerExceptions serão lidas recursivamente</param>
        /// <param name="depth">[OPCIONAL] Nível da exceção. Usado apenas pelo próprio método de recursão. Para a primeira chamada, manter o valor padrão = 0</param>
        /// <returns>String com as InnerExceptions formatadas em texto, no formato de pilha (nivel crescente bottom up)</returns>
        protected string GetInnerExceptionResursive(Exception inner, int depth = 0)
        {
            // Só segue se há o que tratar
            if (inner == null) return null;

            // Mensagem de retorno
            var message = new StringBuilder();

            // Incrementa o nível
            depth++;

            // Fazemos a chamada recursiva em primeiro lugar, para garantirmos que as exceções
            // serão exibidas em formato de pilha (menor para o maior níveis)
            var innerText = GetInnerExceptionResursive(inner.InnerException, depth);
            if (!String.IsNullOrWhiteSpace(innerText))
                message.AppendLine(innerText);

            // Trata nível atual
            message.AppendFormat("Depth: {0}\n", depth);
            message.AppendFormat("Type: {0}\n", inner.GetType().FullName);
            message.AppendFormat("Message: {0}\n", inner.Message);
            if (depth > 1)
                message.AppendLine("---------------------");

            return message.ToString().TrimEnd();
        }

        #endregion

        #region GetStackTrace

        /// <summary>
        /// Retorna o StackTrace tratado
        /// </summary>
        /// <returns>string com o StackTrace</returns>
        protected virtual string GetStackTrace()
        {
            if (!string.IsNullOrEmpty(this.StackTrace))
            {
                return this.StackTrace;
            }
            if (this.InnerException != null && !string.IsNullOrEmpty(this.InnerException.StackTrace))
            {
                return this.InnerException.StackTrace;
            }
            return null;
        }

        #endregion

        #region GetMessage

        /// <summary>
        /// Retorna o message tratado do erro
        /// </summary>
        /// <returns>string com o Message</returns>
        protected virtual string GetMessage()
        {
            if (!string.IsNullOrEmpty(this.Message))
            {
                return this.Message;
            }
            if (this.InnerException != null && !string.IsNullOrEmpty(this.InnerException.Message))
            {
                return this.InnerException.Message;
            }
            return null;
        }

        #endregion

        #endregion

        #region Métodos Privados/Internos

        #region LogarErroContigencia
        
        /// <summary>
        /// Realiza a gravação do erro em um local de contigência, utilizado quando o método LogarErro está falhando
        /// </summary>
        internal void LogarErroContingencia()
        {
            try
            {
                var sb = new StringBuilder();

                sb.AppendLine("Erro de contingência do próprio Logger");
                sb.Append("Message: ");
                sb.AppendLine(GetMessage() ?? "Sem informações de Message");
                sb.Append("Inner Exception: ");
                sb.AppendLine(GetInnerException() ?? "Sem informações de Inner Exception");
                sb.Append("Stack Trace: ");
                sb.AppendLine(GetStackTrace() ?? "Sem informações de StackTrace");

                Log4Net.LoggerFile(null, sb.ToString());
            }
            finally
            {
                // Se chegamos nesta situação, não há o que fazer. Já estamos logando um erro no próprio
                // mecanismo de log, em caráter de contingência
            }
        }

        #endregion

        #endregion
    }
}