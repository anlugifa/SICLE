using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Localidades
{
    public class Regiao : Localidade
    {
        public Regiao(String code)
        {
            this.Code = code;
            this.Tipo = TipoLocalidade.R;
        }       
    }
}
