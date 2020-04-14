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
    public class AssociacaoUsuarioPerfilController : SicleController
    {
        private readonly PerfilRepository _perfilRepo;
        private readonly UsuarioRepository _usrRepo;

        public GrupoUsuario _grupoUsuarioselected;

        public AssociacaoUsuarioPerfilController(ApplicationDBContext context) : base(context)
        {
            _usrRepo = new UsuarioRepository(_context);
            _perfilRepo = new PerfilRepository(_context);
        }

        public async Task<IActionResult> Index(int? grupoId,
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

            grupoId = (grupoId ?? 1); // se grupo id não informado, pegar o primeiro

            ViewData["GrupoId"] = grupoId;
            ViewData["CurrentFilter"] = searchString;
            
            IQueryable<AssociacaoUsuarioPerfil> query = _perfilRepo.GetAssociacaoUsuario(grupoId.Value);
            
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
            var model = new AssociacaoUsuarioPerfilModel(list, list.Count(), pageNumber ?? 1, _pageSize);

            // aguardamos a thread finalizar para não gerar concorrência de Thread no dbContext em _usrRepo.GetAllAsync()
            model.Perfis = await _perfilRepo.GetAllAsync();
            model.Usuarios = _usrRepo.GetAllAsync().Result;

            return View(model);            
        }

        public IActionResult Associar(int perfilId, int usuarioId)
        {
            _log.Info(String.Format("Associar usuário {0} no grupo {1} ", usuarioId, perfilId));
            if (usuarioId == 0 || perfilId == 0)
                throw new ArgumentException(String.Format("Usuário {0} ou Perfil {1} inválidos.", usuarioId, perfilId));

            _usrRepo.AssociarPerfil(usuarioId, perfilId);

            return RedirectToAction("Index", new { grupoId = perfilId });
        }

        public IActionResult Desassociar(int perfilId, int usuarioId)
        {
            _log.Info(String.Format("Desassociar usuário {0} no perfil {1} ", usuarioId, perfilId));
            if (usuarioId == 0 || perfilId == 0)
                throw new ArgumentException(String.Format("Usuário {0} ou Perfil {1} inválidos.", usuarioId, perfilId));

            _usrRepo.DesassociarPerfil(usuarioId, perfilId);

            return RedirectToAction("Index", new { grupoId = perfilId });
        }
    }
}