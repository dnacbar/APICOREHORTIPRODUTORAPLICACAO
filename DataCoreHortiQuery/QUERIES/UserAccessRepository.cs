using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class UserAccessRepository : IUserAccessRepository
    {
        private readonly DBHORTICONTEXT dBHORTICONTEXT;

        public UserAccessRepository(DBHORTICONTEXT _dBHORTICONTEXT)
        {
            dBHORTICONTEXT = _dBHORTICONTEXT;
        }

        public async Task<Userhorti> GetUserAccessHorti(UserAccessSignature signature)
        {
            var userHorti = new Userhorti();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    userHorti = await dBHORTICONTEXT.Userhorti
                                                    .Select(x => new Userhorti
                                                    {
                                                        DsLogin = x.DsLogin,
                                                        DsPassword = x.DsPassword
                                                    })
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync(x => x.DsLogin == signature.DsLogin
                                                                           && x.BoActive);
                }
                scope.Complete();
            }
            return userHorti;
        }
    }
}