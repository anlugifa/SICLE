using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


using Sicle.Logs.Model.Base;

namespace Sicle.Logs.Model
{
    /// <summary>
    /// Classe entidade de Log de Erro
    /// </summary>
    [DataContract]
    public class LogErro : LogBase
    {
        [DataMember]
        [MaxLength(400)]
        public String InnerException { get; set; }

        [DataMember]
        [MaxLength(2000)]
        public String StackTrace { get; set; }

        [DataMember]
        [MaxLength(100)]
        public String Message { get; set; }

        public ErrorType ErrorType {get; set; }
    }

}