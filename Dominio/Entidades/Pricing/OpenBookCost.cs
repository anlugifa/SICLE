using System;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Acesso;

namespace Dominio.Entidades.Contrato
{
    public class OpenBookCost
    {
        public long Id { get; set; }

        public long ParentRuleId { get; set; }

        [Required]
        [MaxLength(30)]
        public String Name { get; set; }

        public double Quantidade { get; set; }
        public double TaxaFiscal { get; set; }
        public double Afrmm { get; set; }
        public double QuantidadeBl { get; set; }
        public double TaxaFiscalBl { get; set; }
        public double AfrmmBl { get; set; }
        public double Demurrage { get; set; }
        public double TotalCost { get; set; }
        
        public double Dap { get; set; }
        public double DapBl { get; set; }
        public double Tup { get; set; }
        public double TupBl { get; set; }
        public double Sop { get; set; }
        public double SopBl { get; set; }

        public double II { get; set; }
        public double IIBl { get; set; }

        public double Ipi { get; set; }
        public double IpiBl { get; set; }

        public double Cide { get; set; }
        public double CideBl { get; set; }

        public double MultaCide { get; set; }
        public double MultaCideBl { get; set; }

        public double JurosCide { get; set; }
        public double JurosCideBl { get; set; }

        public double Pis { get; set; }
        public double PisBl { get; set; }
        public double MultaPis { get; set; }
        public double MultaPisBl { get; set; }
        public double JurosPis { get; set; }
        public double JurosPisBl { get; set; }

        public double Cofins { get; set; }
        public double CofinsBl { get; set; }
        public double MultaCofins { get; set; }
        public double MultaCofinsBl { get; set; }
        public double JurosCofins { get; set; }
        public double JurosCofinsBl { get; set; }

        public double IcmsProp { get; set; }
        public double IcmsPropBl { get; set; }

        public double IcmsST { get; set; }
        public double icmsSTBl { get; set; }

        public double TaxIcms { get; set; }
        public double TaxIcmsBl { get; set; }

        public double Despachante { get; set; }
        public double DespachanteBl { get; set; }

        public double Descarga { get; set; }
        public double DescargaBl { get; set; }

        public double Aduaneiro { get; set; }
        public double AduaneiroBl { get; set; }

        public double Di { get; set; }
        public double DiBl { get; set; }

        public double IOF { get; set; }
        public double IOFBl { get; set; }

        public double HonDespachante { get; set; }
        public double HonInspetor { get; set; }

        public double Sgs { get; set; }
        public double TaxLiber { get; set; }

        public double SisComex { get; set; }
        public double Liber { get; set; }
        public double Armazenagem { get; set; }

        public DateTime ChangeDate { get; set; }

        public String FilePath { get; set; }
        public String FileName { get; set; } 

        public Usuario User { get; set; }
    }
}
