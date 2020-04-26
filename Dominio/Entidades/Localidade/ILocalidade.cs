using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Localidades
{
    public interface ILocalidade
    {
        int Id { get; set; } 

        string Name { get; set; }

        string Code { get; set; } 
    }
}