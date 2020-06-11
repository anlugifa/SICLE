using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sicle.Logs.Utils.CustomAnnotation
{
    /// <summary>
    /// Classe de DataAnnotation customizada para adicionar flag indicativo de truncar valor de string
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class StringLengthRaizen : System.ComponentModel.DataAnnotations.StringLengthAttribute
    {
        public StringLengthRaizen(int maximumLength) : base(maximumLength) { }
        public bool TruncateIfStringLengthExceeded { get; set; }
    }
}