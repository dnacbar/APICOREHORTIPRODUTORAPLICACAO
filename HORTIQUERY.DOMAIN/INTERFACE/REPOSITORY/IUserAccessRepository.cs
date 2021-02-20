using HORTICOMMAND.DOMAIN.MODEL;
using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY
{
    public interface IUserAccessRepository
    {
        Task<Userhorti> GetUserHortiAccess(IUserAccessQuerySignature signature);
    }
}
