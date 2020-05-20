using DATACOREHORTICOMMAND;
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
            using (_DBHORTICONTEXT)
            {
                using (var transaction = _DBHORTICONTEXT.Database.BeginTransaction())
                {
                    try
                    {
                        _DBHORTICONTEXT.Set<T>().Add(TEntity);

                        await _DBHORTICONTEXT.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        protected async Task DeleteEntity(T TEntity, bool bolLogicDeletion = false)
        {
            using (_DBHORTICONTEXT)
            {
                using (var transaction = _DBHORTICONTEXT.Database.BeginTransaction())
                {
                    try
                    {

                        if (bolLogicDeletion)
                            _DBHORTICONTEXT.Set<T>().Update(TEntity);
                        else
                            _DBHORTICONTEXT.Set<T>().Remove(TEntity);

                        await _DBHORTICONTEXT.SaveChangesAsync();
                        _DBHORTICONTEXT.Database.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        protected async Task UpdateEntity(T TEntity)
        {
            using (_DBHORTICONTEXT)
            {
                using (var transaction = _DBHORTICONTEXT.Database.BeginTransaction())
                {
                    try
                    {
                        _DBHORTICONTEXT.Set<T>().Update(TEntity);

                        await _DBHORTICONTEXT.SaveChangesAsync();
                        _DBHORTICONTEXT.Database.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
