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
    public class AssociacaoUsuarioPerfilController : SicleController
    {
        private readonly PerfilBus _perfilRepo;
        private readonly UsuarioBus _usrRepo;

        public AssociacaoUsuarioPerfilController() : base()
        {
            _usrRepo = new UsuarioBus();
            _perfilRepo = new PerfilBus();
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

        internal IQueryable<AssociacaoUsuarioPerfil> Sort(IQueryable<AssociacaoUsuarioPerfil> query, string sortOrder)
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

        public async Task<IActionResult> Index(int? perfilId,
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

            perfilId = (perfilId ?? perfList.FirstOrDefault().Id); // se grupo id não informado, pegar o primeiro            
            
            var query = new AssociacaoPerfilUsuarioBus().AsQueryable().Include("Usuario").Where(p => p.PerfilId == perfilId.Value);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Usuario.Nome.Contains(searchString)
                                        || s.Usuario.Matricula.Contains(searchString));
            }
            
            query = Sort(query, sortOrder);

            var list = query.ToList();
            var model = new AssociacaoUsuarioPerfilModel(list, list.Count(), pageNumber ?? 1);

            // aguardamos a thread finalizar para não gerar concorrência de Thread no dbContext em _usrRepo.GetAllAsync()
            model.Perfis = perfList;
            model.Usuarios = userList;
            model.PerfilId = perfilId.Value;

            return View(model);            
        }

        public IActionResult Associar(int perfilId, int usuarioId)
        {
            _log.Info(String.Format("Associar usuário {0} no Perfil {1} ", usuarioId, perfilId));
            if (usuarioId == 0 || perfilId == 0)
                throw new ArgumentException(String.Format("Usuário {0} ou Perfil {1} inválidos.", usuarioId, perfilId));

            _usrRepo.AssociarPerfil(usuarioId, perfilId);

            return RedirectToAction("Index", new { grupoId = perfilId });
        }

        public IActionResult Desassociar(int perfilId, int usuarioId)
        {
            _log.Info(String.Format("Desassociar usuário {0} no Perfil {1} ", usuarioId, perfilId));
            if (usuarioId == 0 || perfilId == 0)
                throw new ArgumentException(String.Format("Usuário {0} ou Perfil {1} inválidos.", usuarioId, perfilId));

            _usrRepo.DesassociarPerfil(usuarioId, perfilId);

            return RedirectToAction("Index", new { grupoId = perfilId });
        }
    }
}