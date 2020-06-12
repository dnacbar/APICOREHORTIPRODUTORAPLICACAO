using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace SERVICECOREHORTICOMMAND.ISERVICE
{
    public interface IUserDomainService
    {
        Task UserServiceCreate(Userhorti userhorti);
        Task UserServiceDelete(Userhorti userhorti);
        Task UserServiceUpdate(Userhorti userhorti);
    }
}
