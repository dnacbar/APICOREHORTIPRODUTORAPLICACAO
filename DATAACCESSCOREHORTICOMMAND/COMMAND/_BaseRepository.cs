using DATACOREHORTICOMMAND;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
{
    public abstract class _BaseRepository<T> where T : class
    {
        private readonly DBHORTICONTEXT _DBHORTICONTEXT;
        protected _BaseRepository(DBHORTICONTEXT DBHORTICONTEXT)
        {
            _DBHORTICONTEXT = DBHORTICONTEXT;
        }

        protected async Task CreateEntity(T TEntity)
        {
            try
            {
                _DBHORTICONTEXT.Set<T>().Add(TEntity);

                await _DBHORTICONTEXT.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DbUpdateException(ex.Message, ex);

                throw ex;
            }
            finally
            {
                _DBHORTICONTEXT.Dispose();
            }
        }

        protected async Task DeleteEntity(T TEntity, bool bolLogicDeletion = false)
        {
            try
            {
                using (_DBHORTICONTEXT)
                {
                    if (bolLogicDeletion)
                        _DBHORTICONTEXT.Set<T>().Update(TEntity);
                    else
                        _DBHORTICONTEXT.Set<T>().Remove(TEntity);

                    await _DBHORTICONTEXT.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DbUpdateException(ex.Message, ex);

                throw ex;

            }
        }

        protected async Task UpdateEntity(T TEntity)
        {
            try
            {
                using (_DBHORTICONTEXT)
                {
                    _DBHORTICONTEXT.Set<T>().Update(TEntity);

                    await _DBHORTICONTEXT.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    throw new DbUpdateException(ex.Message, ex);

                throw ex;
            }
        }
    }
}
