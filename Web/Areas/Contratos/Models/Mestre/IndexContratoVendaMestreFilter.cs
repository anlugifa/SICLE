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
    internal class CurrentFilter
    {
        public string Nickname { get; set; }
        public ContractStatus? Status { get; set; }
    }

    public class IndexContratoVendaMestreFilter
    {
        public string SearchNickname { get; set; }
        public ContractStatus? SearchStatus { get; set; }

        public string CurrentFilter { get; set; }
        public string SortOrder { get; set; }
        public string IdSortParm { get; set; }
        public string NomeSortParm { get; set; }

        public int? PageNumber { get; set; }

        private ViewDataDictionary ViewData { get; set; }

        public IndexContratoVendaMestreFilter()
        {

        }

        public void SetViewData(ViewDataDictionary data)
        {
            this.ViewData = data;
        }

        public string GetCurrentFilter()
        {
            if (SearchNickname.IsNullOrWhiteSpace() && !SearchStatus.HasValue)
            {
                return String.Empty;
            }

            var filter = new CurrentFilter();
            filter.Nickname = SearchNickname;
            filter.Status = SearchStatus;

            return JsonSerializer.Serialize(filter);
        }

        internal CurrentFilter GetCurrentFilter(string json)
        {
            return JsonSerializer.Deserialize<CurrentFilter>(json);
        }

        public IQueryable<ContratoVendaMestre> DoFilter(IQueryable<ContratoVendaMestre> query)
        {
            HandleOnSorting();

            query = QueryNickname(query);
            query = QueryStatus(query);
            query = Sort(query);

            Save();

            return query;
        }

        internal void HandleOnSorting()
        {
            //var CurrentFilter = ViewData["CurrentFilter"] as String;

            // when ordering
            if (!String.IsNullOrEmpty(CurrentFilter))
            {
                var actualFilter = GetCurrentFilter(CurrentFilter);

                this.SearchNickname = actualFilter.Nickname;
                this.SearchStatus = actualFilter.Status;
            }
        }


        internal IQueryable<ContratoVendaMestre> QueryNickname(IQueryable<ContratoVendaMestre> query)
        {
            if (!String.IsNullOrEmpty(SearchNickname))
            {
                query = query.Where(s => s.Nickname.Contains(SearchNickname));
            }

            return query;
        }

        internal IQueryable<ContratoVendaMestre> QueryStatus(IQueryable<ContratoVendaMestre> query)
        {
            if (SearchStatus != null && SearchStatus > 0)
            {
                query = query.Where(s => s.Contratos.Any(c => c.Status == SearchStatus));
            }

            return query;
        }

        internal IQueryable<ContratoVendaMestre> Sort(IQueryable<ContratoVendaMestre> query)
        {
            switch (SortOrder)
            {
                case "id_asc":
                    return query.OrderBy(s => s.Id);

                case "id_desc":
                    return query.OrderByDescending(s => s.Id);

                case "apelido_asc":
                    return query.OrderBy(s => s.Nickname);

                case "apelido_desc":
                    return query.OrderByDescending(s => s.Nickname);

                default: // inicio_desc
                    return query.OrderByDescending(s => s.Id);

            }
        }

        public void Save()
        {
            ViewData["CurrentFilter"] = GetCurrentFilter();

            ViewData["SearchNickname"] = SearchNickname;
            ViewData["SearchStatus"] = SearchStatus;

            ViewData["CurrentSort"] = SortOrder;
            ViewData["ContratoIdSortParm"] = SortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewData["ApelidoSortParm"] = SortOrder == "apelido_asc" ? "apelido_desc" : "apelido_asc";
        }
    }
}