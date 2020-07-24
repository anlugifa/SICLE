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
        public bool FindActive { get; set; }

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

        public IQueryable<T> DoFilter<T>(IQueryable<T> query) where T : SaleContract
        {
            HandleOnSorting();

            query = QueryName(query);
            query = QueryNickname(query);
            query = QueryStatus(query);
            query = QueryProductGroup(query);
            query = QueryClient(query);
            query = QueryBegin(query);
            query = QueryEnd(query);
            query = QueryActive(query);

            query = query.Where(p => !p.IsDeleted);

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

        internal IQueryable<T> QueryName<T>(IQueryable<T> query) where T : SaleContract
        {
            if (!String.IsNullOrEmpty(Name))
            {
                query = query.Where (s => s.Name.Contains(Name));
            }

            return query;
        }

        internal IQueryable<T> QueryNickname<T>(IQueryable<T> query) where T : SaleContract
        {
            if (!String.IsNullOrEmpty(Nickname))
            {
                query = query.Where (s => s.Nickname.Contains(Nickname));
            }

            return query;
        }

        internal IQueryable<T> QueryStatus<T>(IQueryable<T> query) where T : SaleContract
        {
            if (Status != null && Status > 0)
            {
                query = query.Where (s => s.Status == Status);
            }

            return query;
        }

        internal IQueryable<T> QueryProductGroup<T>(IQueryable<T> query) where T : SaleContract
        {
            if (ProductGroupId.HasValue && ProductGroupId.Value > 0)
            {
                query = query.Where (s => s.ProductGroupId == ProductGroupId);
            }

            return query;
        }

        internal IQueryable<T> QueryClient<T>(IQueryable<T> query) where T : SaleContract
        {
            if (ClientGroupId.HasValue && ClientGroupId.Value > 0)
            {
                query = query.Where (s => s.ClientGroupId == ClientGroupId);
            }

            return query;
        }

        internal IQueryable<T> QueryBegin<T>(IQueryable<T> query) where T : SaleContract
        {
            if (Begin != null)
            {
                query = query.Where (s => s.Begin >= Begin);
            }

            return query;
        }

        internal IQueryable<T> QueryEnd<T>(IQueryable<T> query) where T : SaleContract
        {
            if (End != null)
            {
                query = query.Where (s => s.End <= End);
            }

            return query;
        }

        internal IQueryable<T> QueryActive<T>(IQueryable<T> query) where T : SaleContract
        {            
            return query.Where (s => s.IsActive == FindActive);
        }

        internal IQueryable<T> Sort<T>(IQueryable<T> query) where T : SaleContract
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