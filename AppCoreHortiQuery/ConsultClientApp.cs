using APPCOREHORTIQUERY.CONVERTERS;
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

        public Task<UserInformationResult> GetClient(ConsultCitySignature signature)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserClientInformationResult>> GetListOfCitiesByName(ConsultClientSignature signature)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserClientInformationResult>> GetListOfClients()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserClientInformationResult>> GetListOfClientsByName(ConsultClientSignature signature)
        {
            throw new System.NotImplementedException();
        }
    }
}
