using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Localidade
{
    public class SAPEnv
    {
        public static SAPEnv P72 = new SAPEnv("Combustíveis", "FUELS", "O", "01", "R$", "CCAO", "00");
        public static SAPEnv EAB = new SAPEnv("Energia", "EAB", "SL", "SX", "BRL", "RAIZ", "YS");

        public String Name {get; set;}
        public String PiCode {get; set;}
        public String DistributionChannel {get; set;}
        public String DivisionSales {get; set;}
        public String Moeda {get; set;}
        public String CreditArea {get; set;}
        public String CodRejeicao {get; set;}

        public SAPEnv(String name, String pi, String dc, String ds, String moeda, String credit, String codRej)
        {
            this.Name = name;
            this.PiCode = pi;
            this.DistributionChannel = dc;
            this.DivisionSales = ds;
            this.Moeda = moeda;
            this.CreditArea = credit;
            this.CodRejeicao = codRej;
        }
       
    }
}