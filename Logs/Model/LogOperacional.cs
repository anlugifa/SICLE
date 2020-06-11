using System;
using System.Runtime.Serialization;

using Sicle.Logs.Model.Base;

namespace Sicle.Logs.Model
{
    /// <summary>
    /// Classe entidade de Log Operacional
    /// </summary>
    [DataContract]
    public class LogOperacional : LogBase
    {        
        [DataMember]
        public String BackEndObjectJson { get; set; }
      
        [DataMember]
        public String Description { get; set; }

        [DataMember]
        public String ComputerName { get; set; }
    }
}