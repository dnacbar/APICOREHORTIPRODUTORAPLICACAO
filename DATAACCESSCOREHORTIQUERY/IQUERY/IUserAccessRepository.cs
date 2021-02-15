using APPDTOCOREHORTIQUERY.SIGNATURE;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IUserAccessRepository
    {
        Task<Userhorti> GetUserHortiAccess(UserAccessSignature signature);
    }
}
