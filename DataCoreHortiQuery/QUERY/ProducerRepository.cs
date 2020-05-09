using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class ProducerRepository : _BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<Producer> ProducerByIdOrEmail(ConsultProducerSignature signature)
        {
            return await EntityByFilter(Where: x => x.IdProducer == signature.IdProducer || x.DsEmail == signature.DsEmail,
            Select: p => new Producer
            {
                IdProducer = p.IdProducer,
                DsProducer = p.DsProducer,
                DsFantasyname = p.DsFantasyname,
                DsEmail = p.DsEmail,
                DsPhone = p.DsPhone,
                DsAddress = p.DsAddress,
                DsZip = p.DsZip,
                DsComplement = p.DsComplement,
                DsNumber = p.DsNumber,
                DsDescription = p.DsDescription,
                DsFederalinscription = p.DsFederalinscription,
                DsStateinscription = p.DsStateinscription,
                DsMunicipalinscription = p.DsMunicipalinscription,
                IdCityNavigation = new City
                {
                    IdCity = p.IdCityNavigation.IdCity,
                    DsCity = p.IdCityNavigation.DsCity,
                    Id = new State
                    {
                        IdState = p.IdCityNavigation.Id.IdState,
                        DsState = p.IdCityNavigation.Id.DsState,
                        DsUf = p.IdCityNavigation.Id.DsUf
                    }
                },
                IdDistrictNavigation = new District
                {
                    IdDistrict = p.IdDistrictNavigation.IdDistrict,
                    DsDistrict = p.IdDistrictNavigation.DsDistrict
                }
            });
        }
    }
}
