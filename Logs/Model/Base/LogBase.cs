using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Raizen.Framework.Utils.Extensions;

namespace Sicle.Logs.Model.Base
{
    /// <summary>
    /// Classe base com atributos comuns para model de Log (Erro e Operacional)
    /// </summary>
    [DataContract]
    public abstract class LogBase
    {
        [DataMember]
        public virtual long Id { get; set; }
      
        [DataMember]
        public virtual String Username { get; set; }

        // O valor inicial para data de ocorrência é a data/hora atual
        // Assim, garantimos que nos casos onde não seja informado um valor específico, vamos
        // registrar corretamente a data de ocorrência do log
        private DateTime _dateOccurrence = DateTime.Now;
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]    
        [DataMember]
        public virtual DateTime DateOccurrence
        {
            get
            {
                // Temos que garantir que a data será compatível com a data mínima
                // suportada pelo tipo DATETIME do Sql Server
                return _dateOccurrence.ToSqlServerCompatible();
            }
            set
            {
                _dateOccurrence = value;
            }
        }       
    }
}
