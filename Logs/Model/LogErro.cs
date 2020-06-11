using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


using Sicle.Logs.Model.Base;
using Sicle.Logs.Utils.CustomAnnotation;

namespace Sicle.Logs.Model
{
    /// <summary>
    /// Classe entidade de Log de Erro
    /// </summary>
    [DataContract]
    public class LogErro : LogBase
    {
        [DataMember]
        [StringLengthRaizen(400)]
        public String InnerException { get; set; }

        [DataMember]
        [StringLengthRaizen(2000)]
        public String StackTrace { get; set; }

        [DataMember]
        [StringLengthRaizen(100)]
        public String Message { get; set; }

        public ErrorType ErrorType {get; set; }
    }

}