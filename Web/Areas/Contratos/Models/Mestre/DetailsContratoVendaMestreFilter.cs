using System;

using Dominio.Entidades.Contrato;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;
using System.Text.Encodings.Web;
using System.Web;
using Sicle.Logs.Extensions;

namespace Sicle.Web.Areas.Contratos.Models
{

    public class DetailsContratoVendaMestreFilter
    {
        public long Id { get; set; }
     
        public string SortOrder { get; set; }       

        public int? PageNumber { get; set; }

        private ViewDataDictionary ViewData { get; set; }

        public DetailsContratoVendaMestreFilter()
        {

        }

        public void SetViewData(ViewDataDictionary data)
        {
            this.ViewData = data;
        }

       
        public IQueryable<SaleContract> DoFilter(IQueryable<SaleContract> query)
        {
            query = Sort(query);

            Save();

            return query;
        }       

        internal IQueryable<SaleContract> Sort(IQueryable<SaleContract> query)
        {
            switch (SortOrder)
            {
                case "id_asc":
                    return query.OrderBy(s => s.Id);

                case "id_desc":
                    return query.OrderByDescending(s => s.Id);

                case "nome_asc":
                    return query.OrderBy(s => s.Name);

                case "nome_desc":
                    return query.OrderByDescending(s => s.Name);

                default: // inicio_desc
                    return query.OrderByDescending(s => s.Id);

            }
        }

        public void Save()
        {   
            ViewData["CurrentSort"] = SortOrder;
            ViewData["IdSortParm"] = SortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewData["NomeSortParm"] = SortOrder == "nome_asc" ? "nome_desc" : "nome_asc";
        }
    }
}