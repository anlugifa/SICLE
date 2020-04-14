using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados.Repository.Base;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario, int>
    {
        public UsuarioRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override Usuario Get(int id)
        {
            return _context.Usuarios.First(o => o.Id == id);
        }

        public override int GetPkValue(Usuario entity)
        {
            return (int)typeof(Usuario).GetProperty("Id").GetValue(entity);
        }

        public IQueryable<AssociacaoGrupoUsuario> GetAssociacaoGrupoUsuarios(int usuarioId)
        {
            return _context.AssociacaoGruposUsuarios.Where(g => g.UsuarioId == usuarioId)
                                    .AsQueryable<AssociacaoGrupoUsuario>();
        }

        public override Task Delete(int e)
        {
            var u = Get(e);
            u.IsAtivo = false;

            return Update(u);
        }

        public override Task Delete(Usuario e)
        {
            return Delete(e.Id);
        }

        public void AssociarGrupo(int usuarioId, int grupoId)
        {            
            var associacao = _context.AssociacaoGruposUsuarios
                                .Where(g => g.UsuarioId == usuarioId && g.GrupoUsuarioId == grupoId)
                                .FirstOrDefault();

            if (associacao != null)
                throw new ArgumentException(
                    String.Format("Usuário {0} JÁ associado ao grupo {1}", usuarioId, grupoId));

            associacao = new AssociacaoGrupoUsuario()
            {
                UsuarioId = usuarioId,
                GrupoUsuarioId = grupoId
            };

            _context.AssociacaoGruposUsuarios.Add(associacao);
            _context.SaveChanges();
        }

        public void DesassociarGrupo(int usuarioId, int grupoId)
        {
            var associacao = _context.AssociacaoGruposUsuarios
                                .Where(g => g.UsuarioId == usuarioId && g.GrupoUsuarioId == grupoId)
                                .FirstOrDefault();

            if (associacao == null)
                if (associacao != null)
                    throw new ArgumentException(
                        String.Format("Usuário {0} NÃO associado ao grupo {1}", usuarioId, grupoId));

            _context.AssociacaoGruposUsuarios.Remove(associacao);
            _context.SaveChanges();
        }
    }
}