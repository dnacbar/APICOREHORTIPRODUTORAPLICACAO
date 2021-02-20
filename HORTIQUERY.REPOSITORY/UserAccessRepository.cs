using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public sealed class UserAccessRepository : _BaseRepository<Userhorti>, IUserAccessRepository
    {
        public UserAccessRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public Task<Userhorti> GetUserHortiAccess(IUserAccessQuerySignature signature)
        {
            return EntityByFilter(Where: x => x.DsLogin == signature.Login && x.BoActive,
            Select: p => new Userhorti
            {
                DsLogin = p.DsLogin,
                DsPassword = p.DsPassword
            });
        }
    }
}