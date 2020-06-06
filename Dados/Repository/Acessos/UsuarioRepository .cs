#nullable disable
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
    public class UsuarioRepository : BaseRepository<Usuario, long>
    {
        public UsuarioRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override Usuario Get(long id)
        {
            return _context.Usuarios.First(o => o.Id == id);
        }

        public override long GetPkValue(Usuario entity)
        {
            return (int)typeof(Usuario).GetProperty("Id").GetValue(entity);
        }

        public IQueryable<AssociacaoGrupoUsuario> GetAssociacaoGrupoUsuarios(long usuarioId)
        {
            return _context.AssociacaoGruposUsuarios.Where(g => g.UsuarioId == usuarioId)
                                    .AsQueryable<AssociacaoGrupoUsuario>();
        }

        public override Task<int> Delete(long e)
        {
            var u = Get(e);
            u.IsAtivo = false;

            return Update(u);
        }

        public override Task<int> Delete(Usuario e)
        {
            return Delete(e.Id);
        }

        public void AssociarGrupo(long usuarioId, int grupoId)
        {            
            var associacao = _context.AssociacaoGruposUsuarios
                                .Where(g => g.UsuarioId == usuarioId && g.GrupoUsuarioId == grupoId)
                                .FirstOrDefault();

            if (associacao != null)
                throw new ArgumentException(
                    String.Format("Usuário {0} já associado ao grupo {1}", usuarioId, grupoId));

            associacao = new AssociacaoGrupoUsuario()
            {
                UsuarioId = usuarioId,
                GrupoUsuarioId = grupoId
            };

            _context.AssociacaoGruposUsuarios.Add(associacao);
            _context.SaveChanges();
        }

        public void DesassociarGrupo(long usuarioId, int grupoId)
        {
            var associacao = _context.AssociacaoGruposUsuarios
                                .Where(g => g.UsuarioId == usuarioId && g.GrupoUsuarioId == grupoId)
                                .FirstOrDefault();

            if (associacao == null)
                if (associacao != null)
                    throw new ArgumentException(
                        String.Format("Usuário {0} não associado ao grupo {1}", usuarioId, grupoId));

            _context.AssociacaoGruposUsuarios.Remove(associacao);
            _context.SaveChanges();
        }

        public void AssociarPerfil(long usuarioId, int perfilId)
        {
            var associacao = _context.AssociacaoUsuarioPerfis
                                .Where(g => g.UsuarioId == usuarioId && g.PerfilId == perfilId)
                                .FirstOrDefault();

            if (associacao != null)
                throw new ArgumentException(
                    String.Format("Usuário {0} já associado ao perfil {1}", usuarioId, perfilId));

            associacao = new AssociacaoUsuarioPerfil()
            {
                UsuarioId = usuarioId,
                PerfilId = perfilId
            };

            _context.AssociacaoUsuarioPerfis.Add(associacao);
            _context.SaveChanges();
        }

        public void DesassociarPerfil(long usuarioId, int perfilId)
        {
            var associacao = _context.AssociacaoUsuarioPerfis
                                .Where(g => g.UsuarioId == usuarioId && g.PerfilId == perfilId)
                                .FirstOrDefault();

            if (associacao == null)
                if (associacao != null)
                    throw new ArgumentException(
                        String.Format("Usuário {0} não associado ao perfil {1}", usuarioId, perfilId));

            _context.AssociacaoUsuarioPerfis.Remove(associacao);
            _context.SaveChanges();
        }

        ////
        public void AssociarPerfilVenda(long usuarioId, int perfilVendaId)
        {
            var associacao = _context.AssociacaoUsuarioPerfilVendas
                                .Where(g => g.UsuarioId == usuarioId && g.PerfilVendaId == perfilVendaId)
                                .FirstOrDefault();

            if (associacao != null)
                throw new ArgumentException(
                    String.Format("Usu�rio {0} já associado ao perfil {1}", usuarioId, perfilVendaId));

            associacao = new AssociacaoUsuarioPerfilVenda()
            {
                UsuarioId = usuarioId,
                PerfilVendaId = perfilVendaId
            };

            _context.AssociacaoUsuarioPerfilVendas.Add(associacao);
            _context.SaveChanges();
        }

        public void DesassociarPerfilVenda(long usuarioId, int perfilVendaId)
        {
            var associacao = _context.AssociacaoUsuarioPerfilVendas
                                .Where(g => g.UsuarioId == usuarioId && g.PerfilVendaId == perfilVendaId)
                                .FirstOrDefault();

            if (associacao == null)
                if (associacao != null)
                    throw new ArgumentException(
                        String.Format("Usu�rio {0} nãO associado ao PerfilVenda {1}", usuarioId, perfilVendaId));

            _context.AssociacaoUsuarioPerfilVendas.Remove(associacao);
            _context.SaveChanges();
        }
    }
}