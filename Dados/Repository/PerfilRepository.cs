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
    public class PerfilRepository : BaseRepository<Perfil, int>
    {
        public PerfilRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override Perfil Get(int id)
        {
            return _context.Perfis.First(o => o.Code.Equals(id));
        }

        public override int GetPkValue(Perfil entity)
        {
            return (int)typeof(Perfil).GetProperty("Id").GetValue(entity);
        }

        //public override Perfil MergeFromDB(Perfil localCopy)
        //{
        //    var objFromDB = Get(localCopy.Id);

        //    if (objFromDB == null)
        //        throw new ArgumentException("ERRO: ID " + localCopy.Code + 
        //            " NOT FOUND FOR ENTITY: PERFIL");

        //    objfromdb.code = localcopy.code;
        //    objfromdb.nome = localcopy.nome;
        //    objfromdb.volume = localcopy.volume;
        //    objfromdb.prazo = localcopy.prazo;
        //    objfromdb.preco = localcopy.preco;
        //    objfromdb.rating = localcopy.rating;
        //    objfromdb.volumecontrato = localcopy.volumecontrato;
        //    objfromdb.volumecomplemento = localcopy.volumecomplemento;

        //    objfromdb.vlvolumeenergia = localcopy.vlvolumeenergia;
        //    objfromdb.vlvolumecontratoenergia = localcopy.vlvolumecontratoenergia;
        //    objfromdb.vlvolumeimportacao = localcopy.vlvolumeimportacao;
        //    objfromdb.vlprecoenergia = localcopy.vlprecoenergia;
        //    objfromdb.vlprazoenergia = localcopy.vlprazoenergia;
        //    objfromdb.vlvolumecomplementoenergia = localcopy.vlvolumecomplementoenergia;

        //    objfromdb.vlvolumecomplementoenergia = localcopy.vlvolumecomplementoenergia;
        //    objfromdb.vlvolumecomplementoenergia = localcopy.vlvolumecomplementoenergia;
        //    objfromdb.vlvolumecomplementoenergia = localcopy.vlvolumecomplementoenergia;
        //    objfromdb.vlvolumecomplementoenergia = localcopy.vlvolumecomplementoenergia;


        //    objfromdb.profilelevel = localcopy.profilelevel;

        //    return objFromDB;
        //}
    }
}