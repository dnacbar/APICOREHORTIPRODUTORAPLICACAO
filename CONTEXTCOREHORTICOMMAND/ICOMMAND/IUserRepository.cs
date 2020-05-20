using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.ICOMMAND
{
    public interface IUserRepository
    {
        Task CreateUser(Userhorti userhorti);
        Task DeleteUser(Userhorti userhorti);
        Task UpdateUser(Userhorti userhorti);
    }
}
