using DomainCoreHortiCommand;
using System.Threading.Tasks;

namespace DataCoreHortiQuery.IQUERIES
{
    public interface IUserHorti
    {
        Task<Userhorti> GetLoginUser(string dsLogin, string dsPassword);
        Task<Userhorti> GetUserhorti(string dsLogin);
    }
}
