using APPCOREHORTIQUERY.INTERFACES;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTIQUERY.IQUERIES;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY
{
    public sealed class ConsultClientApp : IConsultClientApp
    {
        private readonly IClientRepository _clientRepository;

        public ConsultClientApp(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<UserResult> GetClient(ConsultCitySignature signature)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserClientResult>> GetListOfCitiesByName(ConsultClientSignature signature)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserClientResult>> GetListOfClients()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserClientResult>> GetListOfClientsByName(ConsultClientSignature signature)
        {
            throw new System.NotImplementedException();
        }
    }
}
