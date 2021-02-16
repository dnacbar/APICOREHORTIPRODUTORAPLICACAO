using System.Threading.Tasks;

namespace HORTICOMMAND.DOMAIN.INTERFACES.REPOSITORY
{
    public interface IUserRepository
    {
        Task CreateUser(Userhorti userhorti);
        Task DeleteUser(Userhorti userhorti);
        Task UpdateUser(Userhorti userhorti);
    }
}
