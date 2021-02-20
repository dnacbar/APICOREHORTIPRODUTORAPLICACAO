using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.APP
{
    public interface IUserQueryFileApp
    {
        Task<byte[]> GetUserImage(IUserQuerySignature signature);
    }
}