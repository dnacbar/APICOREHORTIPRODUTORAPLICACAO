using APPDTOCOREHORTICOMMAND.SIGNATURE;
using System.Threading.Tasks;

namespace APPCOREHORTICOMMAND.IAPP
{
    public interface IUserCommandApp
    {
        Task CreateUser(UserCommandSignature signature);
        Task DeleteUser(UserCommandSignature signature);
        Task UpdateUser(UserCommandSignature signature);
    }
}
