using HORTICOMMAND.REPOSITORY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace DATACOREHORTIQUERY.QUERIES
{
    public abstract class _BaseRepository<T> where T : class
    {
        private readonly DBHORTICONTEXT _DBHORTICONTEXT;
        protected _BaseRepository(DBHORTICONTEXT DBHORTICONTEXT)
        {
            _DBHORTICONTEXT = DBHORTICONTEXT;
        }

        protected async Task<T> EntityByFilter(Expression<Func<T, bool>> Where, Expression<Func<T, T>> Select)
        {
            var varT = Activator.CreateInstance<T>();

            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {

                varT = await _DBHORTICONTEXT.Set<T>().Where(Where).Select(Select).AsNoTracking().FirstOrDefaultAsync();
                scope.Complete();
            }
            return varT;
        }

        protected async Task<IEnumerable<T>> FullListOfEntities<TResult>(Expression<Func<T, T>> Select, Expression<Func<T, TResult>> OrderBy)
        {
            var varT = Activator.CreateInstance<List<T>>();

            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                varT = await _DBHORTICONTEXT.Set<T>().Select(Select).AsNoTracking().OrderBy(OrderBy).ToListAsync();

                scope.Complete();
            }
            return varT;
        }

        protected async Task<IEnumerable<T>> ListOfEntities<TResult>(Expression<Func<T, bool>> Where, Expression<Func<T, T>> Select,
                                                         int Page, int Quantity, Expression<Func<T, TResult>> OrderBy)
        {
            var varT = Activator.CreateInstance<List<T>>();

            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {

                varT = await _DBHORTICONTEXT.Set<T>().Where(Where).Select(Select)
                                            .AsNoTracking().Skip(Page * Quantity).Take(Quantity)
                                            .OrderBy(OrderBy).ToListAsync();
                scope.Complete();
            }
            return varT;
        }
    }
}
