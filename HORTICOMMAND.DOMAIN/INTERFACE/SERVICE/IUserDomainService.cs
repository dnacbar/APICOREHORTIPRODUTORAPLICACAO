using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACE.SERVICE
{
    public interface IUserDomainService
    {
        Task UserServiceCreate(Userhorti userhorti);
        Task UserServiceDelete(Userhorti userhorti);
        Task UserServiceUpdate(Userhorti userhorti);
    }
}
