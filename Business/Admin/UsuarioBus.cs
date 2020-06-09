using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades;
using System.Linq;
using Dominio.Entidades.Acesso;
using System.Threading.Tasks;

namespace Sicle.Business.Admin
{
    public class UsuarioBus : SicleBusiness<Usuario>
    {
        public UsuarioBus()
        {

        }

        public override Task<bool> Delete(long e)
        {
            var u = Get(e);
            u.IsAtivo = false;

            return Update(u);
        }

        public override Task<bool> Delete(Usuario e)
        {
            return Delete(e.Id);
        }

        public IQueryable<AssociacaoGrupoUsuario> GetAssociacaoGrupoUsuarios(long usuarioId)
        {
            using (var repo = new BaseRepository<AssociacaoGrupoUsuario>())
            {
                return repo.AsQueryable().Where(g => g.UsuarioId == usuarioId);
            }
        }

        public async void AssociarGrupo(long usuarioId, int grupoId)
        {
            using (var repo = new BaseRepository<AssociacaoGrupoUsuario>())
            {
                var associacao = repo.AsQueryable()
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

                await repo.Add(associacao);
            }
        }

        public async void DesassociarGrupo(long usuarioId, int grupoId)
        {
            using (var repo = new BaseRepository<AssociacaoGrupoUsuario>())
            {
                var associacao = repo.AsQueryable()
                                    .Where(g => g.UsuarioId == usuarioId && g.GrupoUsuarioId == grupoId)
                                    .FirstOrDefault();

                if (associacao == null)
                    if (associacao != null)
                        throw new ArgumentException(
                            String.Format("Usuário {0} não associado ao grupo {1}", usuarioId, grupoId));

                await repo.Delete(associacao);
            }
        }


        //// Perfil

        public async void AssociarPerfil(long usuarioId, int perfilId)
        {
            using (var repo = new BaseRepository<AssociacaoUsuarioPerfil>())
            {
                var associacao = repo.AsQueryable()
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

                await repo.Add(associacao);
            }
        }

        public async void DesassociarPerfil(long usuarioId, int perfilId)
        {
            using (var repo = new BaseRepository<AssociacaoUsuarioPerfil>())
            {
                var associacao = repo.AsQueryable()
                                    .Where(g => g.UsuarioId == usuarioId && g.PerfilId == perfilId)
                                    .FirstOrDefault();

                if (associacao == null)
                    if (associacao != null)
                        throw new ArgumentException(
                            String.Format("Usuário {0} não associado ao perfil {1}", usuarioId, perfilId));

                await repo.Delete(associacao);
            }
        }

        ////
        public async void AssociarPerfilVenda(long usuarioId, int perfilVendaId)
        {
            using (var repo = new BaseRepository<AssociacaoUsuarioPerfilVenda>())
            {
                var associacao = repo.AsQueryable()
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

                await repo.Delete(associacao);
            }
        }

        public async void DesassociarPerfilVenda(long usuarioId, int perfilVendaId)
        {
            using (var repo = new BaseRepository<AssociacaoUsuarioPerfilVenda>())
            {
                var associacao = repo.AsQueryable()
                                    .Where(g => g.UsuarioId == usuarioId && g.PerfilVendaId == perfilVendaId)
                                    .FirstOrDefault();

                if (associacao == null)
                    if (associacao != null)
                        throw new ArgumentException(
                            String.Format("Usu�rio {0} nãO associado ao PerfilVenda {1}", usuarioId, perfilVendaId));

                await repo.Delete(associacao);
            }
        }


        public override Usuario MergeFromDB(Usuario localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: Usuario");


            objFromDB.Matricula = localCopy.Matricula;
            objFromDB.Nome = localCopy.Nome;
            objFromDB.NomeSGP = localCopy.NomeSGP;
            objFromDB.Nome = localCopy.Nome;
            objFromDB.Email = localCopy.Email;

            objFromDB.IsAtivo = localCopy.IsAtivo;
            objFromDB.IsScaPerfil = localCopy.IsScaPerfil;
            objFromDB.IsTraderComb = localCopy.IsTraderComb;
            objFromDB.IsTraderEAB = localCopy.IsTraderEAB;

            return objFromDB;
        }
    }

}
