using DomainCoreHortiCommand;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.IQUERIES
{
    public interface IUserHortiRepository
    {
        Task<Userhorti> GetLoginUser(string dsLogin, string dsPassword);
        Task<Userhorti> GetUserhorti(string dsLogin);
    }
}
