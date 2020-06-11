using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Sicle.Logs.DAL;
using Sicle.Logs.Model;
using Sicle.Logs.Model.Base;

namespace Sicle.Logs.BLL.Base
{
    /// <summary>
    /// Classe business para as operações de log 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// ATENÇÃO: nesta classe não podemos utilizar o método "LogarErro", pois isso causaria
    /// um loop infinito em cenários de falha! Deixar os erros subirem para as camadas mais
    /// externas (não implementar try/catch)
    /// </remarks>
    internal abstract class LogBusinessBase<T> where T : LogBase
    {
        #region Enumerações
        private enum TipoCRUD
        {
            Adicionar,
            AdicionarMassaDados,
            Atualizar,
            Excluir,
            ExcluirId,
            ExcluirWhere
        }

        #endregion

        #region ExecutarCRUD

        private async Task<bool> ExecutarCRUDVerificandoTransaction(TipoCRUD operacao,
                                                        T registro = null,
                                                        List<T> listaRegistros = null,
                                                        long idChaveExclusao = 0,
                                                        string tabelaDestinoBulkInsert = "",
                                                        Expression<Func<T, bool>> filtroExclusaoLista = null
        ) {
            if (typeof(T) == typeof(LogErro))
            {
                // Especificamente para CRUDs de erro, temos que garantir que a operação será executada, independente
                // se haja um transaction scope aberto ou não. Isso garante que, nas situações de erro, mesmo que haja
                // um transaction scope em andamento, o erro ssrá inserido na tabela, mesmo quando houver o rollback
                // da transação original que falhou
                
                return await ExecutarCRUD(operacao, registro, listaRegistros, idChaveExclusao, tabelaDestinoBulkInsert, filtroExclusaoLista);
                
            }
            else
            {
                // Não estamos tratando log de erro. Nestes casos, executa dentro do escopo da transação em andamento (se houver)
                // Isso garante que, por exemplo, logs operacionais só serão gerados após o commit da transação original
                return await ExecutarCRUD(operacao, registro, listaRegistros, idChaveExclusao, tabelaDestinoBulkInsert, filtroExclusaoLista);
            }
        }

        private async Task<bool> ExecutarCRUD(TipoCRUD operacao, 
                                  T registro = null,
                                  List<T> listaRegistros = null,
                                  long idChaveExclusao = 0,
                                  string tabelaDestinoBulkInsert = "",
                                  Expression<Func<T, bool>> filtroExclusaoLista = null
        ) {
            using (var repositorio = new LogDalRepository<T>())
            {
                var registros = 0;

                switch (operacao)
                {
                    case TipoCRUD.Adicionar:
                        registros = await repositorio.Add(registro);
                        break;

                    // case TipoCRUD.AdicionarMassaDados:
                    //     repositorio.BulkInsert(listaRegistros, tabelaDestinoBulkInsert);
                    //     registros = listaRegistros.Count; // se não gerar exceção, consideramos que foram inseridos a quantidade de registros total da lista
                    //     break;

                    case TipoCRUD.Atualizar:
                        registros = await repositorio.Update(registro);
                        break;

                    case TipoCRUD.Excluir:
                        registros = await repositorio.Delete(registro);
                        break;

                    case TipoCRUD.ExcluirId:
                        registros = await repositorio.Delete(idChaveExclusao);
                        break;

                    // case TipoCRUD.ExcluirWhere:
                    //     registros = await repositorio.DeleteList(filtroExclusaoLista);
                    //     break;
                }

                return (registros > 0);
            }
        }

        #endregion

        #region Adicionar

        public virtual async Task<bool> Adicionar(T model)
        {
            return await ExecutarCRUDVerificandoTransaction(TipoCRUD.Adicionar, model);
        }

        public virtual async Task<bool> AdicionarMassaDados(List<T> listaDados, string nomeTabelaDestino)
        {
            listaDados = (listaDados == null ? new List<T>() : listaDados);
            return await ExecutarCRUDVerificandoTransaction(TipoCRUD.AdicionarMassaDados, listaRegistros: listaDados, tabelaDestinoBulkInsert: nomeTabelaDestino);
        }

        #endregion

        #region Atualizar

        public virtual async Task<bool> Atualizar(T model)
        {
            return await ExecutarCRUDVerificandoTransaction(TipoCRUD.Atualizar, model);
        }

        #endregion

        #region Excluir

        public virtual async Task<bool> Excluir(T model)
        {
            return await ExecutarCRUDVerificandoTransaction(TipoCRUD.Excluir, model);
        }

        public virtual async Task<bool> Excluir(int Id)
        {
            return await ExecutarCRUDVerificandoTransaction(TipoCRUD.ExcluirId, idChaveExclusao: Id);
        }

