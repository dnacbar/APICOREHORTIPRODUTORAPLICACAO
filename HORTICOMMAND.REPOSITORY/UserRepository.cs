using HORTICOMMAND.DOMAIN.INTERFACE.REPOSITORY;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Threading.Tasks;

namespace HORTICOMMAND.REPOSITORY
{
    public sealed class UserRepository : _BaseRepository<Userhorti>, IUserRepository
    {
        public UserRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public async Task CreateUser(Userhorti userhorti)
        {
            await CreateEntity(userhorti);
        }

        public async Task DeleteUser(Userhorti userhorti)
        {
            await DeleteEntity(userhorti, true);
        }

        public async Task UpdateUser(Userhorti userhorti)
        {
            await UpdateEntity(userhorti);
        }
    }
}
