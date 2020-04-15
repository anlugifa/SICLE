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
using Web.Controllers;
using Web.Models;

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
        private readonly PerfilVendaRepository _perfilRepo;
        private readonly UsuarioRepository _usrRepo;

        public AssociacaoUsuarioPerfilVendaController(ApplicationDBContext context) : base(context)
        {
            _usrRepo = new UsuarioRepository(_context);
            _perfilRepo = new PerfilVendaRepository(_context);
        }

        public async Task<IActionResult> Index(int? perfilVendaId,
                                    string sortOrder,
                                    string currentFilter,
                                    string searchString,
                                    int? pageNumber)
        {  
            
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["MatriculaSortParm"] = sortOrder == "matricula_desc" ? "name_desc" : "matricula_desc";

            if (!String.IsNullOrEmpty(searchString))
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            perfilVendaId = (perfilVendaId ?? 1); // se grupo id não informado, pegar o primeiro

            ViewData["PerfilVendaId"] = perfilVendaId.Value;
            ViewData["CurrentFilter"] = searchString;
            
            IQueryable<AssociacaoUsuarioPerfilVenda> query = _perfilRepo.GetAssociacaoUsuario(perfilVendaId.Value);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Include("Usuario")
                            .Where(s => s.Usuario.Nome.Contains(searchString)
                                        || s.Usuario.Matricula.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Usuario.Nome);
                    break;
                case "matricula_desc":
                    query = query.OrderBy(s => s.Usuario.Matricula);
                    break;
                default:
                    query = query.OrderBy(s => s.Usuario.Nome);
                    break;
            }
            var list = query.ToList();
            var model = new AssociacaoUsuarioPerfilVendaModel(list, list.Count(), pageNumber ?? 1, _pageSize);

            // aguardamos a thread finalizar para não gerar concorrência de Thread no dbContext em _usrRepo.GetAllAsync()
            model.Perfis = await _perfilRepo.AsQueryable().OrderBy(g => g.Nome).ToListAsync();
            model.Usuarios = await _usrRepo.AsQueryable().OrderBy(g => g.Nome).ToListAsync();
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