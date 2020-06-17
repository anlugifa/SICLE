using System;
using Dominio.Entidades.Contrato;
using Sicle.Web.Util;
using Util;
using Dominio.Entidades.Acesso;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class ContratoVendaMestreModel
    {
        [Required]
        public long Id { get; set; }

        [Display(Name="Id:")]
        public String SicleId { get; set; }
        public String Farol { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage="Apelido é obrigatório.")]       
        [Display(Name="Apelido:")]
        public String Nickname { get; set; }
        public String EndorsementIcon { get; set; }
        public String StatusMestre { get; set; }
        public String EndossoMestre { get; set; }
        public String MinDate { get; set; }
        public String MaxDate { get; set; }
        public String TotalVolume { get; set; }

        [Display(Name="Observação:")]       
        public String Observation { get; set; }
        public String MaxVolume { get; set; }
        public Boolean IsActive { get; set; }

        [Display(Name="Criação:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        // [DateTimeModelBinder(DateFormat="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage="Data de Criação obrigatória.")]
        public DateTime? CreationDate { get; set; }       


        public long CreationUserId { get; set; }

        [Display(Name="Criado por:")]
        public Usuario CreationUser { get; set; }

        public ContratoVendaMestreModel()
        {
            
        }        

        public ContratoVendaMestreModel(MasterSaleContract mestre)
        {
            this.Id = mestre.Id;
            this.SicleId = mestre.ToString();
            this.Nickname = mestre.Nickname;
            this.Observation = mestre.Observation;
            this.IsActive = mestre.IsActive; 

            this.CreationDate = mestre.CreationDate;

            this.CreationUserId = mestre.CreationUserId;
            this.CreationUser = mestre.CreationUser;    
        }

        public static implicit operator MasterSaleContract(ContratoVendaMestreModel c)
        {
            return new MasterSaleContract()
            {
                Id = c.Id,
                Nickname = c.Nickname,
                Observation = c.Observation,
                IsActive = c.IsActive,
                CreationUserId = c.CreationUserId,
                CreationDate  = c.CreationDate.Value
            };
        }         
    }
}