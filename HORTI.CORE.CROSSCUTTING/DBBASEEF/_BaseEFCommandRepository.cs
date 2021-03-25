using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HORTI.CORE.CROSSCUTTING.DBBASEEF
{
    public abstract class _BaseEFCommandRepository<T> where T : class
    {
        protected readonly DbContext _DBCONTEXT;
        protected _BaseEFCommandRepository(DbContext DBCONTEXT)
        {
            _DBCONTEXT = DBCONTEXT;
        }

        protected Task CreateEntity(T TEntity)
        {
            try
            {
                _DBCONTEXT.Set<T>().Add(TEntity);

                return _DBCONTEXT.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DbUpdateException(ex.Message, ex);

                throw;
            }
        }

        protected Task DeleteEntity(T TEntity, bool bolLogicDeletion = false)
        {
            try
            {
                if (bolLogicDeletion)
                {
                    _DBCONTEXT.Entry(TEntity).Property("BoActive").IsModified = true;
                }
                else
                    _DBCONTEXT.Set<T>().Remove(TEntity);

                return _DBCONTEXT.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DbUpdateException(ex.Message, ex);

                throw;
            }
        }

        protected Task UpdateEntity(T TEntity)
        {
            try
            {
                _DBCONTEXT.Set<T>().Update(TEntity).Property("DtCreation").IsModified = false;

                return _DBCONTEXT.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DbUpdateException(ex.Message, ex);

                throw;
            }
        }
    }
}
