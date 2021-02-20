using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.DOMAIN.INTERFACE.APP
{
    public interface IClientQueryApp
    {
        Task<IClientResult> GetClientByIdOrEmail(IClientQuerySignature signature);
        Task<IEnumerable<IClientResult>> GetFullListOfClients();
        Task<IEnumerable<IClientResult>> GetListOfClients(IClientQuerySignature signature);
    }
}
