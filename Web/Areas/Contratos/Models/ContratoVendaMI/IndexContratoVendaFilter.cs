using System;

using Dominio.Entidades.Contrato;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class IndexContratoVendaFilter
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public ContractStatus? Status { get; set; }
        public long? ProductGroupId { get; set; }

        public string ClientGroupName { get; set; }
        public long? ClientGroupId { get; set; }
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }

        public string SortOrder { get; set; }
        public string IdSortParm { get; set; }
        public string NomeSortParm { get; set; }

        public string CurrentFilter { get; set; }

        public int? PageNumber { get; set; }

        private ViewDataDictionary ViewData { get; set; }

        public IndexContratoVendaFilter()
        {

        }

        public void SetViewData(ViewDataDictionary data)
        {
            this.ViewData = data;
        }

        public String GetCurrentFilter()
        {
            return JsonSerializer.Serialize(this);
        }

        public static IndexContratoVendaFilter Create(string json)
        {
            return JsonSerializer.Deserialize<IndexContratoVendaFilter>(json);
        }

        public IQueryable<SaleContract> DoFilter(IQueryable<SaleContract> query)
        {
            HandleOnSorting();

            query = QueryName(query);
            query = QueryNickname(query);
            query = QueryStatus(query);
            query = QueryProductGroup(query);
            query = QueryClient(query);
            query = QueryBegin(query);
            query = QueryEnd(query);

            query = Sort(query);

            Save();

            return query;
        }

        internal void HandleOnSorting()
        {
            // when ordering
            if (!String.IsNullOrEmpty(CurrentFilter))
            {
                var actualFilter = Create(CurrentFilter);

                this.Name = actualFilter.Name;
                this.Nickname = actualFilter.Name;
                this.Status = actualFilter.Status;
                this.ClientGroupName = actualFilter.ClientGroupName;
                this.ClientGroupId = actualFilter.ClientGroupId;
                this.ProductGroupId = actualFilter.ProductGroupId;
                this.Begin = actualFilter.Begin;
                this.End = actualFilter.End; 
            }
        }

        internal IQueryable<SaleContract> QueryName(IQueryable<SaleContract> query)
        {
            if (!String.IsNullOrEmpty(Name))
            {
                query = query.Where (s => s.Name.Contains(Name));
            }

            return query;
        }

        internal IQueryable<SaleContract> QueryNickname(IQueryable<SaleContract> query)
        {
            if (!String.IsNullOrEmpty(Nickname))
            {
                query = query.Where (s => s.Nickname.Contains(Nickname));
            }

            return query;
        }

        internal IQueryable<SaleContract> QueryStatus(IQueryable<SaleContract> query)
        {
            if (Status != null && Status > 0)
            {
                query = query.Where (s => s.Status == Status);
            }

            return query;
        }

        internal IQueryable<SaleContract> QueryProductGroup(IQueryable<SaleContract> query)
        {
            if (ProductGroupId.HasValue && ProductGroupId.Value > 0)
            {
                query = query.Where (s => s.ProductGroupId == ProductGroupId);
            }

            return query;
        }

        internal IQueryable<SaleContract> QueryClient(IQueryable<SaleContract> query)
        {
            if (ClientGroupId.HasValue && ClientGroupId.Value > 0)
            {
                query = query.Where (s => s.ClientGroupId == ClientGroupId);
            }

            return query;
        }

        internal IQueryable<SaleContract> QueryBegin(IQueryable<SaleContract> query)
        {
            if (Begin != null)
            {
                query = query.Where (s => s.Begin >= Begin);
            }

            return query;
        }

        internal IQueryable<SaleContract> QueryEnd(IQueryable<SaleContract> query)
        {
            if (End != null)
            {
                query = query.Where (s => s.End <= End);
            }

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
                    return query.OrderBy(s => s.Nickname);
                    
                case "nome_desc":
                    return query.OrderByDescending(s => s.Nickname);
                    
                default: // inicio_desc
                    return query.OrderByDescending(s => s.Id);                    
                   
            }
        }

        public void Save()
        {
            ViewData["CurrentFilter"] = GetCurrentFilter();
            ViewData["FilterName"] = Name;
            ViewData["FilterNickname"] = Nickname;
            ViewData["FilterStatus"] = Status;
            ViewData["FilterProduct"] = ProductGroupId;
            ViewData["FilterClientId"] = ClientGroupId;
            ViewData["FilterClientName"] = ClientGroupName;
            ViewData["FilterBegin"] = Begin;
            ViewData["FilterEnd"] =  End;

            ViewData["CurrentSort"] = SortOrder;
            ViewData["IdSortParm"] = SortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewData["NomeSortParm"] = SortOrder == "nome_asc" ? "nome_desc" : "nome_asc";;

        }

    }
}