        public virtual async Task<bool> ExcluirLista(Expression<Func<T, bool>> where)
        {
            return await ExecutarCRUDVerificandoTransaction(TipoCRUD.ExcluirWhere, filtroExclusaoLista: where);
        }

        #endregion

        #region Selecionar

        public virtual T Selecionar(int Id)
        {
            using (var repositorio = new LogDalRepository<T>())
            {
                return repositorio.Get(Id);
            }
        }

        public virtual T Selecionar(Expression<Func<T, bool>> where)
        {
            using (var repositorio = new LogDalRepository<T>())
            {
                return repositorio.Get(where);
            }
        }
        #endregion

        #region Listar

        public virtual List<T> Listar()
        {
            using (var repositorio = new LogDalRepository<T>())
            {
                return repositorio.AsQueryable().ToList<T>();
            }
        }      

        public virtual List<T> Listar(Expression<Func<T, bool>> where)
        {
            using (var repositorio = new LogDalRepository<T>())
            {
                return repositorio.List(where);
            }
        }       

        #endregion

        #region GetQuery

        // public virtual IQueryable<T> GetQuery(LogBaseFiltro filtro, ILogDalRepositorio<T> repositorio)
        // {
        //     DateTime dataInicial = (filtro.DataInicial.HasValue ? filtro.DataInicial.Value.Date : DateTime.MinValue);
        //     DateTime dataFinal = (filtro.DataFinal.HasValue ? filtro.DataFinal.Value.Date : DateTime.MaxValue);

        //     // O Linq to Entity não suporta apenas o objeto Date (não há como comparar apenas datas e ignorar horários)
            
        //     // A data inicial já possui o horário 00:00:00, pois foi feita a atribuição diretamente do objeto Date do filtro
        //     // ou, no caso de estar nulo, o MinValue do DateTime já garante 00:00:00
            
        //     // Porém, temos que garantir que a data final tenha o horário 23:59:59. Para isso, somamos um dia na data,
        //     // pegamos apenas a porção data (que garantirá que o horário será 00:00:00) e subtraímos 1 segundo, o que fará
        //     // com que a data volte para o dia anterior, e o horário seja 23:59:50. Fazemos esta operação apenas se o
        //     // filtro de data final foi informado
        //     if (filtro.DataFinal.HasValue)
        //         dataFinal = dataFinal.AddDays(1).Date.AddSeconds(-1);

        //     IQueryable<T> query = (
                
        //         from log in repositorio.ListComplex<T>()
        //         where
        //         (
        //             log.Id.Equals
        //             (
        //                 filtro.Id <= 0 ?
        //                     log.Id :
        //                     filtro.Id
        //             )
        //         )
        //         &&
        //         (
        //             log.ControllerSource.Equals
        //             (
        //                 filtro.Controller == null ?
        //                     log.ControllerSource :
        //                     filtro.Controller
        //                 , StringComparison.OrdinalIgnoreCase
        //             )
        //         )
        //         &&
        //         (
        //             log.ActionSource.Equals
        //             (
        //                 filtro.Action == null ?
        //                     log.ActionSource :
        //                     filtro.Action
        //                 , StringComparison.OrdinalIgnoreCase
        //             )
        //         )
        //         &&
        //         (
        //             log.Username.Equals
        //             (
        //                 string.IsNullOrEmpty(filtro.Login) ? 
        //                     log.Username : 
        //                     filtro.Login
        //                 , StringComparison.OrdinalIgnoreCase
        //             )
        //         )
        //         &&
        //         (
        //             log.IdUniqueTransaction.Equals
        //             (
        //                 filtro.IdUniqueTransaction == null ?
        //                     log.IdUniqueTransaction : 
        //                     filtro.IdUniqueTransaction
        //                 , StringComparison.OrdinalIgnoreCase
        //             )
        //         )
        //         &&
        //         (
        //             log.SiglaAplicacao.Equals
        //             (
        //                 filtro.SiglaAplicacao == null ? 
        //                     log.SiglaAplicacao : 
        //                     filtro.SiglaAplicacao
        //                 , StringComparison.OrdinalIgnoreCase
        //             )
        //         )
        //         &&
        //         (
        //             filtro.IdAplicacao == null || log.IdApplication == filtro.IdAplicacao
        //         )
        //         &&
        //         (
        //             filtro.IdModulo == null || log.IdModule == filtro.IdModulo
        //         )
        //         &&
        //         (
        //             filtro.IdPagina == null || log.IdPage == filtro.IdPagina
        //         )
        //         &&
        //         (
        //             log.DateOccurrence.CompareTo(dataInicial) >= 0
        //         )
        //         &&
        //         (
        //             log.DateOccurrence.CompareTo(dataFinal) <= 0
        //         )
                
        //         select log
        //     );

        //     return query;
        // }

        #endregion
    }
}
