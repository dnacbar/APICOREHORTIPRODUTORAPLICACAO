using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.APP
{
    public interface IUserCommandApp
    {
        Task CreateUser(IUserCommandSignature signature);
        Task InactiveUser(IUserCommandSignature signature);
        Task UpdateUser(IUserCommandSignature signature);
    }
}
