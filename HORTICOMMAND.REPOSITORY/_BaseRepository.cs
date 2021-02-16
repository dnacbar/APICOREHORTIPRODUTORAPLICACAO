using HORTICOMMAND.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
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
        }

        protected async Task DeleteEntity(T TEntity, bool bolLogicDeletion = false)
        {
            try
            {
                if (bolLogicDeletion)
                {
                    _DBHORTICONTEXT.Entry(TEntity).Property("BoActive").IsModified = true;
                }
                else
                    _DBHORTICONTEXT.Set<T>().Remove(TEntity);

                await _DBHORTICONTEXT.SaveChangesAsync();
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
                _DBHORTICONTEXT.Set<T>().Update(TEntity).Property("DtCreation").IsModified = false;

                await _DBHORTICONTEXT.SaveChangesAsync();
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
