using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.REPOSITORY;
using DATACOREHORTIQUERY.IQUERIES;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public class ClientRepository : _BaseRepository<IClient>, IClientRepository
    {
        public ClientRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<IClient> ClientByIdOrEmail(ConsultClientSignature signature)
        {
            return await EntityByFilter(Where: x => x.IdClient == signature.IdClient || x.DsEmail == signature.DsEmail,
                                        Select: p => new IClient
                                        {
                                            IdClient = p.IdClient,
                                            DsClient = p.DsClient,
                                            DsEmail = p.DsEmail,
                                            DsPhone = p.DsPhone,
                                            DsFederalInscription = p.DsFederalInscription,
                                            IdCityNavigation = new ICity
                                            {
                                                IdCity = p.IdCityNavigation.IdCity,
                                                DsCity = p.IdCityNavigation.DsCity,
                                                Id = new IState
                                                {
                                                    IdState = p.IdCityNavigation.Id.IdState,
                                                    DsState = p.IdCityNavigation.Id.DsState
                                                }
                                            },
                                            IdDistrictNavigation = new IDistrict
                                            {
                                                IdDistrict = p.IdDistrictNavigation.IdDistrict,
                                                DsDistrict = p.IdDistrictNavigation.DsDistrict
                                            }
                                        });
        }

        public async Task<IEnumerable<IClient>> FullListOfClients()
        {
            return await FullListOfEntities(Select: x => new IClient
            {
                IdClient = x.IdClient,
                DsClient = x.DsClient,
                DsEmail = x.DsEmail,
                DsPhone = x.DsPhone,
                DsFederalInscription = x.DsFederalInscription,
                IdCityNavigation = new ICity
                {
                    IdCity = x.IdCityNavigation.IdCity,
                    DsCity = x.IdCityNavigation.DsCity,
                    Id = new IState
                    {
                        IdState = x.IdCityNavigation.Id.IdState,
                        DsState = x.IdCityNavigation.Id.DsState
                    }
                },
                IdDistrictNavigation = new IDistrict
                {
                    IdDistrict = x.IdDistrictNavigation.IdDistrict,
                    DsDistrict = x.IdDistrictNavigation.DsDistrict
                }
            },
                                            OrderBy: p => p.DsClient);
        }

        public async Task<IEnumerable<IClient>> ListOfClients(ConsultClientSignature signature)
        {
            return await ListOfEntities(Where: x => (signature.IdClient == null || signature.IdClient == x.IdClient)
                                                 && (signature.DsEmail == null || signature.DsEmail == x.DsEmail)
                                                 && (signature.DsClient == null || signature.DsClient == x.DsClient),
                                        Select: x => new IClient
                                        {
                                            IdClient = x.IdClient,
                                            DsClient = x.DsClient,
                                            DsEmail = x.DsEmail,
                                            DsPhone = x.DsPhone,
                                            DsFederalInscription = x.DsFederalInscription,
                                            IdCityNavigation = new ICity
                                            {
                                                IdCity = x.IdCityNavigation.IdCity,
                                                DsCity = x.IdCityNavigation.DsCity,
                                                Id = new IState
                                                {
                                                    IdState = x.IdCityNavigation.Id.IdState,
                                                    DsState = x.IdCityNavigation.Id.DsState
                                                }
                                            },
                                            IdDistrictNavigation = new IDistrict
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
