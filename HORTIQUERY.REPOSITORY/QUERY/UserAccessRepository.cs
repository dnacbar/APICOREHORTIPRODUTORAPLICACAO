using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.REPOSITORY;
using DATACOREHORTIQUERY.IQUERIES;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class UserAccessRepository : _BaseRepository<Userhorti>, IUserAccessRepository
    {
        public UserAccessRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<Userhorti> GetUserHortiAccess(UserAccessSignature signature)
        {
            return await EntityByFilter(Where: x => x.DsLogin == signature.DsLogin && x.BoActive,
            Select: p => new Userhorti
            {
                DsLogin = p.DsLogin,
                DsPassword = p.DsPassword
            });
        }
    }
}