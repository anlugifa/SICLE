#nullable disable
using System;

namespace Dominio.Entidades
{
    public class Configuracao : Dominio.Base.BaseEntity
    {
        public String Code { get; set; }

        public String Value { get; set; }
    }
}