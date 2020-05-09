using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DATACOREHORTIQUERY.QUERIES
{
    public class ClientRepository : IClientRepository
    {
        private readonly DBHORTICONTEXT dBHORTICONTEXT;

        public ClientRepository(DBHORTICONTEXT _dBHORTICONTEXT)
        {
            dBHORTICONTEXT = _dBHORTICONTEXT;
        }

        public async Task<Client> ClientByIdOrEmail(ConsultClientSignature signature)
        {
            var client = new Client();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    client = await dBHORTICONTEXT.Client
                                                 .Select(x => new Client
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
                                                 })
                                                 .AsNoTracking()
                                                 .FirstOrDefaultAsync(x => x.IdClient == signature.IdClient
                                                                        || x.DsEmail == signature.DsEmail);
                }
                scope.Complete();
            }
            return client;
        }

        public async Task<IEnumerable<Client>> FullListOfClients()
        {
            var listOfClients = new List<Client>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfClients = await dBHORTICONTEXT.Client
                                                        .Select(x => new Client
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
                                                        })
                                                        .AsNoTracking()
                                                        .ToListAsync();
                }
                scope.Complete();
            }
            return listOfClients;
        }

        public async Task<IEnumerable<Client>> ListOfClients(ConsultClientSignature signature)
        {
            var listOfClients = new List<Client>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfClients = await dBHORTICONTEXT.Client
                                                        .Where(x => (signature.IdClient == null || signature.IdClient == x.IdClient)
                                                                 && (signature.DsEmail == null || signature.DsEmail == x.DsEmail)
                                                                 && (signature.DsClient == null  || signature.DsClient == x.DsClient))
                                                        .Select(x => new Client
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
                                                        })
                                                        .AsNoTracking()
                                                        .OrderBy(x => new { x.DsClient, x.BoActive })
                                                        .ToListAsync();
                }
                scope.Complete();
            }
            return listOfClients;
        }
    }
}
