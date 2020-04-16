using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Localidade
{
    public class Company
    {
        public long Id {get; set;}
        public String Name {get; set;}
        public String CodeSys {get; set;}
        public String CodeSap {get; set;}
        public SAPEnv SAPEnv {get; set;}
    }
}
