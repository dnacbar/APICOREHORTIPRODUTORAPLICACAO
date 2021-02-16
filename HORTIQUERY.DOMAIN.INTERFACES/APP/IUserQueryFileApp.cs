using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACES.APP
{
    public interface IUserQueryFileApp
    {
        Task<byte[]> GetUserImage(ConsultUserSignature signature);
    }
}