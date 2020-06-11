using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.Framework.Log.Bases
{
    /// <summary>
    /// Classe business preparada para implementação de log operacional
    /// </summary>
    public class BaseLog
    {
        /// <summary>
        /// Contém um grupo de informações necessárias para geração de log operacional
        /// </summary>
        /// <returns>Objeto com log operacional</returns>
        public object InfoLogOperacional { get; set; }
    }
}
