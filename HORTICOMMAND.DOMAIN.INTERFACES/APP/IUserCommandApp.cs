using HORTICOMMAND.DOMAIN.INTERFACES.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.APP
{
    public interface IUserCommandApp
    {
        Task CreateUser(IUserCommandSignature signature);
        Task InactiveUser(IUserCommandSignature signature);
        Task UpdateUser(IUserCommandSignature signature);
    }
}
