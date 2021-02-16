using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.SERVICE
{
    public interface IUserDomainService
    {
        Task UserServiceCreate(Userhorti userhorti);
        Task UserServiceDelete(Userhorti userhorti);
        Task UserServiceUpdate(Userhorti userhorti);
    }
}
