using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dados.Repository;
using Dominio.Entidades.Acesso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sicle.Web.Areas.Acessos.Models;
using Sicle.Web.Controllers;
using Sicle.Web.Models;
using Sicle.Business.Admin;

namespace Sicle.Web.Areas.Acessos.Controllers
{

    /// <summary>
    /// Controller para gerenciar a associação entre Usuario e GrupoUsuario usando a tabela de junção AssociacaoGrupoUsuario.
    /// O controller irá prover dois dropdown list: Grupos e Usuários.
    /// Ao selecionar o grupo no DDL os usuários associados são mostrados na tabela de associação. 
    /// </summary>
    [Area("Acessos")]
    public class AssociacaoUsuarioPerfilVendaController : SicleController
    {
        private readonly PerfilVendaBus _perfilRepo;
        private readonly UsuarioBus _usrRepo;

        public AssociacaoUsuarioPerfilVendaController() : base() 
        {
            _usrRepo = new UsuarioBus();
            _perfilRepo = new PerfilVendaBus();
        }

        internal void HandleSearchVariable(
                                    string sortOrder,
                                    string currentFilter,
                                    string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["MatriculaSortParm"] = sortOrder == "matricula_desc" ? "name_desc" : "matricula_desc";
            ViewData["CurrentFilter"] = searchString;
        }

        internal IQueryable<AssociacaoUsuarioPerfilVenda> Sort(IQueryable<AssociacaoUsuarioPerfilVenda> query, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name_desc":
                    return query.OrderByDescending(s => s.Usuario.Nome);
                    
                case "matricula_desc":
                    return query.OrderBy(s => s.Usuario.Matricula);
                   
                default:
                    return query.OrderBy(s => s.Usuario.Nome);
                   
            }
        }

        public async Task<IActionResult> Index(int? perfilVendaId,
                                    string sortOrder,
                                    string currentFilter,
                                    string searchString,
                                    int? pageNumber)
        {  
            
            HandleSearchVariable(sortOrder, currentFilter, searchString);
            if (String.IsNullOrEmpty(searchString))
            {
                searchString = currentFilter;
            }
            
            // aguardamos a thread finalizar para não gerar concorrência de Thread no dbContext em _usrRepo.GetAllAsync()
            var perfList = await _perfilRepo.AsQueryable().OrderBy(g => g.Nome).ToListAsync();
            var userList = await _usrRepo.AsQueryable().OrderBy(g => g.Nome).ToListAsync();

            perfilVendaId = (perfilVendaId ?? perfList.FirstOrDefault().Id); // se grupo id não informado, pegar o primeiro
            ViewData["PerfilVendaId"] = perfilVendaId.Value;            

            var query = new AssociacaoUsuarioPerfilVendaBus().AsQueryable()
                                .Include("Usuario")
                                .Where(g => g.PerfilVendaId == perfilVendaId.Value);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Usuario.Nome.Contains(searchString)
                                        || s.Usuario.Matricula.Contains(searchString));
            }            

            query = Sort(query, sortOrder);
            
            var list = query.ToList();
            var model = new AssociacaoUsuarioPerfilVendaModel(list, list.Count(), pageNumber ?? 1);
            
            model.Perfis = perfList;
            model.Usuarios = userList;
            model.PerfilVendaId = perfilVendaId.Value;

            return View(model);            
        }

        public IActionResult Associar(int perfilVendaId, int usuarioId)
        {
            _log.Info(String.Format("Associar usuário {0} no PerfilVenda {1} ", usuarioId, perfilVendaId));
            if (usuarioId == 0 || perfilVendaId == 0)
                throw new ArgumentException(String.Format("Usuário {0} ou PerfilVenda {1} inválidos.", usuarioId, perfilVendaId));

            _usrRepo.AssociarPerfilVenda(usuarioId, perfilVendaId);

            return RedirectToAction("Index", new { grupoId = perfilVendaId });
        }

        public IActionResult Desassociar(int perfilVendaId, int usuarioId)
        {
            _log.Info(String.Format("Desassociar usuário {0} no PerfilVenda {1} ", usuarioId, perfilVendaId));
            if (usuarioId == 0 || perfilVendaId == 0)
                throw new ArgumentException(String.Format("Usuário {0} ou PerfilVenda {1} inválidos.", usuarioId, perfilVendaId));

            _usrRepo.DesassociarPerfilVenda(usuarioId, perfilVendaId);

            return RedirectToAction("Index", new { grupoId = perfilVendaId });
        }
    }
}