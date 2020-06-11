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
using Sicle.Business.Admin;
using Sicle.Web.Areas.Acessos.Models;
using Sicle.Web.Controllers;
using Sicle.Web.Models;

namespace Sicle.Web.Areas.Acessos.Controllers
{

    /// <summary>
    /// Controller para gerenciar a associação entre Usuario e GrupoUsuario usando a tabela de junção AssociacaoGrupoUsuario.
    /// O controller irá prover dois dropdown list: Grupos e Usuários.
    /// Ao selecionar o grupo no DDL os usuários associados são mostrados na tabela de associação. 
    /// </summary>
    [Area("Acessos")]
    public class AssociacaoGrupoUsuariosController : SicleController
    {
        private readonly GrupoUsuarioBus _grpUsrRepo;
        private readonly UsuarioBus _usrRepo;

        public GrupoUsuario _grupoUsuarioselected;

        public AssociacaoGrupoUsuariosController( ) : base()
        {
            _usrRepo = new UsuarioBus();
            _grpUsrRepo = new GrupoUsuarioBus();
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

        internal IQueryable<AssociacaoGrupoUsuario> Sort(IQueryable<AssociacaoGrupoUsuario> query, string sortOrder)
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

        public async Task<IActionResult> Index(int? grupoId,
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
            var grpList  = await _grpUsrRepo.AsQueryable().Where(g => !String.IsNullOrEmpty(g.Nome)).OrderBy(g => g.Nome).ToListAsync();
            var userList = await _usrRepo.AsQueryable().OrderBy(g => g.Nome).ToListAsync();

            grupoId = (grupoId ?? grpList.FirstOrDefault().Id); // se grupo id não informado, pegar o primeiro

            ViewData["GrupoId"] = grupoId.Value;            
            
            var query = new AssociacaoGrupoUsuarioBus().AsQueryable()
                                    .Include("Usuario")
                                    .Where(g => g.GrupoUsuarioId == grupoId.Value);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query
                            .Where(s => s.Usuario.Nome.Contains(searchString)
                                        || s.Usuario.Matricula.Contains(searchString));
            }

            query = Sort(query, sortOrder);

            var list = query.ToList();
            var model = new AssociacaoGrupoUsuarioModel(list, list.Count(), pageNumber ?? 1);
            
            model.Grupos = grpList;
            model.Usuarios = userList;
            model.GrupoId = grupoId.Value;

            return View(model);            
        }

        public IActionResult Associar(int grupoId, int usuarioId)
        {
            _log.Info(String.Format("Associar usuário {0} no grupo {1} ", usuarioId, grupoId));
            if (usuarioId == 0 || grupoId == 0)
                throw new ArgumentException(String.Format("Usuário {0} ou Grupo {1} inválidos.", usuarioId, grupoId));

            _usrRepo.AssociarGrupo(usuarioId, grupoId);

            return RedirectToAction("Index", new { grupoId = grupoId });
        }

        public IActionResult Desassociar(int grupoId, int usuarioId)
        {
            _log.Info(String.Format("Desassociar usuário {0} no grupo {1} ", usuarioId, grupoId));
            if (usuarioId == 0 || grupoId == 0)
                throw new ArgumentException(String.Format("Usuário {0} ou Grupo {1} inválidos.", usuarioId, grupoId));

            _usrRepo.DesassociarGrupo(usuarioId, grupoId);

            return RedirectToAction("Index", new { grupoId = grupoId });
        }
    }
}