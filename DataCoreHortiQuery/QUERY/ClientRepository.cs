using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public class ClientRepository : _BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<Client> ClientByIdOrEmail(ConsultClientSignature signature)
        {
            return await EntityByFilter(Where: x => x.IdClient == signature.IdClient || x.DsEmail == signature.DsEmail,
                                        Select: p => new Client
                                        {
                                            IdClient = p.IdClient,
                                            DsClient = p.DsClient,
                                            DsEmail = p.DsEmail,
                                            DsPhone = p.DsPhone,
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
            return await FullListOfEntities(Select: x => new Client
            {
                IdClient = x.IdClient,
                DsClient = x.DsClient,
                DsEmail = x.DsEmail,
                DsPhone = x.DsPhone,
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

        public async Task<IEnumerable<Client>> ListOfClients(ConsultClientSignature signature)
        {
            return await ListOfEntities(Where: x => (signature.IdClient == null || signature.IdClient == x.IdClient)
                                                 && (signature.DsEmail == null || signature.DsEmail == x.DsEmail)
                                                 && (signature.DsClient == null || signature.DsClient == x.DsClient),
                                        Select: x => new Client
                                        {
                                            IdClient = x.IdClient,
                                            DsClient = x.DsClient,
                                            DsEmail = x.DsEmail,
                                            DsPhone = x.DsPhone,
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
