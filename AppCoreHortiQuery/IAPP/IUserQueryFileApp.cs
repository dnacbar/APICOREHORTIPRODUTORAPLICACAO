using APPDTOCOREHORTIQUERY.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.IAPP
{
    public interface IUserQueryFileApp
    {
        Task<byte[]> GetUserImage(ConsultUserSignature signature);
    }
}