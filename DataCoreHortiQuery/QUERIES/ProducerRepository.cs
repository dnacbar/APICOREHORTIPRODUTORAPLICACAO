using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class ProducerRepository : IProducerRepository
    {
        private readonly DBHORTICONTEXT dBHORTICONTEXT;

        public ProducerRepository(DBHORTICONTEXT _dBHORTICONTEXT)
        {
            dBHORTICONTEXT = _dBHORTICONTEXT;
        }

        public async Task<Producer> GetProducerByIdOrEmail(ConsultProducerSignature signature)
        {
            var producer = new Producer();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    producer = await dBHORTICONTEXT.Producer
                                                   .Select(x => new Producer
                                                   {
                                                       IdProducer = x.IdProducer,
                                                       DsProducer = x.DsProducer,
                                                       DsFantasyname = x.DsFantasyname,
                                                       DsEmail = x.DsEmail,
                                                       DsPhone = x.DsPhone,
                                                       DsAddress = x.DsAddress,
                                                       DsZip = x.DsZip,
                                                       DsComplement = x.DsComplement,
                                                       DsNumber = x.DsNumber,
                                                       DsDescription = x.DsDescription,
                                                       DsFederalinscription = x.DsFederalinscription,
                                                       DsStateinscription = x.DsStateinscription,
                                                       DsMunicipalinscription = x.DsMunicipalinscription,
                                                       IdCityNavigation = new City
                                                       {
                                                           IdCity = x.IdCityNavigation.IdCity,
                                                           DsCity = x.IdCityNavigation.DsCity,
                                                           Id = new State
                                                           {
                                                               IdState = x.IdCityNavigation.Id.IdState,
                                                               DsState = x.IdCityNavigation.Id.DsState,
                                                               DsUf = x.IdCityNavigation.Id.DsUf
                                                           }
                                                       },
                                                       IdDistrictNavigation = new District
                                                       {
                                                           IdDistrict = x.IdDistrictNavigation.IdDistrict,
                                                           DsDistrict = x.IdDistrictNavigation.DsDistrict
                                                       }
                                                   })
                                                   .AsNoTracking()
                                                   .FirstOrDefaultAsync(x => x.IdProducer == signature.IdProducer
                                                                          || x.DsEmail == signature.DsEmail);
                }
                scope.Complete();
            }
            return producer;
        }
    }
}
