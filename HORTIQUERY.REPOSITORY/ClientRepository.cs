using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public class ClientRepository : _BaseEFQueryRepository<Client>, IClientRepository
    {
        public ClientRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<Client> ClientByIdOrName(IClientQuerySignature signature)
        {
            return await EntityByFilter(Where: x => x.IdClient == signature.Id || x.DsClient == signature.Client,
                                        Select: p => new Client
                                        {
                                            IdClient = p.IdClient,
                                            DsClient = p.DsClient,
                                            DsEmail = p.DsEmail,
                                            DsPhone = p.DsPhone,
                                            DsFederalInscription = p.DsFederalInscription,
                                            IdCityNavigation = new City
                                            {
                                                IdCity = p.IdCityNavigation.IdCity,
                                                DsCity = p.IdCityNavigation.DsCity,
                                                Id = new State
                                                {
                                                    IdState = p.IdCityNavigation.Id.IdState,
                                                    DsState = p.IdCityNavigation.Id.DsState
                                                }
                                            },
                                            IdDistrictNavigation = new District
                                            {
                                                IdDistrict = p.IdDistrictNavigation.IdDistrict,
                                                DsDistrict = p.IdDistrictNavigation.DsDistrict
                                            }
                                        });
        }

        public async Task<IEnumerable<Client>> FullListOfClients()
        {
            return await FullListOfEntity(Select: x => new Client
            {
                IdClient = x.IdClient,
                DsClient = x.DsClient,
                DsEmail = x.DsEmail,
                DsPhone = x.DsPhone,
                DsFederalInscription = x.DsFederalInscription,
                IdCityNavigation = new City
                {
                    IdCity = x.IdCityNavigation.IdCity,
                    DsCity = x.IdCityNavigation.DsCity,
                    Id = new State
                    {
                        IdState = x.IdCityNavigation.Id.IdState,
                        DsState = x.IdCityNavigation.Id.DsState
                    }
                },
                IdDistrictNavigation = new District
                {
                    IdDistrict = x.IdDistrictNavigation.IdDistrict,
                    DsDistrict = x.IdDistrictNavigation.DsDistrict
                }
            },
                                            OrderBy: p => p.DsClient);
        }

        public async Task<IEnumerable<Client>> ListOfClients(IClientQuerySignature signature)
        {
            return await ListOfEntity(Where: x => (signature.Id == null || signature.Id == x.IdClient)
                                                 && (signature.Email == null || signature.Email == x.DsEmail)
                                                 && (signature.Client == null || signature.Client == x.DsClient),
                                        Select: x => new Client
                                        {
                                            IdClient = x.IdClient,
                                            DsClient = x.DsClient,
                                            DsEmail = x.DsEmail,
                                            DsPhone = x.DsPhone,
                                            DsFederalInscription = x.DsFederalInscription,
                                            IdCityNavigation = new City
                                            {
                                                IdCity = x.IdCityNavigation.IdCity,
                                                DsCity = x.IdCityNavigation.DsCity,
                                                Id = new State
                                                {
                                                    IdState = x.IdCityNavigation.Id.IdState,
                                                    DsState = x.IdCityNavigation.Id.DsState
                                                }
                                            },
                                            IdDistrictNavigation = new District
                                            {
                                                IdDistrict = x.IdDistrictNavigation.IdDistrict,
                                                DsDistrict = x.IdDistrictNavigation.DsDistrict
                                            }
                                        },
                                        Page: signature.Page,
                                        Quantity: signature.Quantity,
                                        OrderBy: o => o.DsClient);
        }
    }
}
