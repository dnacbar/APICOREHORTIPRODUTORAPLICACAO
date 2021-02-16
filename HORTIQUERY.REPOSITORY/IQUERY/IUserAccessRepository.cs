using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IUserAccessRepository
    {
        Task<Userhorti> GetUserHortiAccess(UserAccessSignature signature);
    }
}
