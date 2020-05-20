using DATAACCESSCOREHORTICOMMAND.ICOMMAND;
using DATACOREHORTICOMMAND;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATAACCESSCOREHORTICOMMAND.COMMAND
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
