using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Localidades
{
    public class Company
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String CodeSys { get; set; }
        public String CodeSap { get; set; }
        public SAPEnvType SAPEnv { get; set; }
    }
}
