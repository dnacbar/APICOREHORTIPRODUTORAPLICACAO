using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HORTI.CORE.CROSSCUTTING.DBBASEEF
{
    public abstract class _BaseEFQueryRepository<T> where T : class
    {
        protected readonly DbContext _DBCONTEXT;
        protected _BaseEFQueryRepository(DbContext DBCONTEXT)
        {
            _DBCONTEXT = DBCONTEXT;
        }

        protected Task<T> EntityByFilter(Expression<Func<T, T>> Select, Expression<Func<T, bool>> Where)
        {
            return _DBCONTEXT.Set<T>().Where(Where).Select(Select).AsNoTracking().FirstOrDefaultAsync();
        }

        protected Task<List<T>> FullListOfEntity<TResult>(Expression<Func<T, T>> Select, Expression<Func<T, TResult>> OrderBy)
        {
            return _DBCONTEXT.Set<T>().OrderBy(OrderBy).Select(Select).AsNoTracking().ToListAsync();
        }

        protected Task<List<T>> ListOfEntity<TResult>(Expression<Func<T, T>> Select, Expression<Func<T, bool>> Where, int Page, int Quantity, Expression<Func<T, TResult>> OrderBy)
        {
            return _DBCONTEXT.Set<T>().Where(Where).OrderBy(OrderBy).Skip(Page * Quantity).Take(Quantity).Select(Select).AsNoTracking().ToListAsync();
        }
    }
}